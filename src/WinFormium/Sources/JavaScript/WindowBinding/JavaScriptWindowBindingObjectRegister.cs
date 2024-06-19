// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;
public static class JavaScriptWindowBindingObjectRegister
{

    public static AppBuilder RegisterWindowBindingObject<T>(this AppBuilder appBuilder, Func<IServiceProvider, T> registerDelegate) where T : JavaScriptWindowBindingObject
    {

        appBuilder.Services.AddScoped<JavaScriptWindowBindingObject>(registerDelegate);

        return appBuilder;
    }

    public static AppBuilder RegisterWindowBindingObject<T>(this AppBuilder appBuilder) where T : JavaScriptWindowBindingObject
    {
        if(appBuilder.ProcessType == ProcessType.Main)
        {
            JavaScriptWindowBindingObjectBridge.WindowBindingObjectTypes.Add(typeof(T));
        }

        return appBuilder;
    }

    public static IServiceCollection AddWindowBindingObject<T>(this IServiceCollection services, Func<IServiceProvider, T> registerDelegate) where T : JavaScriptWindowBindingObject
    {
        services.AddScoped<JavaScriptWindowBindingObject>(registerDelegate);

        return services;
    }

    public static IServiceCollection AddWindowBindingObject<T>(this IServiceCollection services) where T : JavaScriptWindowBindingObject
    {
        JavaScriptWindowBindingObjectBridge.WindowBindingObjectTypes.Add(typeof(T));
        return services;
    }

}
