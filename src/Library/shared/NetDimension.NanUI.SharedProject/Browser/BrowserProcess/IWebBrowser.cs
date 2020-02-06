using Chromium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI.Browser
{
    public interface IWebBrowser
    {
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
        /// Execute a string of javascript code in the browser's main frame.
        /// Execution is asynchronous, this function returns immediately.
        /// Returns false if the browser has not yet been created.
        /// </summary>
        //bool ExecuteJavascript(string code);
        /// <summary>
        /// Execute a string of javascript code in the browser's main frame. The |scriptUrl|
        /// parameter is the URL where the script in question can be found, if any. The
        /// renderer may request this URL to show the developer the source of the
        /// error.  The |startLine| parameter is the base line number to use for error
        /// reporting.
        /// Execution is asynchronous, this function returns immediately.
        /// Returns false if the browser has not yet been created.
        /// </summary>
        //bool ExecuteJavascript(string code, string scriptUrl, int startLine);
        //bool EvaluateJavascript(string code, Action<CfrV8Value, CfrV8Exception> callback);

    }
}
