using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser;

public sealed class WinFormiumApp : CefApp
{

    internal static string ON_CONTEXT_CREATED = MessagePipe.FormiumMessageBridge.MESSAGE_PREFIX + "OnContextCreated";

    private readonly CefRenderProcessHandler _renderProcessHandler;

    private readonly CefBrowserProcessHandler _browserProcessHandler;

    public WinFormiumApp()
    {
        _renderProcessHandler = new RenderProcessHandler();
        _browserProcessHandler = new BrowserProcessHandler();
    }


    protected override CefRenderProcessHandler GetRenderProcessHandler()
    {
        return _renderProcessHandler;
    }

    protected override CefBrowserProcessHandler GetBrowserProcessHandler()
    {
        return _browserProcessHandler;
    }

    //protected override void OnRegisterCustomSchemes(CefSchemeRegistrar registrar)
    //{
    //    var customSchemeConfigs = WinFormium.Runtime?.CustomResourceHandlerConfigurations;

    //    if (customSchemeConfigs != null)
    //    {
    //        foreach (var schemeName in customSchemeConfigs.Where(x => !x.IsStandardScheme).Select(x => x.Scheme.ToLower()).Distinct())
    //        {
    //            var opts = CefSchemeOptions.Standard | CefSchemeOptions.CorsEnabled;

    //            registrar.AddCustomScheme(schemeName, opts);
    //        }
    //    }
    //}

    protected override void OnBeforeCommandLineProcessing(string processType, CefCommandLine commandLine)
    {
        commandLine.AppendSwitch("default-encoding", "utf-8");
        commandLine.AppendSwitch("enable-media-stream");
        commandLine.AppendSwitch("autoplay-policy", "no-user-gesture-required");
        commandLine.AppendSwitch("renderer-process-limit", "1");


        WinFormium.Runtime.ChromiumEnvironment.CommandLineConfigurations?.Invoke(commandLine);
    }
}
