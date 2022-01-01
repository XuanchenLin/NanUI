using NetDimension.NanUI;
using NetDimension.NanUI.HostWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormiumClient;

internal class LayeredWindowDemo : Formium
{
    public override HostWindowType WindowType { get; } = HostWindowType.Layered;
    public override string StartUrl { get; } = "http://resources.app.local/window-styles/layered-window";

    public LayeredWindowDemo()
    {
        Size = new System.Drawing.Size(520, 400);
        AllowSystemMenu = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        ShowInTaskBar = false;
        Title = "NanUI Window Types";
        Subtitle = "Layered Window Example";
    }

    protected override void OnReady()
    {


    }
}
