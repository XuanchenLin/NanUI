namespace NetDimension.NanUI;

public static class DataServiceExtensionRegister
{
    public static ApplicationConfigurationBuilder UseDataServiceResource(this ApplicationConfigurationBuilder @this, string scheme, string domainName, Action<Resource.Data.DataServiceProvider> buildDataService = null)
    {


        @this.UseCustomResourceHandler(() => new Resource.Data.SchemeConfiguration(scheme, domainName, buildDataService));

        return @this;
    }

    public static ApplicationConfigurationBuilder UseDataServiceResource(this ApplicationConfigurationBuilder @this, string scheme, string domainName)
    {

        @this.UseCustomResourceHandler(() => new Resource.Data.SchemeConfiguration(scheme, domainName, builder => {
            builder.ImportDataServiceAssembly(Assembly.GetEntryAssembly());
        }));

        return @this;
    }
}
