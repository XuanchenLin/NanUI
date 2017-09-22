using System;
using Chromium;
using Chromium.Remote;
using Chromium.WebBrowser;

namespace NetDimension.NanUI
{
	public interface IChromiumClient
	{
		CfxBrowser Browser { get; }
		CfxBrowserHost BrowserHost { get; }
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
		System.Uri Url { get; }


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

		/// <summary>
		/// Search for |searchText|. |forward| indicates whether to search forward or
		/// backward within the page. The search will be case-insensitive.
		/// Returns the identifier for this find operation (see also CfxFindHandler),
		/// or -1 if the browser has not yet been created.
		/// </summary>
		int Find(string searchText, bool forward);

		/// <summary>
		/// Search for |searchText|. The search will be forward and case-insensitive.
		/// Returns the identifier for this find operation (see also CfxFindHandler),
		/// or -1 if the browser has not yet been created.
		/// </summary>
		int Find(string searchText);
		/// <summary>
		/// Execute a string of javascript code in the browser's main frame.
		/// Execution is asynchronous, this function returns immediately.
		/// Returns false if the browser has not yet been created.
		/// </summary>
		bool ExecuteJavascript(string code);
		/// <summary>
		/// Execute a string of javascript code in the browser's main frame. The |scriptUrl|
		/// parameter is the URL where the script in question can be found, if any. The
		/// renderer may request this URL to show the developer the source of the
		/// error.  The |startLine| parameter is the base line number to use for error
		/// reporting.
		/// Execution is asynchronous, this function returns immediately.
		/// Returns false if the browser has not yet been created.
		/// </summary>
		bool ExecuteJavascript(string code, string scriptUrl, int startLine);
		bool EvaluateJavascript(string code, Action<CfrV8Value, CfrV8Exception> callback);
		bool EvaluateJavascript(string code, JSInvokeMode invokeMode, Action<CfrV8Value, CfrV8Exception> callback);
		JSObject GlobalObject { get; }
		JSObject GlobalObjectForFrame(string frameName);
	}
}