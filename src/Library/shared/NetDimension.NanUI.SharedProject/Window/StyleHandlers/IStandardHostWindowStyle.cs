using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.NanUI
{
    public interface IStandardHostWindowStyle : IHostWindowStyle
    {
        bool ControlBox { get; set; }
        bool MaximizeBox { get; set; }
        bool MinimizeBox { get; set; }
    }
}
