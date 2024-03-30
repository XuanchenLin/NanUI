// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace WinFormium.Browser;
internal sealed class BridgeMessage
{
    public static BridgeMessage? FromJson(string json)
    {
        var bridgeMessage = JsonSerializer.Deserialize<BridgeMessage>(json);

        return bridgeMessage;
    }

    public required string Name { get; init; }

    [JsonIgnore]
    public object? Data { get; private set; }

    public string? Json { get; set; }

    public BridgeMessage()
    { }

    [SetsRequiredMembers]
    public BridgeMessage(string name, object? data = null)
    {
        Name = name;
        Data = data;
        Json = JsonSerializer.Serialize(data);
    }

    public T? DeserializeData<T>()
    {
        if (Json == null || string.IsNullOrEmpty(Json)) return default;

        var obj = JsonSerializer.Deserialize<T>(Json);

        Data = obj;

        return obj;
    }

    public void SetData(object obj)
    {
        Data = obj;

        Json = JsonSerializer.Serialize(Data);
    }

    public string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }
}
