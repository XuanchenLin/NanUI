// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.Logging;
internal class DefaultLogger : Logger
{
    private ILogger? _logger;

    /// <summary>
    /// Gets or sets logger.
    /// </summary>
    public override ILogger Log
    {
        get
        {
            if (_logger is null)
            {
                _logger = new NanUILogger();
            }

            return _logger;
        }
        set
        {
            _logger = value;
        }
    }
}
