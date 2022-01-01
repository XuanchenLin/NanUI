namespace NetDimension.NanUI.JavaScript;

internal class JSValueDefinition
{
    public Guid Uuid { get; set; }
    public string Name { get; set; }
    public JavaScriptValueType ValueType { get; set; }
    public string ValueTypeName => Enum.GetName(ValueType.GetType(), ValueType);
    public object ValueDefinition { get; set; }
}
