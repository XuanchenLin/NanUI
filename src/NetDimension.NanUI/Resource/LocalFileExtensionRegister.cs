
namespace NetDimension.NanUI;

public static class LocalFileExtensionRegister
{
    public static ApplicationConfigurationBuilder UseLocalFileResource(this ApplicationConfigurationBuilder @this, string scheme, string domainName, string localFileResourceDirectory, Func<string, string> onFallback = null)
    {
        @this.UseCustomResourceHandler(() => new Resource.LocalFile.SchemeConfiguration(scheme, domainName, localFileResourceDirectory, onFallback));

        return @this;
    }
}