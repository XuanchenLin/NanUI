using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xilium.CefGlue;

public static class Extensions
{
    public static DateTime ToDateTime(this CefBaseTime cefBaseTime)
    {

        //cefBaseTime.UtcExplode(out var exploded);



        return new DateTime(1601, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(cefBaseTime.Ticks / 1000).ToLocalTime();
    }
}
