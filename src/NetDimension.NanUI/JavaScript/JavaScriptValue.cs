using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript;

public enum JavaScriptValueType
{
    Undefined = 0,
    Null,
    Bool,
    Int,
    Double,
    String,
    DateTime,
    Object,
    Array,
    Function,
    Property,
    JSON
}



public class JavaScriptValue
{
    public static implicit operator string(JavaScriptValue jsvalue) => jsvalue.GetString();
    public static implicit operator int(JavaScriptValue jsvalue) => jsvalue.GetInt();
    public static implicit operator double(JavaScriptValue jsvalue) => jsvalue.GetDouble();
    public static implicit operator DateTime(JavaScriptValue jsvalue) => jsvalue.GetDateTime();
    public static implicit operator bool(JavaScriptValue jsvalue) => jsvalue.GetBool();

    internal protected CefFrame Frame { get; internal set; }

    public bool IsUndefined { get; }
    public bool IsNull { get; }
    public bool IsBool { get; }
    public bool IsNumber { get; }
    public bool IsString { get; }
    public bool IsDateTime { get; }
    public bool IsObject { get; }
    public bool IsArray { get; }
    public bool IsFunction { get; }
    public bool IsProperty { get; }
    public bool IsJSON { get; }

    internal string Name
    {
        get
        {

            if (Parent is JavaScriptArray)
            {
                var p = (JavaScriptArray)Parent;

                var index = p.IndexOf(this);

                return $"{index}";
            }
            else if (Parent is JavaScriptObject)
            {
                var p = (JavaScriptObject)Parent;

                var name = p.NameOf(this);

                return name;
            }

            return null;
        }
    }


    //public static JavaScriptValue Create(bool value)
    //{
    //    return new JavaScriptValue(value, JavaScriptValueType.Bool);
    //}

    //public static JavaScriptValue Create(uint value)
    //{
    //    return new JavaScriptValue(value, JavaScriptValueType.Int);
    //}

    //public static JavaScriptValue Create(int value)
    //{
    //    return new JavaScriptValue(value, JavaScriptValueType.Int);
    //}

    //public static JavaScriptValue Create(long value)
    //{
    //    return new JavaScriptValue(value, JavaScriptValueType.Int);
    //}

    //public static JavaScriptValue Create(ulong value)
    //{
    //    return new JavaScriptValue(value, JavaScriptValueType.Int);
    //}

    //public static JavaScriptValue Create(short value)
    //{
    //    return new JavaScriptValue(value, JavaScriptValueType.Int);
    //}

    //public static JavaScriptValue Create(ushort value)
    //{
    //    return new JavaScriptValue(value, JavaScriptValueType.Int);
    //}

    //public static JavaScriptValue Create(double value)
    //{
    //    return new JavaScriptValue(value, JavaScriptValueType.Double);
    //}

    //public static JavaScriptValue Create(float value)
    //{
    //    return new JavaScriptValue(value, JavaScriptValueType.Double);
    //}

    //public static JavaScriptValue Create(decimal value)
    //{
    //    return new JavaScriptValue(value, JavaScriptValueType.Double);
    //}

    //public static JavaScriptValue Create(DateTime value)
    //{
    //    return new JavaScriptValue(value, JavaScriptValueType.DateTime);
    //}

    //public static JavaScriptValue Create(string value)
    //{
    //    return new JavaScriptValue(value, JavaScriptValueType.String);
    //}

    internal static JavaScriptValue CreateUndefined()
    {
        return new JavaScriptValue(null, JavaScriptValueType.Undefined);
    }

    internal readonly object RawValue = null;

    internal protected Guid Uuid { get; set; } = Guid.NewGuid();
    internal JavaScriptValueType ValueType { get; } = JavaScriptValueType.Undefined;
    internal JavaScriptValue Parent { get; set; } = null;

    public JavaScriptValue()
    {
        IsNull = true;
    }

    public JavaScriptValue(bool value)
        : this(value, JavaScriptValueType.Bool)
    {

    }

    public JavaScriptValue(uint value)
        : this(value, JavaScriptValueType.Int)
    {

    }

    public JavaScriptValue(int value)
        : this(value, JavaScriptValueType.Int)
    {
    }

    public JavaScriptValue(long value)
        : this(value, JavaScriptValueType.Int)
    {
    }

    public JavaScriptValue(ulong value)
        : this(value, JavaScriptValueType.Int)
    {

    }

    public JavaScriptValue(short value)
        : this(value, JavaScriptValueType.Int)
    {

    }

    public JavaScriptValue(ushort value)
        : this(value, JavaScriptValueType.Int)
    {

    }

    public JavaScriptValue(double value)
        : this(value, JavaScriptValueType.Double)
    {

    }

    public JavaScriptValue(float value)
        : this(value, JavaScriptValueType.Double)
    {

    }

    public JavaScriptValue(decimal value)
        : this(value, JavaScriptValueType.Double)
    {

    }

    public JavaScriptValue(DateTime value)
        : this(value, JavaScriptValueType.DateTime)
    {

    }

    public JavaScriptValue(string value)
        : this(value, JavaScriptValueType.String)
    {

    }


    internal JavaScriptValue(JavaScriptValueType valueType)
    {

        switch (valueType)
        {
            case JavaScriptValueType.Object:
                IsObject = true;
                break;
            case JavaScriptValueType.Array:
                IsArray = true;
                break;
            case JavaScriptValueType.Function:
                IsFunction = true;
                break;
            case JavaScriptValueType.Property:
                IsProperty = true;
                break;
        }

        ValueType = valueType;
    }

    internal JavaScriptValue(object value, JavaScriptValueType valueType)
    {
        switch (valueType)
        {
            case JavaScriptValueType.Null:
                IsNull = true;
                break;
            case JavaScriptValueType.Bool:
                IsBool = true;
                break;
            case JavaScriptValueType.Int:
            case JavaScriptValueType.Double:
                IsNumber = true;
                break;
            case JavaScriptValueType.String:
                IsString = true;
                break;
            case JavaScriptValueType.DateTime:
                IsDateTime = true;
                break;
            case JavaScriptValueType.Undefined:
                IsUndefined = true;
                break;
            case JavaScriptValueType.JSON:
                IsJSON = true;
                break;
        }

        ValueType = valueType;

        RawValue = value;
    }

    internal virtual JSValueDefinition ToDefinition()
    {
        var def = new JSValueDefinition();

        def.ValueType = ValueType;

        def.Uuid = Uuid;

        def.Name = Name;

        def.ValueDefinition = RawValue;

        return def;
    }

    internal virtual string ToJson()
    {
        return JsonSerializer.Serialize(ToDefinition());
    }

    //public override string ToString()
    //{
    //    return ToJson();
    //}

    internal static JavaScriptValue FromJson(string json)
    {
        return FromDefinition(JsonSerializer.Deserialize<JSValueDefinition>(json));
    }


    internal static JavaScriptValue FromDefinition(JSValueDefinition definition)
    {
        if (definition == null || definition.ValueDefinition == null)
        {
            return CreateUndefined();
        }

        var type = definition.ValueType;
        var def = (JsonElement)definition.ValueDefinition;
        var uuid = definition.Uuid;
        JavaScriptValue value = null;


        if (type == JavaScriptValueType.Property)
        {
            value = JavaScriptProperty.FromJson(def.GetRawText());
        }

        if (type == JavaScriptValueType.Function)
        {
            var funcDef = JSFunctionDefinition.FromJson(def.GetRawText());

            if (funcDef.Side == CefProcessType.Browser)
            {
                if (funcDef.IsAsyncFunction)
                {
                    value = new JavaScriptFunction
                    {
                        IsAsyncFunction = true,
                        Side = CefProcessType.Browser
                    };
                }
                else
                {
                    value = new JavaScriptFunction
                    {
                        IsAsyncFunction = false,
                        Side = CefProcessType.Browser
                    };
                }
            }
            else
            {
                value = new JavaScriptFunction
                {
                    IsAsyncFunction = false,
                    Side = CefProcessType.Renderer
                };
            }
        }


        if (type == JavaScriptValueType.JSON)
        {
            value = new JavaScriptJsonValue(def.GetString());
        }

        if (type == JavaScriptValueType.Null)
        {
            value = new JavaScriptValue();
        }

        if (type == JavaScriptValueType.Bool)
        {
            value = new JavaScriptValue(def.GetBoolean());
        }

        if (type == JavaScriptValueType.Int)
        {
            value = new JavaScriptValue(def.GetInt32());
        }

        if (type == JavaScriptValueType.Double)
        {
            value = new JavaScriptValue(def.GetDouble());
        }

        if (type == JavaScriptValueType.String)
        {
            value = new JavaScriptValue(def.GetString());
        }

        if (type == JavaScriptValueType.DateTime)
        {
            value = new JavaScriptValue(def.GetDateTime());
        }

        if (type == JavaScriptValueType.Object)
        {
            value = JavaScriptObject.FromJson(def.GetRawText());
        }

        if (type == JavaScriptValueType.Array)
        {
            value = JavaScriptArray.FromJson(def.GetRawText());
        }


        if (value == null)
        {
            value = CreateUndefined();
        }
        else
        {
            value.Uuid = uuid;
        }

        return value;
    }


    public string GetString()
    {
        switch (ValueType)
        {
            case JavaScriptValueType.Bool:
            case JavaScriptValueType.Int:
            case JavaScriptValueType.Double:
                return $"{RawValue}";
            case JavaScriptValueType.DateTime:
                return $"{((DateTime)RawValue).ToLocalTime()}";
            case JavaScriptValueType.JSON:
            case JavaScriptValueType.String:
                return (string)RawValue;
            case JavaScriptValueType.Object:
                return $"[object]";
            case JavaScriptValueType.Array:
                return $"[array]";
            case JavaScriptValueType.Function:
                return $"[function]";
            case JavaScriptValueType.Property:
                return $"[property]";
            default:
                return null;
        }
    }

    public int GetInt()
    {
        if (ValueType == JavaScriptValueType.Double || ValueType == JavaScriptValueType.Int)
        {
            return (int)RawValue;
        }

        if (ValueType == JavaScriptValueType.Bool)
        {
            return ((bool)RawValue) ? 1 : 0;
        }

        return 0;
    }

    public double GetDouble()
    {
        if (ValueType == JavaScriptValueType.Double || ValueType == JavaScriptValueType.Int)
        {
            return Convert.ToDouble(RawValue);
        }

        if (ValueType == JavaScriptValueType.Bool)
        {
            return ((bool)RawValue) ? 1 : 0;
        }

        return 0;
    }

    public DateTime GetDateTime()
    {
        if (ValueType == JavaScriptValueType.String)
        {
            if (DateTime.TryParse((string)RawValue, out var retval))
            {
                retval = retval.ToLocalTime();
                return retval;
            }
        }

        if (ValueType == JavaScriptValueType.DateTime)
        {
            return ((DateTime)RawValue).ToLocalTime();
        }

        return default;
    }

    public bool GetBool()
    {
        if (ValueType == JavaScriptValueType.Int || ValueType == JavaScriptValueType.Double)
        {
            return (int)RawValue != 0;
        }

        if (ValueType == JavaScriptValueType.Bool)
        {
            return (bool)RawValue;
        }


        return false;
    }

    internal bool IsFreeze { get; private set; } = false;


    internal void BindToFrame(CefFrame frame, bool isFreeze = false)
    {
        if (IsObject)
        {
            foreach (var item in ((JavaScriptObject)this).PropertySymbols)
            {
                item.BindToFrame(frame, isFreeze);
            }
        }
        else if (IsArray)
        {
            var target = this.ToArray();

            for (int i = 0; i < target.Count; i++)
            {
                var item = target[i];
                item.BindToFrame(frame, isFreeze);
            }
        }

        Frame = frame;

        IsFreeze = isFreeze;
    }

}
