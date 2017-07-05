using Chromium;
using Chromium.Event;
using Chromium.Remote;
using Chromium.Remote.Event;
using NetDimension.NanUI.ChromiumCore;
using NetDimension.NanUI.Resource;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NetDimension.NanUI
{
	public interface IChromiumWebBrowser
	{
		/// <summary>
		/// Indicates whether render process callbacks on this browser
		/// will be executed on the thread that owns the 
		/// browser's underlying window handle.
		/// Depends on the invoke mode. If the invoke mode is set to
		/// "Inherit", then "Invoke" will be assumed.
		/// </summary>
		bool RemoteCallbacksWillInvoke
		{
			get;
		}

		CfrBrowser RemoteBrowser { get; }
		RenderProcess RemoteProcess { get; }

		Dictionary<string, WebResource> WebResources { get; }

		Dictionary<string, JSObject> FrameGlobalObjects { get; }

		JSObject GlobalObject { get; }

		/// <summary>
		/// Special Invoke for framework callbacks from the render process.
		/// Maintains the thread in the context of the calling remote thread.
		/// Use this instead of invoke when the following conditions are meat:
		/// 1) The current thread is executing in the scope of a framework
		///    callback event from the render process (ex. CfrTask.Execute).
		/// 2) You need to Invoke on the webbrowser control and
		/// 3) The invoked code needs to call into the render process.
		/// </summary>
		object RenderThreadInvoke(Delegate method, params Object[] args);
		/// <summary>
		/// Special Invoke for framework callbacks from the render process.
		/// Maintains the thread within the context of the calling remote thread.
		/// Use this instead of invoke when the following conditions are meat:
		/// 1) The current thread is executing in the scope of a framework
		///    callback event from the render process (ex. CfrTask.Execute).
		/// 2) You need to Invoke on the webbrowser control and
		/// 3) The invoked code needs to call into the render process.
		/// </summary>
		void RenderThreadInvoke(MethodInvoker method);

		/// <summary>
		/// Creates the underlying CfxBrowser with the given CfxRequestContext.
		/// This method should only be called if this ChromiumWebBrowser
		/// was instanciated with createImmediately == false.
		/// </summary>
		void CreateBrowser(CfxRequestContext requestContext);

		void SetRemoteBrowser(CfrBrowser remoteBrowser, RenderProcess remoteProcess);

		void RemoteProcessExited(RenderProcess process);
		/// <summary>
		/// Returns the context menu handler for this browser. If this is never accessed the default
		/// implementation will be used.
		/// </summary>
		CfxContextMenuHandler ContextMenuHandler { get; }

		/// <summary>
		/// Returns the life span handler for this browser.
		/// </summary>
		CfxLifeSpanHandler LifeSpanHandler { get; }

		/// <summary>
		/// Returns the load handler for this browser.
		/// </summary>
		CfxLoadHandler LoadHandler { get; }

		/// <summary>
		/// Returns the request handler for this browser.
		/// Do not set the return value in the GetResourceHandler event for URLs
		/// with associated WebResources (see also SetWebResource).
		/// </summary>
		CfxRequestHandler RequestHandler { get; }

		/// <summary>
		/// Returns the display handler for this browser.
		/// </summary>
		CfxDisplayHandler DisplayHandler { get; }

		/// <summary>
		/// Returns the download handler for this browser. If this is never accessed
		/// downloads will not be allowed.
		/// </summary>
		CfxDownloadHandler DownloadHandler { get; }

		/// <summary>
		/// Returns the drag handler for this browser.
		/// </summary>
		CfxDragHandler DragHandler { get; }

		/// <summary>
		/// Returns the dialog handler for this browser. If this is never accessed the default
		/// implementation will be used.
		/// </summary>
		CfxDialogHandler DialogHandler { get; }

		/// <summary>
		/// Returns the find handler for this browser.
		/// </summary>
		CfxFindHandler FindHandler { get; }

		/// <summary>
		/// Returns the focus handler for this browser.
		/// </summary>
		CfxFocusHandler FocusHandler { get; }

		/// <summary>
		/// Returns the geolocation handler for this browser. If this is never accessed
		/// geolocation access will be denied by default.
		/// </summary>
		CfxGeolocationHandler GeolocationHandler { get; }

		/// <summary>
		/// Returns the js dialog handler for this browser. If this is never accessed the default
		/// implementation will be used.
		/// </summary>
		CfxJsDialogHandler JsDialogHandler { get; }

		/// <summary>
		/// Returns the keyboard handler for this browser.
		/// </summary>
		CfxKeyboardHandler KeyboardHandler { get; }

		/// <summary>
		/// Returns the URL currently loaded in the main frame.
		/// </summary>
		System.Uri Url
		{
			get;
		}

		/// <summary>
		/// Returns true if the browser is currently loading.
		/// </summary>
		bool IsLoading { get; }

		/// <summary>
		/// Returns true if the browser can navigate backwards.
		/// </summary>
		bool CanGoBack { get; }

		/// <summary>
		/// Returns true if the browser can navigate forwards.
		/// </summary>
		bool CanGoForward { get; }

		/// <summary>
		/// Navigate backwards.
		/// </summary>
		void GoBack();

		/// <summary>
		/// Navigate forwards.
		/// </summary>
		void GoForward();
		/// <summary>
		/// Load the specified |url| into the main frame.
		/// </summary>
		void LoadUrl(string url);

		/// <summary>
		/// Load the contents of |stringVal| with the specified dummy |url|. |url|
		/// should have a standard scheme (for example, http scheme) or behaviors like
		/// link clicks and web security restrictions may not behave as expected.
		/// </summary>
		void LoadString(string stringVal, string url);

		/// <summary>
		/// Load the contents of |stringVal| with dummy url about:blank.
		/// </summary>
		void LoadString(string stringVal);

		/// <summary>
		/// Search for |searchText|. |forward| indicates whether to search forward or
		/// backward within the page. |matchCase| indicates whether the search should
		/// be case-sensitive.
		/// Returns the identifier for this find operation (see also CfxFindHandler),
		/// or -1 if the browser has not yet been created.
		/// </summary>
		int Find(string searchText, bool forward, bool matchCase);


		void RaiseOnV8ContextCreated(CfrOnContextCreatedEventArgs e);
		/// <summary>
		/// Execute a string of javascript code in the browser's main frame.
		/// Execution is asynchronous, this function returns immediately.
		/// Returns false if the browser has not yet been created.
		/// </summary>
		bool ExecuteJavascript(string code);


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
		/// </summary>
		bool EvaluateJavascript(string code, JSInvokeMode invokeMode, Action<CfrV8Value, CfrV8Exception> callback);


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
		void SetWebResource(string url, WebResource resource);

		/// <summary>
		/// Remove a resource previously set for the specified URL.
		/// </summary>
		/// <param name="url"></param>
		void RemoveWebResource(string url);


		void OnBrowserCreated(CfxOnAfterCreatedEventArgs e);
	}
}
