using NetDimension.NanUI;

namespace FormiumClientSubprocess;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        WinFormium.CreateRuntimeBuilder(app => {
            app.RegisterJavaScriptWindowBinding(() => new FormiumClient.DemoWindowBinding());
        }).Build().RunAsSubprocess();
    }
}
