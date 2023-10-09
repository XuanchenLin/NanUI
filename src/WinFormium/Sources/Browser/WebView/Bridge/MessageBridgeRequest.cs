// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
//
// GITHUB: https://github.com/XuanchenLin/WinFormium
// EMail: xuanchenlin(at)msn.com QQ:19843266 WECHAT:linxuanchen1985

namespace WinFormium.Browser;
public sealed class MessageBridgeRequest
{
    public required string Name { get; set; }
    public required bool IsRemote { get; set; } = false;
    public required int BrowserId { get; set; }
    public required long FrameId { get; set; }
    public string? Payload { get; set; }

    public string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }

    public static MessageBridgeRequest FromJson(string json)
    {
        return JsonSerializer.Deserialize<MessageBridgeRequest>(json)!;
    }
}
