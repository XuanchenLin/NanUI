// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
public sealed class ChromiumEnvironment
{
    public PlatformArchitecture Architecture
    {
        get;
    }

    public string LibCefPath { get; }
    public string ResourceFilePath { get; }
    public string LocaleFilePath { get; }
    public AppBuilder Builder { get; }

    //public string? SubprocessFilePath { get; private set; }

    public string? UserDataPath { get; internal set; } = null;

    public bool DisableHiDpiSupport { get; internal set; } = false;
    public bool UseInMemoryUserData { get; internal set; } = false;


    internal Action<CefCommandLine>? ConfigureCommandLine { get; set; }
    internal Action<CefSettings>? ConfigureSettings { get; set; }
    internal Action<CefBrowserSettings>? ConfigureBrowserSettings { get; set; }

    internal Action<SubprocessOptions>? ConfigureSubprocess;

    internal Action<CefSchemeRegistrar>? ConfigureCustomSchemes;

    internal CefBrowserSettings GetDefaultBrowserSettings()
    {
        var culture = Builder.Properties.GetValue<string>(nameof(AppBuilder.UseCulture)) ?? Application.CurrentCulture.Name;

        return new CefBrowserSettings
        {
            BackgroundColor = new CefColor(0xff, 0xff, 0xff, 0xff),
            WindowlessFrameRate = 60,
            DefaultEncoding = "UTF-8",
            AcceptLanguageList = culture,
        };
    }


    internal ChromiumEnvironment(string libCefDir, string resFileDir,string localeFileDir, AppBuilder builder)
    {

        LibCefPath = libCefDir;
        ResourceFilePath = resFileDir;
        LocaleFilePath = localeFileDir;
        Builder = builder;
        Architecture = Builder.Architecture;


    }
}
