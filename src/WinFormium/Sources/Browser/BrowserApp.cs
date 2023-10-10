// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;


internal class BrowserApp : CefApp
{
    private readonly CefRenderProcessHandler _renderProcessHandler;

    private readonly CefBrowserProcessHandler _browserProcessHandler;

    public string GetExtensionPipeName()
    {
        int processId;

        if (ApplicationContext.ProcessType == ProcessType.Main)
        {
            processId = System.Diagnostics.Process.GetCurrentProcess().Id;
        }
        else
        {
            processId = ApplicationContext.BrowserProcessId;
        }

        return $"WinFormium-ExtensionProxy-{processId}";
    }


    public BrowserApp(WinFormiumApp app)
    {
        ApplicationContext = app;

        _browserProcessHandler = new BrowserProcessHandler(this);
        _renderProcessHandler = new RenderProcessHandler(this);
    }

    public WinFormiumApp ApplicationContext { get; }

    public ChromiumEnvironment Environment => ApplicationContext.Services!.GetService<ChromiumEnvironment>()!;

    protected override void OnBeforeCommandLineProcessing(string processType, CefCommandLine commandLine)
    {

        //TODO:决定好把哪些参数设置为默认参数

        commandLine.AppendSwitch("enable-media-stream");
        commandLine.AppendSwitch("autoplay-policy", "no-user-gesture-required");
        //commandLine.AppendSwitch("renderer-process-limit", "1");
        //commandLine.AppendSwitch("in-process-gpu");
        commandLine.AppendSwitch("user-agent-product", $"Chromium/{CefRuntime.ChromeVersion} WinFormium/{Assembly.GetExecutingAssembly().GetName().Version}");


        Environment.ConfigureCommandLine?.Invoke(commandLine);
    }

    protected override CefBrowserProcessHandler GetBrowserProcessHandler()
    {
        return _browserProcessHandler;
    }

    protected override CefRenderProcessHandler GetRenderProcessHandler()
    {
        return _renderProcessHandler;
    }

    protected override void OnRegisterCustomSchemes(CefSchemeRegistrar registrar)
    {
        Environment.ConfigureCustomSchemes?.Invoke(registrar);

        registrar.AddCustomScheme("formium", CefSchemeOptions.Secure | CefSchemeOptions.Standard);
    }
}

internal record JavaScriptWindowBindingObjectDescriper(string FilePath, string TypeName);