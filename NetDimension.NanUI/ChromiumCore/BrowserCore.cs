using Chromium;
using Chromium.Event;
using Chromium.Remote;
using Chromium.Remote.Event;
using Chromium.WebBrowser;
using Chromium.WebBrowser.Event;
using NetDimension.Windows.Imports;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetDimension.NanUI.HostObjects;
using NetDimension.NanUI;

namespace Chromium.WebBrowser
{
	public class BrowserCore : NativeWindow, IChromiumClient, IDisposable
	{
		#region STATIC
		private static CfxBrowserSettings defaultBrowserSettings;
		/// <summary>
		/// The CfxBrowserSettings applied for new instances of ChromiumWebBrowser.
		/// Any changes to these settings will only apply to new browsers,
		/// leaving already created browsers unaffected.
		/// </summary>
		public static CfxBrowserSettings DefaultBrowserSettings
		{
			get
			{
				if (defaultBrowserSettings == null)
				{
					defaultBrowserSettings = new CfxBrowserSettings();
				}
				return defaultBrowserSettings;
			}
		}

		/// <summary>
		/// Provides an opportunity to change initialization settings
		/// and subscribe to browser process handler events.
		/// </summary>
		public static event OnBeforeCfxInitializeEventHandler OnBeforeCfxInitialize;
		internal static void RaiseOnBeforeCfxInitialize(CfxSettings settings, CfxBrowserProcessHandler processHandler)
		{
			var handler = OnBeforeCfxInitialize;

			if (handler != null)
			{
				var e = new OnBeforeCfxInitializeEventArgs(settings, processHandler);
				handler(e);
			}
		}

		/// <summary>
		/// Provides an opportunity to view and/or modify command-line arguments before
		/// processing by CEF and Chromium. The |ProcessType| value will be NULL for
		/// the browser process. Do not keep a reference to the CfxCommandLine
		/// object passed to this function. The CfxSettings.CommandLineArgsDisabled
		/// value can be used to start with an NULL command-line object. Any values
		/// specified in CfxSettings that equate to command-line arguments will be set
		/// before this function is called. Be cautious when using this function to
		/// modify command-line arguments for non-browser processes as this may result
		/// in undefined behavior including crashes.
		/// </summary>
		public static event OnBeforeCommandLineProcessingEventHandler OnBeforeCommandLineProcessing;
		internal static void RaiseOnBeforeCommandLineProcessing(CfxOnBeforeCommandLineProcessingEventArgs e)
		{
			OnBeforeCommandLineProcessing?.Invoke(e);
		}

		/// <summary>
		/// Provides an opportunity to register custom schemes. Do not keep a reference
		/// to the |Registrar| object. This function is called on the main thread for
		/// each process and the registered schemes should be the same across all
		/// processes.
		/// </summary>
		public static event OnRegisterCustomSchemesEventHandler OnRegisterCustomSchemes;
		internal static void RaiseOnRegisterCustomSchemes(CfxOnRegisterCustomSchemesEventArgs e)
		{
			OnRegisterCustomSchemes?.Invoke(e);
		}

		/// <summary>
		/// For each new render process created, provides an opportunity to subscribe
		/// to CfrRenderProcessHandler remote callback events.
		/// </summary>
		public static event RemoteProcessCreatedEventHandler RemoteProcessCreated;
		internal static void RaiseRemoteProcessCreated(CfrRenderProcessHandler renderProcessHandler)
		{
			RemoteProcessCreated?.Invoke(new RemoteProcessCreatedEventArgs(renderProcessHandler));
		}

		/// <summary>
		/// Initialize the ChromiumWebBrowser and ChromiumFX libraries.
		/// The application can change initialization settings by handling
		/// the OnBeforeCfxInitialize event.
		/// </summary>
		public static void Initialize()
		{
			BrowserProcess.Initialize();
		}
		/// <summary>
		/// This function should be called on the main application thread to shut down
		/// the CEF browser process before the application exits.
		/// </summary>
		public static void Shutdown()
		{
			CfxRuntime.Shutdown();
		}

		/// <summary>
		/// The CfxBrowserProcessHandler for this browser process.
		/// Do not access this property before calling ChromiumWebBrowser.Initialize()
		/// </summary>
		public static CfxBrowserProcessHandler BrowserProcessHandler
		{
			get
			{
				return BrowserProcess.processHandler;
			}
		}

		private static readonly Dictionary<int, WeakReference> browsers = new Dictionary<int, WeakReference>();

		public static BrowserCore GetBrowser(int id)
		{
			lock (browsers)
			{
				WeakReference r;
				if (browsers.TryGetValue(id, out r))
				{
					return (BrowserCore)r.Target;
				}
				return null;
			}
		}

		private static void AddToBrowserCache(BrowserCore wb)
		{
			lock (browsers)
			{
				var deadRefs = new List<int>(browsers.Count);
				foreach (var b in browsers)
				{
					if (!b.Value.IsAlive) deadRefs.Add(b.Key);
				}
				foreach (var r in deadRefs)
				{
					browsers.Remove(r);
				}
				browsers[wb.Browser.Identifier] = new WeakReference(wb);
			}
		}
		#endregion

		private BrowserClient client;

		/// <summary>
		/// Returns the CfxBrowser object for this ChromiumWebBrowser.
		/// Might be null if the browser has not yet been created.
		/// Wait for the BrowserCreated event before accessing this property.
		/// </summary>
		public CfxBrowser Browser { get; private set; }

		/// <summary>
		/// Returns the CfxBrowserHost object for this ChromiumWebBrowser.
		/// Might be null if the browser has not yet been created.
		/// Wait for the BrowserCreated event before accessing this property.
		/// </summary>
		public CfxBrowserHost BrowserHost { get; private set; }

		/// <summary>
		/// The invoke mode for this browser. See also JSInvokeMode.
		/// Changes to the invoke mode will be effective after the next
		/// time the browser creates a V8 context. If this is set to
		/// "Inherit", then "Invoke" will be assumed. The invoke mode
		/// also applies to VisitDom and EvaluateJavascript.
		/// </summary>
		public JSInvokeMode RemoteCallbackInvokeMode { get; set; }

		/// <summary>
		/// Indicates whether render process callbacks on this browser
		/// will be executed on the thread that owns the 
		/// browser's underlying window handle.
		/// Depends on the invoke mode. If the invoke mode is set to
		/// "Inherit", then "Invoke" will be assumed.
		/// </summary>
		public bool RemoteCallbacksWillInvoke
		{
			get
			{
				return RemoteCallbackInvokeMode != JSInvokeMode.DontInvoke;
			}
		}

		private Control parentControl;
		private IntPtr parentWindowHandle;
		private IntPtr browserWindowHandle;
		private BrowserWidgetMessageInterceptor messageInterceptor;


		private Region draggableRegion = null;
		private float scaleFactor = 1.0f;

		private readonly object browserSyncRoot = new object();
		internal readonly Dictionary<string, JSObject> frameGlobalObjects = new Dictionary<string, JSObject>();
		internal readonly Dictionary<string, WebResource> webResources = new Dictionary<string, WebResource>();

		public Dictionary<string, WebResource> WebResources => webResources;

		internal RenderProcess remoteProcess;
		internal CfrBrowser remoteBrowser;

		private string initialUrl;
		private string m_loadUrlDeferred;
		private string m_loadStringDeferred;
		//private NanUIObject nanuiJSObject;
		private NanUIHostObject nanuiJSObject;

		public IntPtr BrowserHandle
		{
			get
			{
				return browserWindowHandle;
			}
		}

		public BrowserCore()
	: this(null, null, true)
		{

		}

		public BrowserCore(Control parentContainer)
	: this(parentContainer, null, true)
		{

		}
		public BrowserCore(Control parentContainer, string initialUrl)
			: this(parentContainer, initialUrl, true)
		{

		}

		public BrowserCore(Control parentControl, string initialUrl, bool createImmediately)
		{
			this.parentControl = parentControl;
			parentWindowHandle = parentControl.Handle;

			if (string.IsNullOrEmpty(initialUrl))
				this.initialUrl = "about:blank";
			else
				this.initialUrl = initialUrl;

			scaleFactor = User32.GetOriginalDeviceScaleFactor(parentWindowHandle);




			client = new BrowserClient(this);

			//nanuiJSObject = new NanUIObject(parentControl);
			GlobalObject = new JSObject();
			GlobalObject.SetBrowser("window", this);
			//GlobalObject.Add("NanUI", nanuiJSObject);

			nanuiJSObject = new NanUIHostObject(parentControl);
			GlobalObject.RegisterJSObject(nanuiJSObject);


			if (createImmediately)
				CreateBrowser();

			AssignHandle(parentWindowHandle);

		}

		/// <summary>
		/// Creates the underlying CfxBrowser with the default CfxRequestContext.
		/// This method should only be called if this ChromiumWebBrowser
		/// was instanciated with createImmediately == false.
		/// </summary>
		public void CreateBrowser()
		{
			CreateBrowser((CfxRequestContext)null);
		}

		/// <summary>
		/// Creates the underlying CfxBrowser with the default CfxRequestContext
		/// and the given initial URL.
		/// This method should only be called if this ChromiumWebBrowser
		/// was instanciated with createImmediately == false.
		/// </summary>
		public void CreateBrowser(string initialUrl)
		{
			this.initialUrl = initialUrl;
			CreateBrowser((CfxRequestContext)null);
		}

		/// <summary>
		/// Creates the underlying CfxBrowser with the given 
		/// CfxRequestContext and initial URL.
		/// This method should only be called if this ChromiumWebBrowser
		/// was instanciated with createImmediately == false.
		/// </summary>
		public void CreateBrowser(string initialUrl, CfxRequestContext requestContext)
		{
			this.initialUrl = initialUrl;
			CreateBrowser(requestContext);
		}

		/// <summary>
		/// Creates the underlying CfxBrowser with the given CfxRequestContext.
		/// This method should only be called if this ChromiumWebBrowser
		/// was instanciated with createImmediately == false.
		/// </summary>
		public void CreateBrowser(CfxRequestContext requestContext)
		{

			if (parentControl == null || parentWindowHandle == null)
			{
				throw new CefException("Failed to create browser instance.");
			}

			// avoid illegal cross-thread calls
			if (parentControl.InvokeRequired)
			{
				parentControl.Invoke((MethodInvoker)(() => CreateBrowser(requestContext)));
				return;
			}

			var windowInfo = new CfxWindowInfo();
			// in order to avoid focus issues when creating browsers offscreen,
			// the browser must be created with a disabled child window.
			///windowInfo.SetAsChild(parentWindowHandle,0,0,parentControl.Width, parentControl.Height);

			//windowInfo.SetAsDisabledChild(parentWindowHandle);





			windowInfo.SetAsChild(parentWindowHandle, 0, 0, parentControl.Width, parentControl.Height);

			if (!CfxBrowserHost.CreateBrowser(windowInfo, client, initialUrl, DefaultBrowserSettings, requestContext))
				throw new CefException("Failed to create browser instance.");
		}


		/// <summary>
		/// Returns the context menu handler for this browser. If this is never accessed the default
		/// implementation will be used.
		/// </summary>
		public CfxContextMenuHandler ContextMenuHandler { get { return client.ContextMenuHandler; } }

		/// <summary>
		/// Returns the life span handler for this browser.
		/// </summary>
		public CfxLifeSpanHandler LifeSpanHandler { get { return client.lifeSpanHandler; } }

		/// <summary>
		/// Returns the load handler for this browser.
		/// </summary>
		public CfxLoadHandler LoadHandler { get { return client.LoadHandler; } }

		/// <summary>
		/// Returns the request handler for this browser.
		/// Do not set the return value in the GetResourceHandler event for URLs
		/// with associated WebResources (see also SetWebResource).
		/// </summary>
		public CfxRequestHandler RequestHandler { get { return client.requestHandler; } }

		/// <summary>
		/// Returns the display handler for this browser.
		/// </summary>
		public CfxDisplayHandler DisplayHandler { get { return client.DisplayHandler; } }

		/// <summary>
		/// Returns the download handler for this browser. If this is never accessed
		/// downloads will not be allowed.
		/// </summary>
		public CfxDownloadHandler DownloadHandler { get { return client.DownloadHandler; } }

		/// <summary>
		/// Returns the drag handler for this browser.
		/// </summary>
		public CfxDragHandler DragHandler { get { return client.DragHandler; } }

		/// <summary>
		/// Returns the dialog handler for this browser. If this is never accessed the default
		/// implementation will be used.
		/// </summary>
		public CfxDialogHandler DialogHandler { get { return client.DialogHandler; } }

		/// <summary>
		/// Returns the find handler for this browser.
		/// </summary>
		public CfxFindHandler FindHandler { get { return client.FindHandler; } }

		/// <summary>
		/// Returns the focus handler for this browser.
		/// </summary>
		public CfxFocusHandler FocusHandler { get { return client.FocusHandler; } }

		/// <summary>
		/// Returns the geolocation handler for this browser. If this is never accessed
		/// geolocation access will be denied by default.
		/// </summary>
		public CfxGeolocationHandler GeolocationHandler { get { return client.GeolocationHandler; } }

		/// <summary>
		/// Returns the js dialog handler for this browser. If this is never accessed the default
		/// implementation will be used.
		/// </summary>
		public CfxJsDialogHandler JsDialogHandler { get { return client.JsDialogHandler; } }

		/// <summary>
		/// Returns the keyboard handler for this browser.
		/// </summary>
		public CfxKeyboardHandler KeyboardHandler { get { return client.KeyboardHandler; } }



		/// <summary>
		/// Returns the URL currently loaded in the main frame.
		/// </summary>
		public System.Uri Url
		{
			get
			{
				if (Browser == null) return null;
				Uri retval;
				Uri.TryCreate(Browser.MainFrame.Url, UriKind.RelativeOrAbsolute, out retval);
				return retval;
			}
		}

		/// <summary>
		/// Returns true if the browser is currently loading.
		/// </summary>
		public bool IsLoading { get { return Browser == null ? false : Browser.IsLoading; } }

		/// <summary>
		/// Returns true if the browser can navigate backwards.
		/// </summary>
		public bool CanGoBack { get { return Browser == null ? false : Browser.CanGoBack; } }

		/// <summary>
		/// Returns true if the browser can navigate forwards.
		/// </summary>
		public bool CanGoForward { get { return Browser == null ? false : Browser.CanGoForward; } }

		/// <summary>
		/// Navigate backwards.
		/// </summary>
		public void GoBack() { if (Browser != null) Browser.GoBack(); }

		/// <summary>
		/// Navigate forwards.
		/// </summary>
		public void GoForward() { if (Browser != null) Browser.GoForward(); }

		/// <summary>
		/// Load the specified |url| into the main frame.
		/// </summary>
		public void LoadUrl(string url)
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
						m_loadUrlDeferred = url;
					}
				}
			}
		}

		/// <summary>
		/// Load the contents of |stringVal| with the specified dummy |url|. |url|
		/// should have a standard scheme (for example, http scheme) or behaviors like
		/// link clicks and web security restrictions may not behave as expected.
		/// </summary>
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
						m_loadUrlDeferred = url;
						m_loadStringDeferred = stringVal;
					}
				}
			}
		}

		/// <summary>
		/// Load the contents of |stringVal| with dummy url about:blank.
		/// </summary>
		public void LoadString(string stringVal)
		{
			LoadString(stringVal, "about:blank");
		}
		private int findId;
		private string currentFindText;
		private bool currentMatchCase;

		/// <summary>
		/// Search for |searchText|. |forward| indicates whether to search forward or
		/// backward within the page. |matchCase| indicates whether the search should
		/// be case-sensitive.
		/// Returns the identifier for this find operation (see also CfxFindHandler),
		/// or -1 if the browser has not yet been created.
		/// </summary>
		public int Find(string searchText, bool forward, bool matchCase)
		{
			if (BrowserHost == null)
				return -1;
			var findNext = currentFindText == searchText && currentMatchCase == matchCase;
			if (!findNext)
			{
				currentFindText = searchText;
				currentMatchCase = matchCase;
				++findId;
			}

			BrowserHost.Find(findId, searchText, forward, matchCase, findNext);
			return findId;
		}

		/// <summary>
		/// Search for |searchText|. |forward| indicates whether to search forward or
		/// backward within the page. The search will be case-insensitive.
		/// Returns the identifier for this find operation (see also CfxFindHandler),
		/// or -1 if the browser has not yet been created.
		/// </summary>
		public int Find(string searchText, bool forward)
		{
			return Find(searchText, forward, false);
		}

		/// <summary>
		/// Search for |searchText|. The search will be forward and case-insensitive.
		/// Returns the identifier for this find operation (see also CfxFindHandler),
		/// or -1 if the browser has not yet been created.
		/// </summary>
		public int Find(string searchText)
		{
			return Find(searchText, true, false);
		}

		/// <summary>
		/// Execute a string of javascript code in the browser's main frame.
		/// Execution is asynchronous, this function returns immediately.
		/// Returns false if the browser has not yet been created.
		/// </summary>
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

		/// <summary>
		/// Execute a string of javascript code in the browser's main frame. The |scriptUrl|
		/// parameter is the URL where the script in question can be found, if any. The
		/// renderer may request this URL to show the developer the source of the
		/// error.  The |startLine| parameter is the base line number to use for error
		/// reporting.
		/// Execution is asynchronous, this function returns immediately.
		/// Returns false if the browser has not yet been created.
		/// </summary>
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

		/// <summary>
		/// Special Invoke for framework callbacks from the render process.
		/// Maintains the thread in the context of the calling remote thread.
		/// Use this instead of invoke when the following conditions are meat:
		/// 1) The current thread is executing in the scope of a framework
		///    callback event from the render process (ex. CfrTask.Execute).
		/// 2) You need to Invoke on the webbrowser control and
		/// 3) The invoked code needs to call into the render process.
		/// </summary>
		public Object RenderThreadInvoke(Delegate method, params Object[] args)
		{

			if (!CfxRemoteCallContext.IsInContext)
			{
				throw new CefException("Can't use RenderThreadInvoke without being in the scope of a render process callback.");
			}

			if (parentControl == null || !parentControl.InvokeRequired)
				return method.DynamicInvoke(args);

			object retval = null;
			var context = CfxRemoteCallContext.CurrentContext;

			// Use BeginInvoke and Wait instead of Invoke.
			// Invoke marshals exceptions back to the calling thread.
			// We want exceptions to be thrown in place.

			var waitLock = new object();
			lock (waitLock)
			{
				parentControl.BeginInvoke((MethodInvoker)(() =>
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

		/// <summary>
		/// Special Invoke for framework callbacks from the render process.
		/// Maintains the thread within the context of the calling remote thread.
		/// Use this instead of invoke when the following conditions are meat:
		/// 1) The current thread is executing in the scope of a framework
		///    callback event from the render process (ex. CfrTask.Execute).
		/// 2) You need to Invoke on the webbrowser control and
		/// 3) The invoked code needs to call into the render process.
		/// </summary>
		public void RenderThreadInvoke(MethodInvoker method)
		{

			if (!CfxRemoteCallContext.IsInContext)
			{
				throw new CefException("Can't use RenderThreadInvoke without being in the scope of a render process callback.");
			}

			if (parentControl == null || !parentControl.InvokeRequired)
			{
				method.Invoke();
				return;
			}

			var context = CfxRemoteCallContext.CurrentContext;

			// Use BeginInvoke and Wait instead of Invoke.
			// Invoke marshals exceptions back to the calling thread.
			// We want exceptions to be thrown in place.

			var waitLock = new object();
			lock (waitLock)
			{
				parentControl.BeginInvoke((MethodInvoker)(() =>
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

		/// <summary>
		/// Evaluate a string of javascript code in the browser's main frame.
		/// Evaluation is done asynchronously in the render process.
		/// Returns false if the remote browser is currently unavailable.
		/// If this function returns false, then |callback| will not be called. Otherwise,
		/// |callback| will be called asynchronously in the context of the render thread and,
		/// if RemoteCallbackInvokeMode is set to Invoke, on the thread that owns the 
		/// browser's underlying window handle.
		/// 
		/// Use with care:
		/// The callback may never be called if the render process gets killed prematurely.
		/// On success the CfrV8Value argument of the callback will be set to the return value
		/// of the evaluated script, if any. On failure the CfrV8Exception argument of the callback
		/// will be set to the exception thrown by the evaluated script, if any.
		/// Do not block the callback since it blocks the render thread.
		/// 
		/// *** WARNING ***
		/// In CEF 3.2623 and higher, the return value of the evaluation 
		/// seems to be broken in some cases (see also issue #65).
		/// 
		/// </summary>
		public bool EvaluateJavascript(string code, Action<CfrV8Value, CfrV8Exception> callback)
		{
			return EvaluateJavascript(code, JSInvokeMode.Inherit, callback);
		}

		/// <summary>
		/// Evaluate a string of javascript code in the browser's main frame.
		/// Evaluation is done asynchronously in the render process.
		/// Returns false if the remote browser is currently unavailable.
		/// If this function returns false, then |callback| will not be called. Otherwise,
		/// |callback| will be called asynchronously in the context of the render thread.
		/// 
		/// If |invokeMode| is set to Invoke, |callback| will be called on the thread that 
		/// owns the browser's underlying window handle. If |invokeMode| is set to Inherit,
		/// |callback| will be called according to RemoteCallbackInvokeMode.
		/// 
		/// Use with care:
		/// The callback may never be called if the render process gets killed prematurely.
		/// On success the CfrV8Value argument of the callback will be set to the return value
		/// of the evaluated script, if any. On failure the CfrV8Exception argument of the callback
		/// will be set to the exception thrown by the evaluated script, if any.
		/// Do not block the callback since it blocks the render thread.
		/// 
		/// *** WARNING ***
		/// In CEF 3.2623 and higher, the return value of the evaluation 
		/// seems to be broken in some cases (see also issue #65).
		/// 
		/// </summary>
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

			BrowserCore wb;
			string code;
			JSInvokeMode invokeMode;
			Action<CfrV8Value, CfrV8Exception> callback;

			internal EvaluateTask(BrowserCore wb, string code, JSInvokeMode invokeMode, Action<CfrV8Value, CfrV8Exception> callback)
			{
				this.wb = wb;
				this.code = code;
				this.invokeMode = invokeMode;
				this.callback = callback;
				Execute += (s, e) =>
				{
					if (invokeMode == JSInvokeMode.Invoke || (invokeMode == JSInvokeMode.Inherit && wb.RemoteCallbacksWillInvoke))
						wb.RenderThreadInvoke(() => Task_Execute(e));
					else
						Task_Execute(e);
				};
			}

			void Task_Execute(CfrEventArgs e)
			{
				CfrV8Value retval;
				CfrV8Exception ex;
				bool result = false;
				try
				{
					var context = wb.remoteBrowser.MainFrame.V8Context;
					result = context.Eval(code, null, 0, out retval, out ex);
				}
				catch
				{
					callback(null, null);
					return;
				}
				if (result)
				{
					callback(retval, null);
				}
				else
				{
					callback(null, ex);
				}
			}
		}

		/// <summary>
		/// Represents the main frame's global javascript object (window).
		/// Any changes to the global object's properties will be available 
		/// after the next time a V8 context is created in the render process
		/// for the main frame of this browser.
		/// </summary>
		public JSObject GlobalObject { get; private set; }

		/// <summary>
		/// Represents a named frame's global javascript object (window).
		/// Any changes to the global object's properties will be available 
		/// after the next time a V8 context is created in the render process
		/// of this browser for a frame with this name.
		/// </summary>
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


		/// <summary>
		/// Visit the DOM in the remote browser's main frame.
		/// Returns false if the remote browser is currently unavailable.
		/// If this function returns false, then |callback| will not be called. Otherwise,
		/// |callback| will be called according to the InvokeMode setting.
		/// 
		/// The document object passed to the callback represents a snapshot 
		/// of the DOM at the time the callback is executed.
		/// DOM objects are only valid for the scope of the callback. Do not
		/// keep references to or attempt to access any DOM objects outside the scope
		/// of the callback.
		/// Use with care:
		/// The callback may never be called if the render process gets killed prematurely.
		/// Do not keep a reference to the remote DOM or remote browser object after returning from the callback.
		/// Do not block the callback since it blocks the renderer thread.
		/// Explicitly Dispose() all CfrDomNode objects, otherwise the render process may become unstable and crash.
		/// </summary>
		/// <param name="callback"></param>
		/// <returns></returns>
		public bool VisitDom(Action<CfrDomDocument, CfrBrowser> callback)
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
					var task = new VisitDomTask(this, callback);
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

		private class VisitDomTask : CfrTask
		{

			BrowserCore wb;
			Action<CfrDomDocument, CfrBrowser> callback;
			CfrDomVisitor visitor;

			internal VisitDomTask(BrowserCore wb, Action<CfrDomDocument, CfrBrowser> callback)
			{
				this.wb = wb;
				this.callback = callback;
				this.Execute += Task_Execute;
				visitor = new CfrDomVisitor();
				visitor.Visit += (s, e) =>
				{
					if (wb.RemoteCallbacksWillInvoke)
						wb.RenderThreadInvoke((MethodInvoker)(() => { callback(e.Document, wb.remoteBrowser); }));
					else
						callback(e.Document, wb.remoteBrowser);
				};
			}

			void Task_Execute(object sender, CfrEventArgs e)
			{
				wb.remoteBrowser.MainFrame.VisitDom(visitor);
			}
		}

		// Callbacks from the associated render process handler

		/// <summary>
		/// Called immediately after the V8 context for a frame has been created. To
		/// retrieve the JavaScript 'window' object use the
		/// CfrV8Context.GetGlobal() function. V8 handles can only be accessed
		/// from the thread on which they are created. A task runner for posting tasks
		/// on the associated thread can be retrieved via the
		/// CfrV8Context.GetTaskRunner() function.
		/// 
		/// All javascript properties/functions defined through GlobalObject or GlobalObjectForFrame
		/// are made available before this event is executed.
		/// 
		/// If RemoteCallbackInvokeMode is set to Invoke, then this event is executed on the 
		/// thread that owns the browser's underlying window handle.
		/// </summary>
		/// <remarks>
		/// See also the original CEF documentation in
		/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
		/// </remarks>
		public event CfrOnContextCreatedEventHandler OnV8ContextCreated;

		internal void RaiseOnV8ContextCreated(CfrOnContextCreatedEventArgs e)
		{
			var eventHandler = OnV8ContextCreated;
			if (eventHandler == null) return;
			if (RemoteCallbacksWillInvoke)
				RenderThreadInvoke(() => eventHandler(this, e));
			else
				eventHandler(this, e);
		}


		/// <summary>
		/// Set a resource to be used for the specified URL.
		/// Note that these resources are kept in the memory.
		/// If you need to handle a lot of custom web resources,
		/// subscribing to RequestHandler.GetResourceHandler
		/// and loading from disk on demand
		/// might be a better choice.
		/// </summary>
		/// <param name="url"></param>
		/// <param name="resource"></param>
		public void SetWebResource(string url, WebResource resource)
		{
			webResources[url] = resource;
		}

		/// <summary>
		/// Remove a resource previously set for the specified URL.
		/// </summary>
		/// <param name="url"></param>
		public void RemoveWebResource(string url)
		{
			webResources.Remove(url);
		}

		/// <summary>
		/// Raised after the CfxBrowser object for this WebBrowser has been created.
		/// The event is executed on the thread that owns this browser control's 
		/// underlying window handle.
		/// </summary>
		public event BrowserCreatedEventHandler BrowserCreated;

		/// <summary>
		/// Called after a remote browser has been created. When browsing cross-origin a new
		/// browser will be created before the old browser is destroyed.
		/// 
		/// Applications may keep a reference to the CfrBrowser object outside the scope 
		/// of this event, but you have to be aware that those objects become invalid as soon
		/// as the framework swaps render processes and/or recreates browsers.
		/// </summary>
		public event RemoteBrowserCreatedEventHandler RemoteBrowserCreated;

		private void InvokeCallback(MethodInvoker method)
		{

			if (parentControl == null || !parentControl.InvokeRequired)
			{
				method.Invoke();
				return;
			}

			// Use BeginInvoke and Wait instead of Invoke.
			// Invoke marshals exceptions back to the calling thread.
			// We want exceptions to be thrown in place.

			var waitLock = new object();
			lock (waitLock)
			{
				parentControl.BeginInvoke((MethodInvoker)(() =>
				{
					try
					{
						method.Invoke();
					}
					finally
					{
						lock (waitLock)
						{
							Monitor.PulseAll(waitLock);
						}
					}
				}));
				Monitor.Wait(waitLock);
			}
		}



		/// <summary>
		/// INITIALIZE BROWSER.
		/// </summary>
		/// <param name="e"></param>
		internal void OnBrowserCreated(CfxOnAfterCreatedEventArgs e)
		{

			Browser = e.Browser;
			BrowserHost = Browser.Host;
			browserWindowHandle = BrowserHost.WindowHandle;
			AddToBrowserCache(this);

			var handler = BrowserCreated;
			if (handler != null)
			{
				var e1 = new BrowserCreatedEventArgs(e.Browser);
				handler(this, e1);
			}

			RegisterControlEvents();
			AssignBrowserMessageHandler();
			InitializeNanUI();

			ThreadPool.QueueUserWorkItem(AfterSetBrowserTasks);

			ResizeBrowserWindow();
		}




		private void AfterSetBrowserTasks(object state)
		{
			lock (browserSyncRoot)
			{
				if (m_loadUrlDeferred != null)
				{
					if (m_loadStringDeferred != null)
					{
						Browser.MainFrame.LoadString(m_loadStringDeferred, m_loadUrlDeferred);
					}
					else
					{
						Browser.MainFrame.LoadUrl(m_loadUrlDeferred);
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
				if (RemoteCallbacksWillInvoke && (parentControl != null && parentControl.InvokeRequired))
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

		void RegisterControlEvents()
		{
			parentControl.VisibleChanged += (sender, args) =>
			{
				var visible = ((Control)sender).Visible;
				ResizeBrowserWindow();
				if (visible)
				{
					parentControl.Refresh();
				}


			};

			parentControl.GotFocus += (sender, args) =>
			{
				if (BrowserHost != null) BrowserHost.SetFocus(true);

			};
		}

		protected void ResizeBrowserWindow()
		{

			if (parentControl.Visible)
			{
				if (browserWindowHandle != IntPtr.Zero && parentControl.Height > 0 && parentControl.Width > 0)
				{
					User32.SetWindowLong(browserWindowHandle, GetWindowLongFlags.GWL_STYLE, (int)(WindowStyle.WS_CHILD | WindowStyle.WS_CLIPCHILDREN | WindowStyle.WS_CLIPSIBLINGS | WindowStyle.WS_TABSTOP | WindowStyle.WS_VISIBLE));
					var rect = new RECT();
					User32.GetClientRect(parentWindowHandle, ref rect);
					User32.SetWindowPos(browserWindowHandle, IntPtr.Zero, 0, 0, rect.Width, rect.Height, /*SetWindowPosFlags.SWP_NOMOVE | */SetWindowPosFlags.SWP_NOZORDER);
				}
			}
			else
			{
				if (browserWindowHandle != IntPtr.Zero)
				{
					User32.SetWindowLong(browserWindowHandle, GetWindowLongFlags.GWL_STYLE, (int)(WindowStyle.WS_CHILD | WindowStyle.WS_CLIPCHILDREN | WindowStyle.WS_CLIPSIBLINGS | WindowStyle.WS_TABSTOP | WindowStyle.WS_DISABLED));
					User32.SetWindowPos(browserWindowHandle, IntPtr.Zero, 0, 0, 0, 0, SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOZORDER);
				}
			}
		}


		internal void SetToTop()
		{
			User32.SetWindowPos(browserWindowHandle, new IntPtr(-1), 0, 0, 0, 0, SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOSIZE);
		}

		#region Dispose

		private bool isDisposed;

		/// <summary>
		/// IsDisposed status
		/// </summary>
		public bool IsDisposed
		{
			get { return isDisposed; }
		}

		/// <summary>
		/// Standard Dispose
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Dispose
		/// </summary>
		/// <param name="disposing">True if disposing, false otherwise</param>
		protected virtual void Dispose(bool disposing)
		{
			if (!isDisposed)
			{
				if (disposing)
				{
					//release unmanaged resources

					ReleaseHandle();
					DestroyHandle();

					messageInterceptor?.ReleaseHandle();
					messageInterceptor?.DestroyHandle();
					messageInterceptor = null;

				}

				isDisposed = true;



				parentControl = null;
			}
		}

		#endregion



		#region Browser Message Interceptor

		public delegate bool BrowserForwardAction(ref Message message);
		internal static class BrowserWidgetHandleFinder
		{
			private delegate bool EnumWindowProc(IntPtr hwnd, IntPtr lParam);

			[DllImport("user32")]
			[return: MarshalAs(UnmanagedType.Bool)]
			private static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr lParam);

			[DllImport("user32.dll", CharSet = CharSet.Auto)]
			private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

			private class ClassDetails
			{
				public IntPtr DescendantFound { get; set; }
			}

			private static bool EnumWindow(IntPtr hWnd, IntPtr lParam)
			{
				const string chromeWidgetHostClassName = "Chrome_RenderWidgetHostHWND";

				var buffer = new StringBuilder(128);
				GetClassName(hWnd, buffer, buffer.Capacity);

				if (buffer.ToString() == chromeWidgetHostClassName)
				{
					var gcHandle = GCHandle.FromIntPtr(lParam);

					var classDetails = (ClassDetails)gcHandle.Target;

					classDetails.DescendantFound = hWnd;
					return false;
				}

				return true;
			}

			internal static bool TryFindHandle(IntPtr browserHandle, out IntPtr chromeWidgetHostHandle)
			{
				var classDetails = new ClassDetails();
				var gcHandle = GCHandle.Alloc(classDetails);

				var childProc = new EnumWindowProc(EnumWindow);
				EnumChildWindows(browserHandle, childProc, GCHandle.ToIntPtr(gcHandle));

				chromeWidgetHostHandle = classDetails.DescendantFound;

				gcHandle.Free();

				return classDetails.DescendantFound != IntPtr.Zero;
			}
		}

		internal class BrowserWidgetMessageInterceptor : NativeWindow
		{
			private BrowserForwardAction forwardAction;
			private readonly IntPtr parentHandle;

			internal BrowserWidgetMessageInterceptor(Control parentControl, IntPtr parentHandle, IntPtr chromeHostHandle, BrowserForwardAction forwardAction)
			{
				this.parentHandle = parentHandle;
				AssignHandle(chromeHostHandle);
				parentControl.HandleDestroyed += BrowserHandleDestroyed;
				this.forwardAction = forwardAction;
			}

			private void BrowserHandleDestroyed(object sender, EventArgs e)
			{
				ReleaseHandle();
				var browser = (Control)sender;
				browser.HandleDestroyed -= BrowserHandleDestroyed;
				forwardAction = null;
			}

			protected override void WndProc(ref Message m)
			{
				if (forwardAction == null)
				{
					return;
				}


				try
				{

					if(m.Msg == (int)WindowsMessages.WM_ACTIVATE)
					{
						User32.PostMessage(parentHandle, (uint)WindowsMessages.WM_ACTIVATE, m.WParam, m.LParam);
					}

					var result = forwardAction(ref m);

					if (!result)
					{
						base.WndProc(ref m);
					}
				}
				catch (Exception ex)
				{

					Console.WriteLine(ex);
					base.WndProc(ref m);

				}
			}
		}

		internal protected virtual void AssignBrowserMessageHandler()
		{
			Task.Factory.StartNew(() =>
			{
				try
				{
					while (true)
					{
						if (BrowserWidgetHandleFinder.TryFindHandle(BrowserHandle, out IntPtr chromeWidgetHostHandle))
						{
							messageInterceptor = new BrowserWidgetMessageInterceptor(parentControl, parentWindowHandle, chromeWidgetHostHandle, BrowserMessage);
							break;
						}
						else
						{
							Thread.Sleep(100);
						}
					}
				}
				catch (Exception ex)
				{

				}
			});
		}

		protected virtual bool BrowserMessage(ref Message message)
		{
			var args = new BrowserMessageEventArgs(ref message);
			args.Handled = false;
			OnBrowserMessage?.Invoke(this, args);
			return args.Handled;
		}

		#endregion

		private void SetHostStateChange(int currentState, RECT rect)
		{
			if (jsWindowState != currentState)
			{
				var stateString = currentState == 0 ? "normal" : currentState == 2 ? "maximized" : "minimized";

				var js = $"raiseCustomEvent('hoststatechange', " +
				$"{{" +
				$"state: {currentState}," +
				$"stateName: \"{stateString}\"," +
				$"width: {rect.Width}," +
				$"height: {rect.Height}" +
				$"}})";

				Browser.MainFrame.ExecuteJavaScript(js, null, 0);
				jsWindowState = currentState;

				nanuiJSObject.HostWindow.CurrentWindowState = currentState;
			}

		}

		private void SetHostActiveState(int currentState)
		{
			var stateText = currentState == 1 ? "activated" : "deactivated";

			var js = $"raiseCustomEvent('hostactivestate', {{state:{currentState}, stateName:'{currentState}'}})";

			System.Diagnostics.Debug.WriteLine($"Current State: 0x{Handle.ToString("X")} {currentState}");

			Browser.MainFrame?.ExecuteJavaScript(js, null, 0);
		}

		int jsWindowState = 0;
		protected override void WndProc(ref Message m)
		{
			switch ((WindowsMessages)m.Msg)
			{
				case WindowsMessages.WM_SIZING:
					{
						var rect = new RECT();
						User32.GetClientRect(parentWindowHandle, ref rect);

						User32.SetWindowPos(browserWindowHandle, IntPtr.Zero, rect.left, rect.top, rect.right, rect.bottom, SetWindowPosFlags.SWP_NOZORDER | SetWindowPosFlags.SWP_NOMOVE);

						base.WndProc(ref m);
					}

					break;
				case WindowsMessages.WM_SIZE:
					{
						var rect = new RECT();
						User32.GetClientRect(parentWindowHandle, ref rect);
						User32.SetWindowPos(browserWindowHandle, IntPtr.Zero, rect.left, rect.top, rect.right, rect.bottom, SetWindowPosFlags.SWP_NOZORDER | SetWindowPosFlags.SWP_NOMOVE);

						if (Browser != null)
						{
							if (parentControl is Form)
							{
								var currentState = (int)m.WParam;
								SetHostStateChange(currentState, rect);
							}


							{
								var js = $"raiseCustomEvent('hostsizechange', " +
									$"{{" +
									$"width: {rect.Width}," +
									$"height: {rect.Height}" +
									$"}})";

								Browser.MainFrame.ExecuteJavaScript(js, null, 0);
							}


						}


						Browser?.Host?.NotifyMoveOrResizeStarted();

						base.WndProc(ref m);
					}
					break;
				case WindowsMessages.WM_ACTIVATE:
					if (Browser != null)
					{
						var currentState = ((int)m.WParam) > 0 ? 1 : 0;


						SetHostActiveState(currentState);
					}


					base.WndProc(ref m);

					break;
				case WindowsMessages.WM_MOVE:
					Browser?.Host?.NotifyMoveOrResizeStarted();
					break;
				default:
					base.WndProc(ref m);
					break;
			}

		}


		public event EventHandler<BrowserMessageEventArgs> OnBrowserMessage;


		public virtual void ShowDevTools(IntPtr? parentHwnd = null)
		{
			var windowInfo = new CfxWindowInfo();

			windowInfo.Style = WindowStyle.WS_OVERLAPPEDWINDOW | WindowStyle.WS_CLIPCHILDREN | WindowStyle.WS_CLIPSIBLINGS | WindowStyle.WS_VISIBLE & ~WindowStyle.WS_CAPTION;
			windowInfo.ParentWindow = parentHwnd.HasValue ? parentHwnd.Value : IntPtr.Zero;
			windowInfo.WindowName = "Dev Tools";
			windowInfo.X = 200;
			windowInfo.Y = 200;
			windowInfo.Width = 720;
			windowInfo.Height = 480;
			BrowserHost.ShowDevTools(windowInfo, new CfxClient(), new CfxBrowserSettings(), null);

		}


		public Region DraggableRegion
		{
			get
			{
				return draggableRegion;
			}
		}
		private ToolTip toolTip;
		private void InitializeNanUI()
		{
			toolTip = new ToolTip();

			DragHandler.OnDraggableRegionsChanged += (that, args) =>
			{
				var regions = args.Regions;

				if (regions.Length > 0)
				{
					foreach (var region in regions)
					{
						var rect = new Rectangle((int)(region.Bounds.X * scaleFactor), (int)(region.Bounds.Y * scaleFactor), (int)(region.Bounds.Width * scaleFactor), (int)(region.Bounds.Height * scaleFactor));
						if (draggableRegion == null)
						{
							draggableRegion = new Region(rect);
						}
						else
						{
							if (region.Draggable)
							{
								draggableRegion.Union(rect);
							}
							else
							{
								draggableRegion.Exclude(rect);
							}
						}
					}
				}
			};

			OnV8ContextCreated += (that, args) =>
			{

				if (args.Frame.IsMain)
				{
					args.Frame.ExecuteJavaScript(NetDimension.NanUI.Properties.Resources.nanui_frameGlobal, null, 0);
				}
			};


			DisplayHandler.OnTooltip += (that, args) =>
			{
				args.SetReturnValue(false);
			};

		}


	}



}
