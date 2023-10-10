// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;

public class JavaScriptObjectRegisterHandle
{
    internal static List<JavaScriptObjectRegisterHandle> Handles { get; } = new();

    internal long Id { get; init; }
    internal CefFrame Frame { get; }

    internal static bool Exists(CefFrame frame)
    {
        return Handles.Any(x => x.Frame.Identifier == frame.Identifier);
    }

    internal JavaScriptObjectRegisterHandle(CefFrame frame)
    {
        Frame = frame;
        Id = frame.Identifier;
        Handles.Add(this);
    }

}
