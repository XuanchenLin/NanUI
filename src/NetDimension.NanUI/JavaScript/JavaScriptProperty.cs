using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript;

public sealed class JavaScriptProperty : JavaScriptValue
{
    internal static HashSet<JavaScriptProperty> Bag { get; } = new HashSet<JavaScriptProperty>();

    internal JavaScriptProperty() : base(JavaScriptValueType.Property)
    {
        Bag.Add(this);
    }

    public bool Writable { get; internal set; }


    public Func<JavaScriptValue> Getter { get; set; }

    Action<JavaScriptValue> _setter;
    public Action<JavaScriptValue> Setter
    {
        get => _setter; set
        {
            _setter = value;

            if (_setter != null)
                Writable = true;
            else
                Writable = false;

        }
    }

    internal override JSValueDefinition ToDefinition()
    {
        var def = new JSValueDefinition();

        def.ValueType = ValueType;

        def.Uuid = Uuid;

        def.Name = Name;

        def.ValueDefinition = new JSPropertyDefinition
        {
            Writable = Writable
        };

        return def;
    }

    public static new JavaScriptProperty FromJson(string json)
    {
        return FromDefinition(JsonSerializer.Deserialize<JSPropertyDefinition>(json));
    }

    internal static JavaScriptProperty FromDefinition(JSPropertyDefinition definition)
    {
        if (definition == null)
        {
            return null;
        }

        var value = new JavaScriptProperty
        {
            Writable = definition.Writable
        };

        return value;
    }

    internal static void ReleaseProps(CefFrame frame)
    {
        if (frame == null) return;

        Bag.RemoveWhere(x => x.Frame != null && x.Frame.Identifier == frame.Identifier && !x.IsFreeze);
    }

    internal static void ReleaseProps()
    {
        Bag.Clear();
    }
}
