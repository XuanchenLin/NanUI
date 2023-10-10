// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;

public class JavaScriptArray : JavaScriptValue, IList<JavaScriptValue>
{
    internal List<JavaScriptValue> Contents { get; } = new List<JavaScriptValue>();
    public bool IsReadOnly => false;
    public int Count => Contents.Count;

    public JavaScriptArray()
    : base(JavaScriptValueType.Array)
    {

    }

    public JavaScriptValue this[int index]
    {
        get => Contents[index];
        set => Contents[index] = value;
    }


    public JavaScriptArray Add(JavaScriptValue item)
    {
        item.Parent = this;
        Contents.Add(item);

        return this;
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
    public JavaScriptValue GetValue(int index)
    {
        return Contents[index];
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

    internal override JavaScriptValueDefinition ToDefinition()
    {
        return new JavaScriptValueDefinition
        {
            Name = Name,
            Uuid = Uuid,
            ValueType = ValueType,
            ValueDefinition = Contents.Select(x => x.ToDefinition()).ToList()
        };
    }

    protected internal override void AssociateToFrame(CefFrame? frame)
    {
        base.AssociateToFrame(frame);

        foreach (var item in Contents)
        {
            item.AssociateToFrame(frame);
        }
    }
    internal static new JavaScriptArray? FromJson(string json)
    {
        return FromDefinition(JsonSerializer.Deserialize<List<JavaScriptValueDefinition>>(json));
    }

    internal static JavaScriptArray? FromDefinition(List<JavaScriptValueDefinition>? definition)
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

}


public static class JavaScriptArrayExtension
{
    public static JavaScriptArray ToArray(this JavaScriptValue jsValue)
    {
        if (jsValue != null && jsValue.ValueType == JavaScriptValueType.Array)
        {
            return (JavaScriptArray)jsValue;
        }

        throw new InvalidOperationException($"This is not a {nameof(JavaScriptArray)}.");
    }
}