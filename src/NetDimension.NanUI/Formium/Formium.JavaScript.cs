using NetDimension.NanUI.JavaScript;
using NetDimension.NanUI.JavaScript.JavaScriptEvaluation;
using NetDimension.NanUI.JavaScript.JavaScriptObjectMapping;
using Vanara.PInvoke;
using Xilium.CefGlue;

namespace NetDimension.NanUI;

partial class Formium
{
    private const string JS_EVENT_RAISER_NAME = "__formium_raiseHostWindowEvent";

    FormWindowState _windowLastState;
    private Dictionary<string, string> DelayedScripts { get; } = new Dictionary<string, string>();
    /// <summary>
    /// Execute JavaScript code in in main frame.
    /// </summary>
    /// <param name="code">The javascript code that will be executed.</param>
    public void ExecuteJavaScript(string code)
    {
        Browser?.GetMainFrame()?.ExecuteJavaScript(code, Browser.GetMainFrame().Url, 0);
    }

    /// <summary>
    /// Execute JavaScript code in the specified frame.
    /// </summary>
    /// <param name="frame">The specified frame</param>
    /// <param name="code">The javascript code that will be executed.</param>
    public void ExecuteJavaScript(CefFrame frame, string code)
    {
        frame?.ExecuteJavaScript(code, Browser.GetMainFrame().Url, 0);
    }

    /// <summary>
    /// Execute JavaScript code and wait for the execution result.
    /// </summary>
    /// <param name="code">The javascript code that will be executed.</param>
    /// <returns>JavaScriptExecutionResult</returns>
    public Task<JavaScriptExecutionResult> EvaluateJavaScriptAsync(string code)
    {
        return WebView.MessageBridge.GetInstance<EvaluateJavaScriptOnBrowserSide>().EvaluateJavaScriptAsync(GetMainFrame(), code);
    }

    /// <summary>
    /// Execute JavaScript code and wait for the execution result in the specified frame.
    /// </summary>
    /// <param name="frame">The specified frame</param>
    /// <param name="code">The javascript code that will be executed.</param>
    /// <returns>JavaScriptExecutionResult</returns>
    public Task<JavaScriptExecutionResult> EvaluateJavaScriptAsync(CefFrame frame, string code)
    {
        return WebView.MessageBridge.GetInstance<EvaluateJavaScriptOnBrowserSide>().EvaluateJavaScriptAsync(frame, code);
    }

    /// <summary>
    /// Register the specified object to the JavaScript environment.
    /// </summary>
    /// <param name="name">Object key</param>
    /// <param name="javaScriptObject">Target object</param>
    public void RegisterJavaScriptObject(string name, JavaScriptObject javaScriptObject)
    {
        WebView.MessageBridge.GetInstance<MapJavaScriptObjectOnBrowserSide>().RegisterJavaScriptObject(GetMainFrame(), name, javaScriptObject);
    }

    /// <summary>
    /// Register the specified object to the JavaScript environment.
    /// </summary>
    /// <param name="frame">The specified frame</param>
    /// <param name="name">Object key</param>
    /// <param name="javaScriptObject">Target object</param>
    public void RegisterJavaScriptObject(CefFrame frame, string name, JavaScriptObject javaScriptObject)
    {
        WebView.MessageBridge.GetInstance<MapJavaScriptObjectOnBrowserSide>().RegisterJavaScriptObject(frame, name, javaScriptObject);
    }




    private void RegisterHostWindowJavascriptEventHandler()
    {
        _windowLastState = FormHostWindow.WindowState;

        const string FORMIUM_ACTIVATED = "formium-activated";
        const string FORMIUM_DEACTIVATE = "formium-deactivate";

        

        FormHostWindow.Activated += (_, _) =>
        {
            var sb = new StringBuilder();

            sb.AppendLine($@"(function(){{

    const html =  document.querySelector(`html`);

    html && html.classList.remove(`{FORMIUM_DEACTIVATE}`);    
    html && html.classList.add(`{FORMIUM_ACTIVATED}`);

    if(typeof {JS_EVENT_RAISER_NAME} === 'undefined') return;

    {JS_EVENT_RAISER_NAME} && {JS_EVENT_RAISER_NAME}(""hostactivated"", {{}});
    {JS_EVENT_RAISER_NAME} && {JS_EVENT_RAISER_NAME}(""hostactivatestatechange"", {{ activated: true }});

}})();");


            if (!IsWebViewReady)
            {
                DelayedScripts["hostactivatestatechange"] = sb.ToString();
            }


            ExecuteJavaScript(sb.ToString());

        };

        FormHostWindow.Deactivate += (_, _) =>
        {
            var sb = new StringBuilder();

            sb.AppendLine($@"(function(){{

    const html =  document.querySelector(`html`);
    
    html && html.classList.remove(`{FORMIUM_ACTIVATED}`);
    html && html.classList.add(`{FORMIUM_DEACTIVATE}`);

    if(typeof {JS_EVENT_RAISER_NAME} === 'undefined') return;
    
{JS_EVENT_RAISER_NAME} && {JS_EVENT_RAISER_NAME}(""hostdeactivate"", {{}});
    {JS_EVENT_RAISER_NAME} && {JS_EVENT_RAISER_NAME}(""hostactivatestatechange"", {{ activated: false }});

}})();");


            if (!IsWebViewReady)
            {
                DelayedScripts["hostactivatestatechange"] = sb.ToString();
            }

            ExecuteJavaScript(sb.ToString());


        };

        FormHostWindow.Resize += (_, _) =>
        {
            var state = FormHostWindow.WindowState.ToString().ToLower();

            RECT rect;

            var isMaximized = User32.IsZoomed(HostWindowHandle);

            if (isMaximized)
            {
                User32.GetClientRect(HostWindowHandle, out rect);
            }
            else
            {
                User32.GetWindowRect(HostWindowHandle, out rect);
            }

            var sb = new StringBuilder();

            sb.AppendLine("(function(){");

            sb.AppendLine("const html =  document.querySelector(`html`);");

            if (_windowLastState != FormHostWindow.WindowState)
            {
                sb.AppendLine($"html && html.classList.remove(`formium-maximized`,`formium-minimized`);");

                


                sb.AppendLine($"if(typeof {JS_EVENT_RAISER_NAME} !== 'undefined') {JS_EVENT_RAISER_NAME}(`hoststatechanged`, {{ state: `{state}`}});");


                if (FormHostWindow.WindowState != FormWindowState.Normal)
                {
                    sb.AppendLine($"html && html.classList.add(`formium-{state}`);");
                }


                _windowLastState = FormHostWindow.WindowState;
            }

            sb.AppendLine($"if(typeof {JS_EVENT_RAISER_NAME} !== 'undefined') {JS_EVENT_RAISER_NAME}(`hostsizechanged`, {{ width:{rect.Width}, height:{rect.Height} }});");

            sb.AppendLine("})();");

            if (IsWebViewReady)
            {
                ExecuteJavaScript(sb.ToString());
            }
            else
            {
                DelayedScripts["hostsizechanged"] = sb.ToString();
            }

        };

        FormHostWindow.Move += (_, e) =>
        {
            User32.GetWindowRect(HostWindowHandle, out var rect);
            var sb = new StringBuilder();

            sb.AppendLine("(function(){");
            sb.AppendLine($"if(typeof {JS_EVENT_RAISER_NAME} !== 'undefined') {JS_EVENT_RAISER_NAME}(`hostpositionchanged`, {{ left:{rect.left}, top:{rect.top}, right:{rect.right }, bottom:{rect.bottom}, width:{rect.Width}, height:{rect.Height});");
            sb.AppendLine("})();");

        };
    }
}
