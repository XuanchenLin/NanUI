using NetDimension.NanUI;
using NetDimension.NanUI.HostWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormiumClient;

internal class BorderlessWindowDemo : Formium
{


    public override HostWindowType WindowType { get; } = HostWindowType.Borderless;
    public override string StartUrl { get; } = "http://resources.app.local/window-styles/borderless-window";

    public BorderlessWindowDemo()
    {
        Size = new System.Drawing.Size(800, 480);
        MinimumSize = new System.Drawing.Size(720, 360);
        Title = "NanUI Window Types";
        Subtitle = "Borderless Window Example";

        var extendedStyle = UseExtendedStyles<BorderlessWindowStyle>();
        extendedStyle.ShadowEffect = ShadowEffect.Normal;
        extendedStyle.CornerStyle = CornerStyle.None;

        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

        EnableSplashScreen = false;
    }

    protected override void OnReady()
    {

    }
}
