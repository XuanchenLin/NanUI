// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
internal class BrowserProcessHandler : CefBrowserProcessHandler
{
    private BrowserApp app;
    private WindowBindingObjectServiceServer? WindowBindingObjectServer { get; set; }

    public BrowserProcessHandler(BrowserApp browserApp)
    {
        app = browserApp;

    }

    protected override void OnRegisterCustomPreferences(CefPreferencesType type, CefPreferenceRegistrar registrar)
    {
        base.OnRegisterCustomPreferences(type, registrar);
    }

    protected override void OnBeforeChildProcessLaunch(CefCommandLine commandLine)
    {

        commandLine.AppendSwitch("host-process-id", System.Diagnostics.Process.GetCurrentProcess().Id.ToString());



        System.Diagnostics.Debug.WriteLine("[SUBPROCESS] commandline arguments:");
        System.Diagnostics.Debug.WriteLine(commandLine.ToString());
    }

    protected override void OnContextInitialized()
    {
        WindowBindingObjectServer = new WindowBindingObjectServiceServer(app.GetExtensionPipeName());
    }

    protected override void Dispose(bool disposing)
    {
        WindowBindingObjectServer?.Dispose();
        base.Dispose(disposing);
    }


}

