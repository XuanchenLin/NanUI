// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;

public class JavaScriptObject : JavaScriptValue, IDictionary<string, JavaScriptValue>
{
    internal Dictionary<string, JavaScriptValue> Contents { get; } = new Dictionary<string, JavaScriptValue>();

    public JavaScriptValue this[string key]
    {
        get => Contents[key];
        set
        {
            var item = Contents[key] = value;
            item.Parent = this;
        }
    }

    public JavaScriptObject DefineProperty(string name, Func<JavaScriptValue> getter, Action<JavaScriptValue>? setter = null)
    {
        var prop = new JavaScriptProperty()
        {
            Getter = getter,
            Setter = setter,
            Parent = this
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

    public JavaScriptObject Add(string key, Action<JavaScriptArray, JavaScriptPromise> promiseDelegate)
    {
        return Add(key, new JavaScriptAsynchronousFunction(promiseDelegate) { Parent = this });
    }

    public JavaScriptObject Add(string key, Func<JavaScriptArray, JavaScriptValue?> functionDelegate)
    {
        return Add(key, new JavaScriptSynchronousFunction(functionDelegate) { Parent = this });
    }

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
        return Contents.TryGetValue(key, out value!);
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

        throw new IndexOutOfRangeException();
    }

    public IEnumerable<string> PropertyNames => Keys;

    public IEnumerable<JavaScriptValue> PropertySymbols => Values;

    public int Length => Contents.Count;

    public ICollection<string> Keys => Contents.Keys;

    public ICollection<JavaScriptValue> Values => Contents.Values;

    public int Count => Contents.Count;

    public bool IsReadOnly => false;

    public JavaScriptObject()
    : base(JavaScriptValueType.Object) { }

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

    internal override JavaScriptValueDefinition ToDefinition()
    {
        return new JavaScriptValueDefinition
        {
            Name = Name,
            Uuid = Uuid,
            ValueType = ValueType,
            ValueDefinition = Contents.ToDictionary(k => k.Key, v => v.Value.ToDefinition())
        };
    }

    protected internal override void AssociateToFrame(CefFrame? frame)
    {
        base.AssociateToFrame(frame);

        foreach (var item in Contents.Values)
        {
            item.AssociateToFrame(frame);
        }
    }

    internal static new JavaScriptObject? FromJson(string json)
    {
        return FromDefinition(JsonSerializer.Deserialize<Dictionary<string, JavaScriptValueDefinition>>(json));
    }

    internal static JavaScriptObject? FromDefinition(Dictionary<string, JavaScriptValueDefinition>? definition)
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
}
