// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


namespace WinFormium.JavaScript;

public class JavaScriptProperty : JavaScriptValue
{
    public bool Writable { get; internal set; }
    public Func<JavaScriptValue>? Getter { get; set; }

    Action<JavaScriptValue>? _setter;

    public Action<JavaScriptValue>? Setter
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

    internal JavaScriptProperty() : base(JavaScriptValueType.Property) { }


    internal override JavaScriptValueDefinition ToDefinition()
    {
        return new JavaScriptValueDefinition
        {
            Name = Name,
            Uuid = Uuid,
            ValueType = ValueType,
            ValueDefinition = new JavaScriptPropertyDefinition { Writable = Writable}
        };
    }


    public static new JavaScriptProperty? FromJson(string json)
    {
        return FromDefinition(JsonSerializer.Deserialize<JavaScriptPropertyDefinition>(json));
    }

    internal static JavaScriptProperty? FromDefinition(JavaScriptPropertyDefinition? definition)
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

}
