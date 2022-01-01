namespace NetDimension.NanUI;

public sealed class RuntimeBuilderContext
{
    public IDictionary<object, object> Properties { get; }

    internal RuntimeBuilderContext(IDictionary<object, object> properties)
    {
        Properties = properties;
    }
}
