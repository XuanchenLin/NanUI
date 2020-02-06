using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.Browser
{
    using Chromium;
    using Chromium.Remote;

    internal class RenderProcess
    {
        private readonly CfrApp app;
        private readonly RenderProcessHandler processHandler;

        private List<WeakReference> browserRefs = new List<WeakReference>();

        internal int RemoteProcessId { get; private set; }

        internal static int RenderProcessMain()
        {
            try
            {
                var rp = new RenderProcess();
                BrowserCore.OnRemoteProcessCreated(rp.processHandler);
                return rp.Initialize();
            }
            catch (CfxRemotingException)
            {
                return -1;
            }
        }

        private RenderProcess()
        {
            RemoteProcessId = CfxRemoteCallContext.CurrentContext.ProcessId;
            app = new CfrApp();
            processHandler = new RenderProcessHandler(this);
            app.GetRenderProcessHandler += (s, e) => e.SetReturnValue(processHandler);
        }

        internal void AddBrowserReference(BrowserCore browser)
        {
            for (int i = 0; i < browserRefs.Count; ++i)
            {
                if (browserRefs[i].Target == null)
                {
                    browserRefs[i] = new WeakReference(browser);
                    return;
                }
            }
            browserRefs.Add(new WeakReference(browser));
        }

        //internal void RemoveBrowserReference(BrowserCore browser)
        //{
        //    var reffedBrowser = browserRefs.Find(x => x.Target.Equals(browser));
        //    //if (reffedBrowser != null)
        //    //{
        //    //    browserRefs.Remove(reffedBrowser);
        //    //}
        //}

        private int Initialize()
        {
            try
            {
                var retval = CfrRuntime.ExecuteProcess(app);
                return retval;
            }
            finally
            {
                foreach (var br in browserRefs)
                {
                    if (br.Target == null) continue;

                    var b = (BrowserCore)br.Target;
                    b?.RemoteProcessExited(this);
                }
            }
        }


    }
}
