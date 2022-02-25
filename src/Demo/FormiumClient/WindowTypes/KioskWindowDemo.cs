using NetDimension.NanUI;
using NetDimension.NanUI.HostWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormiumClient;

internal class KioskWindowDemo : Formium
{


    public override HostWindowType WindowType { get; } = HostWindowType.Kiosk;
    public override string StartUrl { get; } = "http://resources.app.local/window-styles/kiosk-window";

    public KioskWindowDemo()
    {
        Title = "NanUI Window Types";
        Subtitle = "Kiosk Example";

    }

    protected override void OnReady()
    {
    }
}
