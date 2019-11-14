using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.WinForm
{
    public class DpiChangedEventArgs: EventArgs
    {
        public DpiChangedEventArgs(int dpiX, int dpiY, System.Drawing.Rectangle bounds)
        {
            Dpi = new System.Drawing.Size(dpiX, dpiY);
            Bounds = bounds;
        }

        public System.Drawing.Size Dpi
        {
            get;
        }

        public System.Drawing.Rectangle Bounds
        {
            get;
        }
    }
}
