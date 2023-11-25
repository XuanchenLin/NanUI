// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;

public interface IWinFormiumStartup
{
    void WinFormiumMain(string[] args);

    MainWindowCreationAction? UseMainWindow(MainWindowOptions opts);

    void ConfigureChromiumEmbeddedFramework(ChromiumEnvironmentBuiler builder);

    void ConfigureServices(IServiceCollection services);
}


