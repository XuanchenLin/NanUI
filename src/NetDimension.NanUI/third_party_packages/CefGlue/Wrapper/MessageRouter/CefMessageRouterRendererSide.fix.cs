using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Xilium.CefGlue.Wrapper
{


    using BrowserRequestInfoMap = CefBrowserInfoMap<System.Collections.Generic.KeyValuePair<int, int>, Xilium.CefGlue.Wrapper.CefMessageRouterRendererSide.RequestInfo>;

    partial class CefMessageRouterRendererSide
    {
        private int SendQuery(CefBrowser browser, long frameId, int contextId, string request, bool persistent, CefV8Value successCallback, CefV8Value failureCallback)
        {
            Helpers.RequireRendererThread();

            var requestId = _requestIdGenerator.GetNextId();

            var info = new RequestInfo
            {
                Persistent = persistent,
                SuccessCallback = successCallback,
                FailureCallback = failureCallback,
            };
            _browserRequestInfoMap.Add(browser.Identifier, new KeyValuePair<int, int>(contextId, requestId), info);

            var message = CefProcessMessage.Create(_queryMessageName);
            var args = message.Arguments;
            args.SetInt(0, Helpers.Int64GetLow(frameId));
            args.SetInt(1, Helpers.Int64GetHigh(frameId));
            args.SetInt(2, contextId);
            args.SetInt(3, requestId);
            args.SetString(4, request);
            args.SetBool(5, persistent);

            CefFrame frame = browser.GetFrame(frameId);
            frame?.SendProcessMessage(CefProcessId.Browser, message);

            args.Dispose();
            message.Dispose();

            return requestId;
        }

        private bool SendCancel(CefBrowser browser, long frameId, int contextId, int requestId)
        {
            Helpers.RequireRendererThread();

            var browserId = browser.Identifier;

            int cancelCount = 0;
            if (requestId != CefMessageRouter.ReservedId)
            {
                // Cancel a single request.
                bool removed = false;
                var info = GetRequestInfo(browserId, contextId, requestId, true, ref removed);
                if (info != null)
                {
                    Debug.Assert(removed);
                    info.Dispose();
                    cancelCount = 1;
                }
            }
            else
            {
                // Cancel all requests with the specified context ID.
                BrowserRequestInfoMap.Visitor visitor = (int vBrowserId, KeyValuePair<int, int> vInfoId, RequestInfo vInfo, ref bool vRemove) =>
                {
                    if (vInfoId.Key == contextId)
                    {
                        vRemove = true;
                        vInfo.Dispose();
                        cancelCount++;
                    }
                    return true;
                };

                _browserRequestInfoMap.FindAll(browserId, visitor);
            }

            if (cancelCount > 0)
            {
                var message = CefProcessMessage.Create(_cancelMessageName);

                var args = message.Arguments;
                args.SetInt(0, contextId);
                args.SetInt(1, requestId);

                CefFrame frame = browser.GetFrame(frameId);

                frame?.SendProcessMessage(CefProcessId.Browser, message);

                return true;
            }

            return false;
        }

        public bool OnProcessMessageReceived(CefBrowser browser, CefFrame frame, CefProcessId sourceProcess, CefProcessMessage message)
        {
            return OnProcessMessageReceived(browser, sourceProcess, message);
        }
    }
}
