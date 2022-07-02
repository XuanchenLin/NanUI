
namespace NetDimension.NanUI;

public static class LocalFileExtensionRegister
{
    /// <summary>
    /// Use local files and directories as the web resource
    /// </summary>
    /// <param name="this">Instance of ApplicationConfigurationBuilder</param>
    /// <param name="scheme"></param>
    /// <param name="domainName"></param>
    /// <param name="localFileResourceDirectory"></param>
    /// <param name="onFallback"></param>
    /// <returns></returns>
    public static ApplicationConfigurationBuilder UseLocalFileResource(this ApplicationConfigurationBuilder @this, string scheme, string domainName, string localFileResourceDirectory, Func<string, string> onFallback = null)
    {
        @this.UseCustomResourceHandler(() => new Resource.LocalFile.SchemeConfiguration(scheme, domainName, localFileResourceDirectory, onFallback));

        return @this;
    }

    /// <summary>
    /// Use local files and directories as the web resource
    /// </summary>
    /// <param name="this">Instance of RuntimeContext</param>
    /// <param name="scheme"></param>
    /// <param name="domainName"></param>
    /// <param name="localFileResourceDirectory"></param>
    /// <param name="onFallback"></param>
    public static void UseLocalFileResource(this RuntimeContext @this, string scheme, string domainName, string localFileResourceDirectory, Func<string, string> onFallback = null)
    {
        @this.RegisterCustomResourceHandler(new Resource.LocalFile.SchemeConfiguration(scheme, domainName, localFileResourceDirectory, onFallback));
    }
}
