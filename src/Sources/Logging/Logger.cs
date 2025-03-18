// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.Logging;
public abstract class Logger
{
    private static Logger? instance;

    /// <summary>
    /// The <see cref="ILogger"/> instance.
    /// </summary>
    public static Logger Instance
    {
        get
        {
            if (instance is null)
            {
                // Ambient Context can't return null, so we assign Local Default
                instance = new DefaultLogger();
            }

            return instance;
        }
        set
        {
            instance = (value is null) ? new DefaultLogger() : value;
        }
    }
#nullable disable

    /// <summary>
    /// Gets or sets the application logger.
    /// </summary>
    public virtual ILogger Log { get; set; }
#nullable restore
}