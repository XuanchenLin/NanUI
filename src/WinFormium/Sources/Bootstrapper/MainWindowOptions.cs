// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;

public sealed class MainWindowOptions
{
    internal ApplicationContext Context { get; }
    private IServiceCollection Services { get; }

    internal MainWindowOptions(ApplicationContext context, IServiceCollection services)
    {
        Context = context;
        Services = services;
    }

    public MainWindowCreationAction UseMainForm(Form form)
    {
        Services.AddSingleton(form);

        return new MainWindowCreationAction(services =>
        {
            Context.MainForm = form;
        });
    }

    public MainWindowCreationAction UseMainForm<T>() where T: Form
    {
        Services.AddSingleton<T>();

        return new MainWindowCreationAction(services =>
        {
            var form = services.GetRequiredService<T>();

            Context.MainForm = form;
        });
    }

    public MainWindowCreationAction UseMainFormium(Formium formium)
    {
        Services.AddSingleton(formium);


        return new MainWindowCreationAction(services =>
        {
            Context.MainForm = formium.HostWindow;
        });
    }

    public MainWindowCreationAction UseMainFormium<T>() where T: Formium
    {

        Services.AddSingleton<T>();

        return new MainWindowCreationAction(services =>
        {
            var formium = services.GetRequiredService<T>();

            Context.MainForm = formium.HostWindow;

        });
    }

    public MainWindowCreationAction UseWithoutMainForm()
    {
        return new MainWindowCreationAction(services =>
        {
            Context.MainForm = null;
        });
    }
}
