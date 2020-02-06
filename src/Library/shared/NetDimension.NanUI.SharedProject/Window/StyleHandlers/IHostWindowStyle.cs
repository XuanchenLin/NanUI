using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NetDimension.NanUI
{
    public interface IHostWindowStyle
    {
        Icon Icon { get; set; }
        FormBorderStyle FormBorderStyle { get; set; }
        bool ShowInTaskbar { get; set; }
        bool ShowIcon { get; set; }
        Point Location { get; set; }
        Size Size { get; set; }
        Size MaximumSize { get; set; }
        Size MinimumSize { get; set; }
        FormStartPosition StartPosition { get; set; }
        FormWindowState WindowState { get; set; }
        bool TopMost { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        int Left { get; set; }
        int Top { get; set; }

    }
}
