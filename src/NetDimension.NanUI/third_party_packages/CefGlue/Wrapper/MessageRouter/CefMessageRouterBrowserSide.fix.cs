using System;
using System.Collections.Generic;
using System.Text;
using Xilium.CefGlue;

namespace Xilium.CefGlue.Wrapper
{
    partial class CefMessageRouterBrowserSide
    {

        private void SendQuerySuccess(CefFrame frame, int contextId, int requestId, string response)
        {
            
            var message = CefProcessMessage.Create(_queryMessageName);
            var args = message.Arguments;
            args.SetInt(0, contextId);
            args.SetInt(1, requestId);
            args.SetBool(2, true);  // Indicates a success result.
            args.SetString(3, response);
            frame?.SendProcessMessage(CefProcessId.Renderer, message);
            args.Dispose();
            message.Dispose();
        }

        private void SendQueryFailure(CefFrame frame, int contextId, int requestId, int errorCode, string errorMessage)
        {
            var message = CefProcessMessage.Create(_queryMessageName);
            var args = message.Arguments;
            args.SetInt(0, contextId);
            args.SetInt(1, requestId);
            args.SetBool(2, false);  // Indicates a failure result.
            args.SetInt(3, errorCode);
            args.SetString(4, errorMessage);
            frame?.SendProcessMessage(CefProcessId.Renderer, message);
            args.Dispose();
            message.Dispose();
        }
    }
}
