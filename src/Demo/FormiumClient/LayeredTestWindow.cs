using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NetDimension.NanUI;
using NetDimension.NanUI.HostWindow;

namespace FormiumClient;
internal class LayeredTestWindow : Formium
{
    public override HostWindowType WindowType { get; } = HostWindowType.Layered;
    public override string StartUrl { get; } = "https://cn.bing.com/account/general";

    public LayeredTestWindow()
    {
        StartPosition= FormStartPosition.CenterScreen;
        Size = new Size(1280, 720);

    }


    protected override void OnReady()
    {
    }
}
