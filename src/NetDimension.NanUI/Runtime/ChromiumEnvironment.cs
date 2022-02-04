namespace NetDimension.NanUI;

using Xilium.CefGlue;

public class ChromiumEnvironment
{
    /// <summary>
    /// Gets the path of libcef.dll that found by NanUI automatically.
    /// </summary>
    public string LibCefDir { get; internal set; }
    /// <summary>
    /// Gets the resource files of CEF that found by NanUI automatically.
    /// </summary>
    public string LibCefResourceDir { get; internal set; }
    /// <summary>
    /// Gets the locale files of CEF that found by NanUI automatically.
    /// </summary>
    public string LibCefLocaleDir { get; internal set; }
    /// <summary>
    /// Gets the subprocess files of CEF that found by NanUI automatically.
    /// </summary>
    public string SubprocessPath { get; internal set; }
    /// <summary>
    /// Gets value that indicates if the CEF focre the HiDpi support disabled.
    /// </summary>
    public bool ForceHighDpiSupportDisabled { get; internal set; }

    internal Action<CefCommandLine> CommandLineConfigurations { get; set; }
    internal Action<CefSettings> SettingConfigurations { get; set; }
    internal Action<CefBrowserSettings> CefBrowserSettingConfigurations { get; set; }

}
