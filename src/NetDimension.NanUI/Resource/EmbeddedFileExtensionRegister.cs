
namespace NetDimension.NanUI;

public static class EmbeddedFileExtensionRegister
{
    public static ApplicationConfigurationBuilder UseEmbeddedFileResource(this ApplicationConfigurationBuilder @this, string scheme, string domainName, Assembly resourceAssembly, string resourceFileRootPath = null, Func<string, string> onFallback = null, string defaultNameSpace = null)
    {
        var ns = defaultNameSpace ?? (resourceAssembly.EntryPoint?.DeclaringType.Namespace ?? resourceAssembly.GetName().Name);


        @this.UseCustomResourceHandler(() => new Resource.EmbeddedFile.SchemeConfiguration(resourceAssembly, scheme, domainName, resourceFileRootPath, onFallback, ns));

        return @this;
    }

    public static ApplicationConfigurationBuilder UseEmbeddedFileResource(this ApplicationConfigurationBuilder @this, string scheme, string domainName, string resourceFileRootPath, Func<string, string> onFallback = null, string defaultNameSpace = null)
    {

        UseEmbeddedFileResource(@this, scheme, domainName, Assembly.GetEntryAssembly(), resourceFileRootPath, onFallback, defaultNameSpace);

        return @this;
    }

    public static ApplicationConfigurationBuilder UseEmbeddedFileResource(this ApplicationConfigurationBuilder @this, string scheme, string domainName, Func<string, string> onFallback = null, string defaultNameSpace = null)
    {

        UseEmbeddedFileResource(@this, scheme, domainName, Assembly.GetEntryAssembly(), null, onFallback, defaultNameSpace);
        return @this;
    }

    public static void UseEmbeddedFileResource(this RuntimeContext @this, string scheme, string domainName, Assembly resourceAssembly, string resourceFileRootPath = null, Func<string, string> onFallback = null, string defaultNameSpace = null)
    {
        @this.RegisterCustomResourceHandler(new Resource.EmbeddedFile.SchemeConfiguration(resourceAssembly, scheme, domainName, resourceFileRootPath, onFallback,defaultNameSpace));
    }

    public static void UseEmbeddedFileResource(this RuntimeContext @this, string scheme, string domainName, string resourceFileRootPath, Func<string, string> onFallback = null, string defaultNameSpace = null)
    {
        UseEmbeddedFileResource(@this, scheme, domainName, Assembly.GetExecutingAssembly(), resourceFileRootPath, onFallback,defaultNameSpace);
    }

    public static void UseEmbeddedFileResource(this RuntimeContext @this, string scheme, string domainName, Func<string, string> onFallback = null, string defaultNameSpace = null)
    {
        UseEmbeddedFileResource(@this, scheme, domainName, Assembly.GetExecutingAssembly(), null, onFallback,defaultNameSpace);
    }
}
