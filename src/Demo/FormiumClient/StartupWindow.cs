using NetDimension.NanUI;
using NetDimension.NanUI.HostWindow;
using NetDimension.NanUI.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormiumClient;

internal class StartupWindow : Formium
{


    public override HostWindowType WindowType { get; } = HostWindowType.SystemBorderless;
    public override string StartUrl { get; } = "http://resources.app.local/startup-ui/";

    public StartupWindow()
    {
        Size = new System.Drawing.Size(680, 440);
        MinimumSize = new System.Drawing.Size(640, 400);
        StartPosition = FormStartPosition.CenterScreen;
        Sizable = true;
        Maximizable = false;
        AllowFullScreen = false;
        EnableSplashScreen = false;
        AllowSystemMenu = false;
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

        RegisterJavaScriptObject("launcher",jsObject);
    }
}
