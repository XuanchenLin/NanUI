// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;
public class PropertyManager
{
    Dictionary<string, Property> settings = new Dictionary<string, Property>();

    public void SetValue(string name, object value)
    {
        settings[name] = new Property(value, value.GetType());
    }

    public void SetValue<T>(string name, T value) where T : notnull
    {
        settings[name] = new Property(value, typeof(T));
    }

    public object? GetValue(string name)
    {
        if (settings.TryGetValue(name, out var setting))
        {
            return setting.Value;
        }

        return null;
    }

    public Property GetProperty(string name)
    {
        if (settings.TryGetValue(name, out var setting))
        {
            return setting;
        }

        throw new KeyNotFoundException();
    }



    public T? GetValue<T>(string name)
    {
        if (settings.TryGetValue(name, out var setting))
        {
            return (T)setting.Value;
        }

        return default;
    }

    public void Remove(string name)
    {
        settings.Remove(name);
    }

    public bool Exists(string name)
    {
        return settings.ContainsKey(name);
    }
}

public sealed class Property
{
    public object Value { get; set; }
    public Type ValueType { get; set; }

    public Property(object value, Type valueType)
    {
        Value = value;
        ValueType = valueType;
    }
}
