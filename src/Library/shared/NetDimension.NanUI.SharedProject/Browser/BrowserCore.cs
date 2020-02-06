using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Chromium;
using Chromium.Event;
using Chromium.Remote;
using ColoredConsole;
using NetDimension.NanUI.Browser.Handlers;
using NetDimension.WinForm;

namespace NetDimension.NanUI.Browser
{

    public enum JSInvokeMode
    {
        /// <summary>
        /// Inherit from parent object. This is the default mode
        /// for javascript properties.
        /// </summary>
        Inherit,
        /// <summary>
        /// Callbacks from the render process are executed on the 
        /// thread that owns the browser's underlying window handle
        /// within the context of the calling remote thread.
        /// This is the default mode for the webbrowser object.
        /// </summary>
        Invoke,
        /// <summary>
        /// Callback from the render process are executed on the
        /// worker thread which marshals the callback.
        /// </summary>
        DontInvoke
    }
    public class BrowserCore
    {
        public const string ABOUT_BLANK = "about:blank";

        public static event RemoteProcessCreatedEventHandler RemoteProcessCreated;
        public static event OnRegisterCustomSchemesEventHandler OnRegisterCustomSchemes;
        public static event WebKitInitializedEventHanlder OnWebKitInitialized;


        internal bool IsMainFrameLoaded { get; private set; } = false;

        internal static void OnRemoteProcessCreated(RenderProcessHandler processHandler)
        {


            RemoteProcessCreated?.Invoke(new RemoteProcessCreatedEventArgs(processHandler));
        }

        internal static void RaiseWebKitInitialized()
        {
            OnWebKitInitialized?.Invoke();
        }

        internal static void RaiseOnRegisterCustomSchemes(CfxOnRegisterCustomSchemesEventArgs e)
        {
            OnRegisterCustomSchemes?.Invoke(e);
        }

        internal IntPtr OwnerHandle { get; private set; }



        internal RenderProcess remoteProcess;
        internal CfrBrowser remoteBrowser;
        public BrowserClient Client { get; private set; }

        private CfxBrowserSettings browserSettings;
        private string loadUrlDeferred;
        private string loadStringDeferred;

        private readonly object browserSyncRoot = new object();
        private string startUrl;

        public bool IsBrowserCreated { get; set; }

        public Control Owner { get; }
        public IntPtr BrowserWindowHandle { get; private set; }
        public CfxBrowser Browser { get; private set; }
        public CfrBrowser RemoteBrowser { get; private set; }
        public CfxBrowserHost BrowserHost { get; private set; }
        internal readonly Dictionary<string, JSObject> frameGlobalObjects = new Dictionary<string, JSObject>();

        public JSObject GlobalObject { get; private set; }

        public JSObject GlobalObjectForFrame(string frameName)
        {
            JSObject obj;
            if (!frameGlobalObjects.TryGetValue(frameName, out obj))
            {
                obj = new JSObject();
                obj.SetBrowser("window", this);
                frameGlobalObjects.Add(frameName, obj);
            }
            return obj;
        }

        public JSInvokeMode RemoteCallbackInvokeMode { get; set; }
        public bool RemoteCallbacksWillInvoke
        {
            get
            {
                return RemoteCallbackInvokeMode != JSInvokeMode.DontInvoke;
            }
        }

        public event EventHandler<BrowserCreatedEventArgs> BrowserCreated;
        public event EventHandler<BrowserCrashedArgs> BrowserCrashed;
        public event EventHandler<RemoteBrowserCreatedEventArgs> RemoteBrowserCreated;
        public event EventHandler<BrowserV8ContextCreatedEventArgs> OnV8ContextCreated;

        public BrowserCore(Control owner, string startUrl = null, CfxBrowserSettings browserSettings = null)
        {
            Owner = owner;
            OwnerHandle = owner.Handle;

            this.startUrl = startUrl;

            if (browserSettings == null)
            {
                browserSettings = new CfxBrowserSettings();
            }

            this.browserSettings = browserSettings;

            Client = new BrowserClient(this);


            GlobalObject = new JSObject();
            GlobalObject.SetBrowser(null, this);
        }

        internal void RaiseOnV8ContextCreated(CfrBrowser browser, CfrFrame frame, CfrV8Context context)
        {
            OnV8ContextCreated?.Invoke(this, new BrowserV8ContextCreatedEventArgs(browser, frame, context));
        }


        public void NavigateToUrl(string url)
        {
            if (Browser != null)
                Browser.MainFrame.LoadUrl(url);
            else
            {
                lock (browserSyncRoot)
                {
                    if (Browser != null)
                    {
                        Browser.MainFrame.LoadUrl(url);
                    }
                    else
                    {
                        loadUrlDeferred = url;
                    }
                }
            }
        }

        public void LoadString(string stringVal, string url)
        {
            if (Browser != null)
            {
                Browser.MainFrame.LoadString(stringVal, url);
            }
            else
            {
                lock (browserSyncRoot)
                {
                    if (Browser != null)
                    {
                        Browser.MainFrame.LoadString(stringVal, url);
                    }
                    else
                    {
                        loadUrlDeferred = url;
                        loadStringDeferred = stringVal;
                    }
                }
            }
        }


        public void Create(CfxWindowInfo windowInfo)
        {
            if (windowInfo == null)
            {
                windowInfo = new CfxWindowInfo();
            }

            if (string.IsNullOrEmpty(startUrl))
            {
                startUrl = ABOUT_BLANK;
            }

            windowInfo.SetAsDisabledChild(OwnerHandle);

            if (!CfxBrowserHost.CreateBrowser(windowInfo, Client, startUrl, browserSettings, null, null))
            {
                throw new WebBrowserException("Failed to create browser instance.");
            }


        }

        public void Close()
        {
            if (Browser != null)
            {
                BrowserHost.CloseBrowser(true);
                RemoveBrowserCore(Browser.Identifier);
                BrowserHost.Dispose();
                BrowserHost = null;
                Browser.Dispose();
                Browser = null;
            }
        }

        public void ShowDevTools(IWin32Window parent = null)
        {
            CfxWindowInfo windowInfo = new CfxWindowInfo();
            if (parent == null)
            {

                windowInfo.Style = WindowStyle.WS_OVERLAPPEDWINDOW | WindowStyle.WS_CLIPCHILDREN | WindowStyle.WS_CLIPSIBLINGS | WindowStyle.WS_VISIBLE;
                windowInfo.ParentWindow = IntPtr.Zero;
                windowInfo.X = 200;
                windowInfo.Y = 200;
                windowInfo.Width = 800;
                windowInfo.Height = 600;

            }
            else
            {
                var handle = parent.Handle;
                var rect = new RECT();
                User32.GetClientRect(handle, ref rect);
                windowInfo.SetAsChild(parent.Handle, 0, 0, rect.Width, rect.Height);
                windowInfo.ParentWindow = handle;

            }


            windowInfo.WindowName = "NanUI Developer Tools";



            BrowserHost.ShowDevTools(windowInfo, new DevToolBrowserClient(), new CfxBrowserSettings(), null);


            

        }



        internal void OnBrowserCreated(CfxBrowser browser)
        {
            Browser = browser;
            BrowserHost = browser.Host;
            BrowserWindowHandle = browser.Host.WindowHandle;

            AddBrowserCore(this);

            ResizeBrowserWindow();


            BrowserCreated?.Invoke(this, new BrowserCreatedEventArgs(browser));

            ThreadPool.QueueUserWorkItem(AfterSetBrowserTasks);

            IsBrowserCreated = true;
        }



        internal void OnBrowserCrashed(CfxBrowser browser, CfxTerminationStatus status)
        {
            var args = new BrowserCrashedArgs(browser, status);
            BrowserCrashed?.Invoke(this, args);

            if (args.Handled) return;

            browser.Reload();

        }


        private void AfterSetBrowserTasks(object state)
        {

            IsMainFrameLoaded = true;

            lock (browserSyncRoot)
            {
                if (loadUrlDeferred != null)
                {
                    if (loadStringDeferred != null)
                    {
                        Browser.MainFrame.LoadString(loadStringDeferred, loadUrlDeferred);
                    }
                    else
                    {
                        Browser.MainFrame.LoadUrl(loadUrlDeferred);
                    }
                }
            }
        }

        internal void SetRemoteBrowser(CfrBrowser remoteBrowser, RenderProcess remoteProcess)
        {
            this.remoteBrowser = remoteBrowser;
            this.remoteProcess = remoteProcess;
            remoteProcess.AddBrowserReference(this);
            var h = RemoteBrowserCreated;
            if (h != null)
            {
                var e = new RemoteBrowserCreatedEventArgs(remoteBrowser);
                if (Owner.InvokeRequired)
                {
                    RenderThreadInvoke(() => { h(this, e); });
                }
                else
                {
                    h(this, e);
                }
            }
        }

        internal void RemoteProcessExited(RenderProcess process)
        {
            if (process == this.remoteProcess)
            {
                this.remoteBrowser = null;
                this.remoteProcess = null;
            }
        }



        public object RenderThreadInvoke(Delegate method, params object[] args)
        {

            if (!CfxRemoteCallContext.IsInContext)
            {
                throw new WebBrowserException("Can't use RenderThreadInvoke without being in the scope of a render process callback.");
            }

            if (!Owner.InvokeRequired)
                return method.DynamicInvoke(args);

            object retval = null;
            var context = CfxRemoteCallContext.CurrentContext;

            var waitLock = new object();
            lock (waitLock)
            {
                Owner.BeginInvoke((MethodInvoker)(() =>
                {
                    context.Enter();
                    try
                    {
                        retval = method.DynamicInvoke(args);
                    }
                    finally
                    {
                        context.Exit();
                        lock (waitLock)
                        {
                            Monitor.PulseAll(waitLock);
                        }
                    }
                }));
                Monitor.Wait(waitLock);
            }
            return retval;
        }

        public void InvokeIfRequired(Action a)
        {
            if (Owner == null) return;

            if (Owner.InvokeRequired)
                Owner.Invoke(a);
            else
                a();
        }

        public void RenderThreadInvoke(MethodInvoker method)
        {

            if (!CfxRemoteCallContext.IsInContext)
            {
                throw new WebBrowserException("Can't use RenderThreadInvoke without being in the scope of a render process callback.");
            }

            if (!Owner.InvokeRequired)
            {
                method.Invoke();
                return;
            }

            var context = CfxRemoteCallContext.CurrentContext;

            var waitLock = new object();
            lock (waitLock)
            {
                Owner.BeginInvoke((MethodInvoker)(() =>
                {
                    context.Enter();
                    try
                    {
                        method.Invoke();
                    }
                    finally
                    {
                        context.Exit();
                        lock (waitLock)
                        {
                            Monitor.PulseAll(waitLock);
                        }
                    }
                }));
                Monitor.Wait(waitLock);
            }
        }

        public bool ExecuteJavascript(string code)
        {
            if (Browser != null)
            {
                Browser.MainFrame.ExecuteJavaScript(code, null, 0);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ExecuteJavascript(string code, string scriptUrl, int startLine)
        {
            if (Browser != null)
            {
                Browser.MainFrame.ExecuteJavaScript(code, scriptUrl, startLine);
                return true;
            }
            else
            {
                return false;
            }
        }



        #region RegisterToGlobal
        public bool RegisterToGlobal(string name, Action<CfrV8Value> action)
        {
            var rb = remoteBrowser;
            if (rb == null) return false;
            try
            {
                var ctx = rb.CreateRemoteCallContext();
                ctx.Enter();
                try
                {
                    var taskRunner = CfrTaskRunner.GetForThread(CfxThreadId.Renderer);
                    var task = new RegisterTask(this, name, JSInvokeMode.Inherit, action);
                    taskRunner.PostTask(task);
                    return true;
                }
                finally
                {
                    ctx.Exit();
                }
            }
            catch (CfxRemotingException)
            {
                return false;
            }
        }

        private class RegisterTask : CfrTask
        {
            private BrowserCore browserCore;
            private JSInvokeMode invokeMode;
            private Action<CfrV8Value> globalTask;
            private string name;

            public RegisterTask(BrowserCore browserCore, string name, JSInvokeMode invokeMode, Action<CfrV8Value> globalTask)
            {
                this.name = name;
                this.browserCore = browserCore;
                this.invokeMode = invokeMode;
                this.globalTask = globalTask;
                Execute += (s, e) =>
                {
                    if (invokeMode == JSInvokeMode.Invoke || (invokeMode == JSInvokeMode.Inherit && browserCore.RemoteCallbacksWillInvoke))
                        browserCore.RenderThreadInvoke(() => RegisterTask_Execute(e));
                    else
                        RegisterTask_Execute(e);
                };
            }

            private void RegisterTask_Execute(CfrEventArgs e)
            {
                CfrV8Context context;


                try
                {
                    context = browserCore.remoteBrowser.MainFrame.V8Context;

                    context.Enter();

                    try
                    {
                        var global = context.Global;
                        Console.WriteLine($"{global.IsObject}");
                        var keys = new List<string>();
                        //global.GetKeys(keys);

                        //Console.WriteLine(String.Join(";", keys));

                        globalTask?.Invoke(global);
                    }
                    finally
                    {
                        context.Exit();
                    }

                }
                catch (Exception)
                {
                    return;
                }

            }
        }
        #endregion

        #region EvaluateJavascriptTask
        public bool EvaluateJavascript(string code, Action<CfrV8Value, CfrV8Exception> callback)
        {
            return EvaluateJavascript(code, JSInvokeMode.Inherit, callback);
        }

        public bool EvaluateJavascript(string code, JSInvokeMode invokeMode, Action<CfrV8Value, CfrV8Exception> callback)
        {
            var rb = remoteBrowser;
            if (rb == null) return false;
            try
            {
                var ctx = rb.CreateRemoteCallContext();
                ctx.Enter();
                try
                {
                    var taskRunner = CfrTaskRunner.GetForThread(CfxThreadId.Renderer);
                    var task = new EvaluateTask(this, code, invokeMode, callback);
                    taskRunner.PostTask(task);
                    return true;
                }
                finally
                {
                    ctx.Exit();
                }
            }
            catch (CfxRemotingException)
            {
                return false;
            }
        }

        private class EvaluateTask : CfrTask
        {

            BrowserCore core;
            string code;
            JSInvokeMode invokeMode;
            Action<CfrV8Value, CfrV8Exception> callback;

            internal EvaluateTask(BrowserCore core, string code, JSInvokeMode invokeMode, Action<CfrV8Value, CfrV8Exception> callback)
            {
                this.core = core;
                this.code = code;
                this.invokeMode = invokeMode;
                this.callback = callback;
                Execute += (s, e) =>
                {
                    if (invokeMode == JSInvokeMode.Invoke || (invokeMode == JSInvokeMode.Inherit && core.RemoteCallbacksWillInvoke))
                        core.RenderThreadInvoke(() => Task_Execute(e));
                    else
                        Task_Execute(e);
                };
            }

            void Task_Execute(CfrEventArgs e)
            {
                CfrV8Context context;
                CfrV8Value retval;
                CfrV8Exception ex;
                bool result = false;
                try
                {
                    context = core.remoteBrowser.MainFrame.V8Context;
                    result = context.Eval(code, null, 0, out retval, out ex);
                }
                catch
                {
                    callback(null, null);
                    return;
                }
                context.Enter();
                try
                {
                    if (result)
                    {
                        callback(retval, null);
                    }
                    else
                    {
                        callback(null, ex);
                    }
                }
                finally
                {
                    context.Exit();
                }
            }
        }
        #endregion

        #region Resize browser window
        public void ResizeBrowserWindow()
        {
            if (BrowserWindowHandle == IntPtr.Zero) return;



            var visible = Owner.Visible;
            var rect = new RECT();

            User32.GetClientRect(OwnerHandle, ref rect);

            var width = rect.Width;
            var height = rect.Height;


            if (visible)
            {
                User32.SetWindowLong(BrowserWindowHandle, GetWindowLongFlags.GWL_STYLE, (IntPtr)(WindowStyles.WS_CHILD | WindowStyles.WS_CLIPCHILDREN | WindowStyles.WS_CLIPSIBLINGS | WindowStyles.WS_TABSTOP | WindowStyles.WS_VISIBLE));

                User32.SetWindowPos(BrowserWindowHandle, IntPtr.Zero, 0, 0, width, height, SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOZORDER | SetWindowPosFlags.SWP_SHOWWINDOW | SetWindowPosFlags.SWP_NOCOPYBITS | SetWindowPosFlags.SWP_ASYNCWINDOWPOS);

            }
            else
            {
                User32.SetWindowLong(BrowserWindowHandle, GetWindowLongFlags.GWL_STYLE, (IntPtr)(WindowStyles.WS_CHILD | WindowStyles.WS_CLIPCHILDREN | WindowStyles.WS_CLIPSIBLINGS | WindowStyles.WS_TABSTOP | WindowStyles.WS_DISABLED));

                User32.SetWindowPos(BrowserWindowHandle, IntPtr.Zero, 0, 0, width, height, SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_HIDEWINDOW | SetWindowPosFlags.SWP_ASYNCWINDOWPOS);
            }
        }
        #endregion

        #region BrowserCore Cache
        internal static readonly Dictionary<int, WeakReference> browserCoreRefs = new Dictionary<int, WeakReference>();
        public static BrowserCore GetBrowserCore(int id)
        {
            lock (browserCoreRefs)
            {
                WeakReference r;
                if (browserCoreRefs.TryGetValue(id, out r))
                {
                    return (BrowserCore)r.Target;
                }
                return null;
            }
        }

        public static void RemoveBrowserCore(int id)
        {
            lock (browserCoreRefs)
            {

                if (browserCoreRefs.TryGetValue(id, out WeakReference r))
                {
                    var target = (BrowserCore)r.Target;
                    browserCoreRefs.Remove(id);

                    //ColorConsole.WriteLine("[BrowserCache] ".Yellow(), "Remove browser [".Gray(), $"{id}".Yellow(), "] from BrowserCache. Remain [".Gray(), $"{browserCoreRefs.Count}".Yellow(), "] browser references.".Gray());
                }
            }
        }

        internal static void AddBrowserCore(BrowserCore browserCore)
        {
            lock (browserCoreRefs)
            {
                var deadRefs = new List<int>(browserCoreRefs.Count);
                foreach (var b in browserCoreRefs)
                {
                    if (!b.Value.IsAlive) deadRefs.Add(b.Key);
                }
                foreach (var r in deadRefs)
                {
                    browserCoreRefs.Remove(r);
                }
                browserCoreRefs[browserCore.Browser.Identifier] = new WeakReference(browserCore);

                //NanUI.Log("[BrowserCache] ".Yellow(), "Added new browser [".Gray(), $"{browserCore.Browser.Identifier}".Yellow(), "] to BrowserCache. There are [".Gray(), $"{browserCoreRefs.Count}".Yellow(), "] browser references.".Gray());

            }
        }


        #endregion
    }

    public class BrowserV8ContextCreatedEventArgs : EventArgs
    {
        public BrowserV8ContextCreatedEventArgs(CfrBrowser browser, CfrFrame frame, CfrV8Context context)
        {
            Browser = browser;
            Frame = frame;
            Context = context;
        }

        public CfrBrowser Browser { get; }
        public CfrFrame Frame { get; }
        public CfrV8Context Context { get; }
    }

    public class BrowserCreatedEventArgs : EventArgs
    {
        public CfxBrowser Browser { get; private set; }
        internal BrowserCreatedEventArgs(CfxBrowser browser)
        {
            Browser = browser;
        }
    }

    public class BrowserCrashedArgs : EventArgs
    {
        public CfxBrowser Browser { get; }
        public CfxTerminationStatus Status { get; }

        public bool Handled { get; set; } = false;

        public BrowserCrashedArgs(CfxBrowser browser, CfxTerminationStatus status)
        {
            Browser = browser;
            Status = status;
        }
    }


    public class RemoteBrowserCreatedEventArgs : EventArgs
    {
        public CfrBrowser Browser { get; private set; }
        internal RemoteBrowserCreatedEventArgs(CfrBrowser browser)
        {
            Browser = browser;
        }
    }

    public class RemoteProcessCreatedEventArgs : EventArgs
    {
        public CfrRenderProcessHandler RenderProcessHandler { get; private set; }
        internal RemoteProcessCreatedEventArgs(CfrRenderProcessHandler renderProcessHandler)
        {
            RenderProcessHandler = renderProcessHandler;
        }
    }

    public delegate void RemoteProcessCreatedEventHandler(RemoteProcessCreatedEventArgs e);
    public delegate void WebKitInitializedEventHanlder();
    public delegate void OnRegisterCustomSchemesEventHandler(CfxOnRegisterCustomSchemesEventArgs e);



}
