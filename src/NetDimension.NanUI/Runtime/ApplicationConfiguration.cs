namespace NetDimension.NanUI;

public sealed class ApplicationConfiguration
{
    public Func<ApplicationContext, Formium> UseMainWindow { get; internal set; }

    public Func<ApplicationContext> UseApplicationContext { get; internal set; }

    public Action<RuntimeContext, IDictionary<string, object>>[] UseExtensions { get; internal set; } = new Action<RuntimeContext, IDictionary<string, object>>[5];

    internal ApplicationConfiguration()
    {

    }

}
