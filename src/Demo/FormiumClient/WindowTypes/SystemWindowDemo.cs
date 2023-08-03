using NetDimension.NanUI;
using NetDimension.NanUI.HostWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormiumClient;

internal class SystemWindowDemo : Formium
{


    public override HostWindowType WindowType { get; } = HostWindowType.System;
    public override string StartUrl { get; } = "http://resources.app.local/window-styles/system-window/";

    public SystemWindowDemo()
    {
        Size = new System.Drawing.Size(800, 480);
        MinimumSize = new System.Drawing.Size(720, 360);
        Title = "NanUI Window Types";
        Subtitle = "System Window Example";

        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
    }

    protected override void OnReady()
    {

    }
}
