using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NetDimension.NanUI
{
    public interface IBorderlessHostWindowStyle : IHostWindowStyle
    {
        Color ShadowColor { get; set; }
        Color BorderColor { get; set; }
        Padding Borders { get; set; }
    }
}
