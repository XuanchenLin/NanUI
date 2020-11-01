using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NetDimension.NanUI.HostWindow
{
    public enum HostWindowType
    {
        System,
        Borderless,
        Kiosk,
        Layered,
        Acrylic,
        Custom
    }

    public delegate bool OnWindowsMessageDelegate(ref Message message);


    public interface IFormiumHostWindow
    {
        void PostUIThread(Action action);

        OnWindowsMessageDelegate OnWindowsMessage { get; set; }

        OnWindowsMessageDelegate OnDefWindowsMessage { get; set; }

    }


}
