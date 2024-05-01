// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI



namespace WinFormium.JavaScript;

public class JavaScriptValue : IDisposable
{
    private static readonly HashSet<JavaScriptValue> JAVASCRIPT_VALUE_COLLECTION = new();

    public static int JAVASCRIPT_VALUE_COLLECTION_COUNT => JAVASCRIPT_VALUE_COLLECTION.Count;

    internal static void Release()
    {
        for (var i = 0; i < JAVASCRIPT_VALUE_COLLECTION.Count; i++)
        {
            JAVASCRIPT_VALUE_COLLECTION.ElementAt(i)?.Dispose();
        }
    }

    internal static void Release(CefBrowser browser)
    {
        var items = JAVASCRIPT_VALUE_COLLECTION.Where(x => x.GetAssociatedFrame()?.Browser.Identifier == browser.Identifier).ToArray();

        foreach (JavaScriptValue item in items)
        {
            item.Dispose();
        }
    }


    internal static void Release(CefFrame frame)
    {
        var items = JAVASCRIPT_VALUE_COLLECTION.Where(x => x.GetAssociatedFrame()?.Identifier == frame.Identifier).ToArray();

        foreach (JavaScriptValue item in items)
        {
            item.Dispose();
        }
    }


    public static implicit operator string?(JavaScriptValue value) => value.GetString();
    public static implicit operator bool(JavaScriptValue value) => value.GetBoolean();
    public static implicit operator double(JavaScriptValue value) => value.GetDouble();
    public static implicit operator float(JavaScriptValue value) => value.GetFloat();
    public static implicit operator int(JavaScriptValue value) => value.GetInt();
    public static implicit operator long(JavaScriptValue value) => value.GetBigInt();
    public static implicit operator DateTime(JavaScriptValue value) => value.GetDateTime();
    public static implicit operator decimal(JavaScriptValue value) => value.GetDecimal();

    public static implicit operator JavaScriptValue(string value) => new JavaScriptValue(value);
    public static implicit operator JavaScriptValue(bool value) => new JavaScriptValue(value);
    public static implicit operator JavaScriptValue(double value) => new JavaScriptValue(value);
    public static implicit operator JavaScriptValue(float value) => new JavaScriptValue(value);
    public static implicit operator JavaScriptValue(int value) => new JavaScriptValue(value);
    public static implicit operator JavaScriptValue(uint value) => new JavaScriptValue(value);
    public static implicit operator JavaScriptValue(long value) => new JavaScriptValue(value);
    public static implicit operator JavaScriptValue(ulong value) => new JavaScriptValue(value);
    public static implicit operator JavaScriptValue(short value) => new JavaScriptValue(value);
    public static implicit operator JavaScriptValue(ushort value) => new JavaScriptValue(value);
    public static implicit operator JavaScriptValue(decimal value) => new JavaScriptValue(value);
    public static implicit operator JavaScriptValue(DateTime value) => new JavaScriptValue(value);





    internal readonly object? RawValue = null;
    internal protected Guid Uuid { get; internal set; } = Guid.NewGuid();
    internal protected CefFrame? Frame { get; internal set; }
    public JavaScriptValueType ValueType { get; internal set; } = JavaScriptValueType.Undefined;
    internal protected JavaScriptValue? Parent { get; internal set; } = null;

    internal protected bool IsFreeze { get; private set; } = false;

    internal protected virtual void AssociateToFrame(CefFrame? frame)
    {
        Frame = frame;
    }

    internal protected CefFrame? GetAssociatedFrame()
    {
        var frame = Frame ?? Parent?.GetAssociatedFrame();

        Frame = frame;

        return frame;
    }

    public JavaScriptValue()
        : this(JavaScriptValueType.Undefined) { }

    public JavaScriptValue(bool value)
        : this(JavaScriptValueType.Bool, value) { }

    public JavaScriptValue(int value)
        : this(JavaScriptValueType.Number, value) { }

    public JavaScriptValue(uint value)
        : this(JavaScriptValueType.Number, value) { }

    public JavaScriptValue(long value)
        : this(JavaScriptValueType.Number, value) { }

    public JavaScriptValue(ulong value)
        : this(JavaScriptValueType.Number, value) { }

    public JavaScriptValue(short value)
        : this(JavaScriptValueType.Number, value) { }

    public JavaScriptValue(ushort value)
        : this(JavaScriptValueType.Number, value) { }

    public JavaScriptValue(double value)
        : this(JavaScriptValueType.Number, value) { }

    public JavaScriptValue(float value)
        : this(JavaScriptValueType.Number, value) { }

    public JavaScriptValue(decimal value)
        : this(JavaScriptValueType.Number, value) { }

    public JavaScriptValue(string value)
        : this(JavaScriptValueType.String, value) { }

    public JavaScriptValue(DateTime value)
        : this(JavaScriptValueType.Date, value) { }

    internal protected JavaScriptValue(JavaScriptValueType valueType, object? value = null)
    {
        switch (valueType)
        {
            case JavaScriptValueType.Undefined:
                RawValue = null;
                ValueType = JavaScriptValueType.Undefined;
                break;
            case JavaScriptValueType.Null:
                RawValue = null;
                ValueType = JavaScriptValueType.Null;
                break;
            case JavaScriptValueType.Bool:
                ValueType = JavaScriptValueType.Bool;
                RawValue = value ?? default(bool);
                break;
            case JavaScriptValueType.Number:
                ValueType = JavaScriptValueType.Number;
                RawValue = value ?? 0;
                break;
            case JavaScriptValueType.String:
                ValueType = JavaScriptValueType.String;
                RawValue = value ?? default(string);
                break;
            case JavaScriptValueType.Date:
                ValueType = JavaScriptValueType.Date;
                RawValue = value ?? DateTime.Now;
                break;
            case JavaScriptValueType.Object:
                ValueType = JavaScriptValueType.Object;
                break;
            case JavaScriptValueType.Array:
                ValueType = JavaScriptValueType.Array;
                break;
            case JavaScriptValueType.Function:
                ValueType = JavaScriptValueType.Function;
                JAVASCRIPT_VALUE_COLLECTION.Add(this);
                break;
            case JavaScriptValueType.Property:
                ValueType = JavaScriptValueType.Property;
                JAVASCRIPT_VALUE_COLLECTION.Add(this);
                break;
        }



        //
    }

    public bool GetBoolean()
    {
        if (ValueType == JavaScriptValueType.Number)
        {
            var value = (int?)RawValue ?? 0;

            return value != 0;
        }

        if (ValueType == JavaScriptValueType.Bool)
        {
            var value = (bool?)RawValue ?? false;

            return value;
        }


        return false;
    }

    public double GetDouble()
    {
        if (ValueType == JavaScriptValueType.Number)
        {
            if(RawValue is double || RawValue is float || RawValue is decimal)
            {
                return (double)Convert.ChangeType(RawValue, TypeCode.Double);
            }

            return (double)(Convert.ChangeType(RawValue, TypeCode.Int32));
        }

        if (ValueType == JavaScriptValueType.Bool)
        {
            return GetBoolean() ? 1 : 0;
        }

        return default;
    }

    public float GetFloat()
    {
        var value = GetDouble();

        return Convert.ToSingle(value);
    }

    public decimal GetDecimal()
    {
        var value = GetDouble();

        return Convert.ToDecimal(value);
    }

    public int GetInt()
    {
        var value = GetDouble();

        return Convert.ToInt32(value);
    }

    public long GetBigInt()
    {
        var value = GetDouble();

        return Convert.ToInt64(value);
    }

    public DateTime GetDateTime()
    {
        if (ValueType == JavaScriptValueType.String)
        {
            var value = (string?)RawValue;

            if (value == null) return DateTime.Now;

            if (DateTime.TryParse(value, out var retval))
            {
                retval = retval.ToLocalTime();
                return retval;
            }
        }

        if (ValueType == JavaScriptValueType.Date)
        {
            return ((DateTime?)RawValue)?.ToLocalTime() ?? DateTime.Now;
        }

        return default;
    }

    public string? GetString()
    {
        switch (ValueType)
        {
            case JavaScriptValueType.Bool:
            case JavaScriptValueType.Number:
                return $"{RawValue}";

            case JavaScriptValueType.Date:
                return $"{GetDateTime()}";

            case JavaScriptValueType.Json:
            case JavaScriptValueType.String:
                return $"{RawValue}";

            case JavaScriptValueType.Object:
                return $"[object]";

            case JavaScriptValueType.Function:
                return $"[function]";

            case JavaScriptValueType.Array:
                return $"[array]";

            case JavaScriptValueType.Property:
                return $"[property]";

            default:
                return null;
        }
    }

    protected virtual void Dispose(bool isDisposing)
    {
    }

    public static JavaScriptValue? GetJavaScriptValue(Guid uuid)
    {
        return JAVASCRIPT_VALUE_COLLECTION.SingleOrDefault(x => x.Uuid == uuid);
    }

    public void Dispose()
    {

        Dispose(true);

        JAVASCRIPT_VALUE_COLLECTION.Remove(this);
        GC.SuppressFinalize(this);
    }

    internal protected string Name
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

            return string.Empty;
        }
    }

    internal virtual JavaScriptValueDefinition ToDefinition()
    {
        return new JavaScriptValueDefinition
        {
            Name = Name,
            Uuid = Uuid,
            ValueType = ValueType,
            ValueDefinition = RawValue
        };
    }

    internal virtual string ToJson()
    {
        return JsonSerializer.Serialize(ToDefinition());
    }

    internal static JavaScriptValue FromJson(string json)
    {
        return FromDefinition(JsonSerializer.Deserialize<JavaScriptValueDefinition>(json));
    }

    internal static JavaScriptValue FromDefinition(JavaScriptValueDefinition? definition)
    {
        if (definition?.ValueDefinition == null)
        {
            return new JavaScriptValue();
        }

        var type = definition.ValueType;
        var def = (JsonElement)(definition.ValueDefinition ?? string.Empty);
        var uuid = definition.Uuid;
        JavaScriptValue? value = null;


        if (type == JavaScriptValueType.Property)
        {
            value = JavaScriptProperty.FromJson(def.GetRawText());
        }

        if (type == JavaScriptValueType.Function)
        {
            var funcDef = JavaScriptFunctionInvokerDefinition.FromJson(def.GetRawText());

            if (funcDef.Side == ProcessType.Main)
            {
                if (funcDef.IsAsynchronous)
                {
                    value = new JavaScriptFunctionInvoker
                    {
                        IsAsynchronous = true,
                        Side = ProcessType.Main,
                    };
                }
                else
                {
                    value = new JavaScriptFunctionInvoker
                    {
                        IsAsynchronous = false,
                        Side = ProcessType.Main
                    };
                }
            }
            else
            {
                value = new JavaScriptFunctionInvoker
                {
                    IsAsynchronous = false,
                    Side = ProcessType.Renderer
                };
            }
        }


        if (type == JavaScriptValueType.Json)
        {
            var json = def.GetString();

            if (json == null) return new JavaScriptValue(JavaScriptValueType.Null);
            value = new JavaScriptJsonValue(json);
        }

        if (type == JavaScriptValueType.Null)
        {
            value = new JavaScriptValue(JavaScriptValueType.Null);
        }

        if (type == JavaScriptValueType.Bool)
        {
            value = new JavaScriptValue(def.GetBoolean());
        }

        if (type == JavaScriptValueType.Number)
        {
            value = new JavaScriptValue(def.GetDouble());
        }

        if (type == JavaScriptValueType.String)
        {
            value = new JavaScriptValue(def.GetString() ?? string.Empty);
        }

        if (type == JavaScriptValueType.Date)
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
            value = new JavaScriptValue();
        }

        value.Uuid = uuid;

        return value;
    }
}
