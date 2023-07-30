using FormiumClient.Resources;

using NetDimension.NanUI;
using NetDimension.NanUI.HostWindow;
using NetDimension.NanUI.JavaScript;

namespace FormiumClient;

internal class StartupWindow : Formium
{


    public override HostWindowType WindowType { get; } = HostWindowType.SystemBorderless;
    public override string StartUrl { get; } = "http://resources.app.local/startup-ui/";

    public StartupWindow()
    {
        Size = new Size(720, 440);
        MinimumSize = new Size(640, 400);
        StartPosition = FormStartPosition.CenterScreen;
        Sizable = true;
        Maximizable = true;
        AllowFullScreen = false;
        EnableSplashScreen = false;
        AllowSystemMenu = false;

        Title = Messages.StartupWindowTitle;

    }

    protected override void OnReady()
    {
        var jsObject = new JavaScriptObject();
        jsObject.Add("launchDemo", (args =>
        {
            InvokeIfRequired(() =>
            {
                DialogResult = DialogResult.OK;
                Close();
            });
            return null;
        }));

        RegisterJavaScriptObject("launcher", jsObject);

    }


}
