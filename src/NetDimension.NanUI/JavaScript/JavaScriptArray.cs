using System.Collections;
using Xilium.CefGlue;

namespace NetDimension.NanUI.JavaScript;

public static class JavaScriptArrayExtension
{
    public static JavaScriptArray ToArray(this JavaScriptValue jsValue)
    {
        if (jsValue != null && jsValue.IsArray)
        {
            return (JavaScriptArray)jsValue;
        }

        throw new InvalidOperationException($"This is not a {nameof(JavaScriptArray)}.");
    }
}

public sealed class JavaScriptArray : JavaScriptValue, IList<JavaScriptValue>
{
    public JavaScriptValue this[int index]
    {
        get => Contents[index];
        set => Contents[index] = value;
    }

    public int Count => Contents.Count;

    public JavaScriptArray Add(JavaScriptValue item)
    {
        item.Parent = this;
        Contents.Add(item);

        return this;
    }

    public JavaScriptArray Add(bool value)
    {
        return Add(new JavaScriptValue(value));
    }

    public JavaScriptArray Add(uint value)
    {
        return Add(new JavaScriptValue(value));
    }

    public JavaScriptArray Add(int value)
    {
        return Add(new JavaScriptValue(value));
    }
    public JavaScriptArray Add(long value)
    {
        return Add(new JavaScriptValue(value));
    }
    public JavaScriptArray Add(ulong value)
    {
        return Add(new JavaScriptValue(value));
    }
    public JavaScriptArray Add(short value)
    {
        return Add(new JavaScriptValue(value));
    }
    public JavaScriptArray Add(ushort value)
    {
        return Add(new JavaScriptValue(value));
    }
    public JavaScriptArray Add(double value)
    {
        return Add(new JavaScriptValue(value));
    }
    public JavaScriptArray Add(float value)
    {
        return Add(new JavaScriptValue(value));
    }
    public JavaScriptArray Add(decimal value)
    {
        return Add(new JavaScriptValue(value));
    }
    public JavaScriptArray Add(DateTime value)
    {
        return Add(new JavaScriptValue(value));
    }
    public JavaScriptArray Add(string value)
    {
        return Add(new JavaScriptValue(value));
    }
    public JavaScriptArray Add(CefFrame frame, Action<JavaScriptArray, JavaScriptFunctionPromise> action)
    {
        return Add(new JavaScriptAsyncFunction(frame, action));
    }

    public JavaScriptArray Add(CefFrame frame, Func<JavaScriptArray, JavaScriptValue> func)
    {
        return Add(new JavaScriptSyncFunction(frame, func));
    }

    public JavaScriptArray Add(JavaScriptProperty property)
    {
        return Add(property);
    }

    public void Clear()
    {
        Contents.ForEach(x => x.Parent = null);

        Contents.Clear();
    }

    public bool Contains(JavaScriptValue item)
    {
        return Contents.Contains(item);
    }

    public int IndexOf(JavaScriptValue item)
    {
        return Contents.IndexOf(item);
    }

    public void Insert(int index, JavaScriptValue item)
    {
        item.Parent = this;
        Contents.Insert(index, item);
    }

    public bool Remove(JavaScriptValue item)
    {
        item.Parent = null;

        return Contents.Remove(item);
    }

    public void RemoveAt(int index)
    {

        Contents[index].Parent = null;

        Contents.RemoveAt(index);
    }

    public static JavaScriptArray Create()
    {
        return new JavaScriptArray();
    }

    internal List<JavaScriptValue> Contents { get; } = new List<JavaScriptValue>();
    //public int Count  => Contents.Count;
    
    public bool IsReadOnly => false;

    public JavaScriptArray()
        : base(JavaScriptValueType.Array)
    {

    }

    public JavaScriptValue GetValue(int index)
    {
        return Contents[index];
    }

    internal override JSValueDefinition ToDefinition()
    {
        var def = new JSValueDefinition();

        def.Uuid = Uuid;

        def.ValueType = ValueType;

        def.Name = Name;

        def.ValueDefinition = Contents.Select(x => x.ToDefinition()).ToList();

        return def;
    }


    internal static new JavaScriptArray FromJson(string json)
    {
        return FromDefinition(JsonConvert.DeserializeObject<List<JSValueDefinition>>(json));
    }

    internal static JavaScriptArray FromDefinition(List<JSValueDefinition> definition)
    {
        if (definition == null)
        {
            return null;
        }

        var value = new JavaScriptArray();


        foreach (var item in definition)
        {
            value.Add(FromDefinition(item));
        }


        return value;
    }


    public string GetString(int index)
    {
        return GetValue(index)?.GetString();
    }

    public int GetInt(int index)
    {
        return GetValue(index)?.GetInt() ?? default;
    }

    public double GetDouble(int index)
    {
        return GetValue(index)?.GetDouble() ?? default;
    }

    public DateTime GetDateTime(int index)
    {
        return GetValue(index)?.GetDateTime() ?? default;
    }

    public bool GetBool(int index)
    {
        return GetValue(index)?.GetBool() ?? default;
    }

    void ICollection<JavaScriptValue>.Add(JavaScriptValue item)
    {
        Contents.Add(item);
    }

    public void CopyTo(JavaScriptValue[] array, int arrayIndex)
    {
        Contents.CopyTo(array, arrayIndex);
    }

    public IEnumerator<JavaScriptValue> GetEnumerator()
    {
        return Contents.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return Contents.GetEnumerator();
    }
}
