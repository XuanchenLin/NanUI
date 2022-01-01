using System.Collections;
using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript;

public static class JavaScriptObjectExtension
{
    public static JavaScriptObject ToObject(this JavaScriptValue jsValue)
    {
        if (jsValue != null && jsValue.IsObject)
        {
            return (JavaScriptObject)jsValue;
        }

        throw new InvalidOperationException($"This is not a {nameof(JavaScriptObject)}.");
    }
}

public sealed class JavaScriptObject : JavaScriptValue, IDictionary<string, JavaScriptValue>
{

    internal static HashSet<JavaScriptObject> Bag { get; } = new HashSet<JavaScriptObject>();

    public JavaScriptValue this[string key]
    {
        get => Contents[key];
        set => Contents[key] = value;
    }

    public JavaScriptObject DefineProperty(string name, Func<JavaScriptValue> getter, Action<JavaScriptValue> setter = null)
    {
        var prop = new JavaScriptProperty()
        {
            Getter = getter,
            Setter = setter
        };
        Contents.Add(name, prop);
        return this;

    }

    public JavaScriptObject Add(string key, JavaScriptValue value)
    {
        value.Parent = this;
        Contents.Add(key, value);
        return this;
    }

    public JavaScriptObject Add(string key, bool value)
    {
        return Add(key, new JavaScriptValue(value));
    }

    public JavaScriptObject Add(string key, uint value)
    {
        return Add(key, new JavaScriptValue(value));
    }

    public JavaScriptObject Add(string key, int value)
    {
        return Add(key, new JavaScriptValue(value));
    }
    public JavaScriptObject Add(string key, long value)
    {
        return Add(key, new JavaScriptValue(value));
    }
    public JavaScriptObject Add(string key, ulong value)
    {
        return Add(key, new JavaScriptValue(value));
    }
    public JavaScriptObject Add(string key, short value)
    {
        return Add(key, new JavaScriptValue(value));
    }
    public JavaScriptObject Add(string key, ushort value)
    {
        return Add(key, new JavaScriptValue(value));
    }
    public JavaScriptObject Add(string key, double value)
    {
        return Add(key, new JavaScriptValue(value));
    }
    public JavaScriptObject Add(string key, float value)
    {
        return Add(key, new JavaScriptValue(value));
    }
    public JavaScriptObject Add(string key, decimal value)
    {
        return Add(key, new JavaScriptValue(value));
    }
    public JavaScriptObject Add(string key, DateTime value)
    {
        return Add(key, new JavaScriptValue(value));
    }
    public JavaScriptObject Add(string key, string value)
    {
        return Add(key, new JavaScriptValue(value));
    }

    public JavaScriptObject Add(string key, Action<JavaScriptArray, JavaScriptFunctionPromise> action)
    {
        return Add(key, new JavaScriptAsyncFunction(action));
    }

    //public JavaScriptObject Add(string key, CefFrame frame, Action<JavaScriptArray, JavaScriptFunctionPromise> action)
    //{
    //    return Add(key, (JavaScriptValue)new JavaScriptAsyncFunction(frame,action));
    //}

    //public JavaScriptObject Add(string key, CefFrame frame, Func<JavaScriptArray, JavaScriptValue> func)
    //{
    //    return Add(key, (JavaScriptValue)new JavaScriptSyncFunction(frame, func));
    //}

    public JavaScriptObject Add(string key, Func<JavaScriptArray, JavaScriptValue> func)
    {
        return Add(key, new JavaScriptSyncFunction(func));
    }


    //public JavaScriptObject Add(string key, JavaScriptProperty property)
    //{
    //    return Add(key, (JavaScriptValue)property);
    //}

    public bool ContainsKey(string key)
    {
        return Contents.ContainsKey(key);
    }

    public bool Remove(string key)
    {
        Contents[key].Parent = null;

        return Contents.Remove(key);
    }

    public JavaScriptValue GetValue(string key)
    {
        return Contents[key];
    }

    public bool TryGetValue(string key, out JavaScriptValue value)
    {
        return Contents.TryGetValue(key, out value);
    }

    public void Clear()
    {
        Contents.Values.ToList().ForEach(x => x.Parent = null);

        Contents.Clear();
    }

    public string NameOf(JavaScriptValue item)
    {
        var idx = Contents.Values.ToList().IndexOf(item);

        if (idx >= 0)
        {
            return Contents.Keys.ToList()[idx];
        }

        return null;
    }

    public IEnumerable<string> PropertyNames => Contents.Keys.ToList();
    public IEnumerable<JavaScriptValue> PropertySymbols => Contents.Values.ToList();

    public int Length => Contents.Count;

    public static JavaScriptObject Create()
    {
        return new JavaScriptObject();
    }

    internal Dictionary<string, JavaScriptValue> Contents { get; } = new Dictionary<string, JavaScriptValue>();
    public ICollection<string> Keys { get; }
    public ICollection<JavaScriptValue> Values { get; }
    public int Count { get; }
    public bool IsReadOnly { get; }

    public JavaScriptObject()
        : base(JavaScriptValueType.Object)
    {
        Bag.Add(this);

    }


    internal override JSValueDefinition ToDefinition()
    {
        var def = new JSValueDefinition();

        def.ValueType = ValueType;

        def.Uuid = Uuid;

        def.Name = Name;

        def.ValueDefinition = Contents.ToDictionary(k => k.Key, v => v.Value.ToDefinition());

        return def;
    }

    internal static new JavaScriptObject FromJson(string json)
    {
        return FromDefinition(JsonConvert.DeserializeObject<Dictionary<string, JSValueDefinition>>(json));
    }

    internal static JavaScriptObject FromDefinition(Dictionary<string, JSValueDefinition> definition)
    {
        if (definition == null)
        {
            return null;
        }

        var value = new JavaScriptObject();

        foreach (var kv in definition)
        {
            value.Add(kv.Key, FromDefinition(kv.Value));
        }

        return value;
    }

    public string GetString(string propertyName)
    {
        return GetValue(propertyName)?.GetString();
    }

    public int GetInt(string propertyName)
    {
        return GetValue(propertyName)?.GetInt() ?? default;
    }

    public double GetDouble(string propertyName)
    {
        return GetValue(propertyName)?.GetDouble() ?? default;
    }

    public DateTime GetDateTime(string propertyName)
    {
        return GetValue(propertyName)?.GetDateTime() ?? default;
    }

    public bool GetBool(string propertyName)
    {
        return GetValue(propertyName)?.GetBool() ?? default;
    }


    internal static void ReleaseObjects(CefFrame frame)
    {
        if (frame == null) return;

        Bag.RemoveWhere(x => x.Frame != null && x.Frame.Identifier == frame.Identifier && !x.IsFreeze);
    }

    internal static void ReleaseObjects()
    {
        Bag.Clear();
    }

    void IDictionary<string, JavaScriptValue>.Add(string key, JavaScriptValue value)
    {
        Contents.Add(key, value);
    }

    public void Add(KeyValuePair<string, JavaScriptValue> item)
    {
        Contents.Add(item.Key, item.Value);
    }

    public bool Contains(KeyValuePair<string, JavaScriptValue> item)
    {
        return Contents.ContainsKey(item.Key) && Contents.ContainsValue(item.Value);
    }

    public void CopyTo(KeyValuePair<string, JavaScriptValue>[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(KeyValuePair<string, JavaScriptValue> item)
    {
        return Contents.Remove(item.Key);
    }

    public IEnumerator<KeyValuePair<string, JavaScriptValue>> GetEnumerator()
    {
        return Contents.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return Contents.GetEnumerator();
    }
}
