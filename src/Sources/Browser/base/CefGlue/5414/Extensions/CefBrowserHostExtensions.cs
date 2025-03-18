// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.CefGlue;

public static class CefBrowserHostExtensions
{
    public static unsafe bool SendDevToolsMessage(this CefBrowserHost browserHost, byte[] message)
    {
        fixed (byte* messagePtr = &message[0])
        {
            return browserHost.SendDevToolsMessage((IntPtr)messagePtr, message.Length);
        }
    }

    public static unsafe bool SendDevToolsMessage(this CefBrowserHost browserHost, ArraySegment<byte> message)
    {
        fixed (byte* messagePtr = &message.Array[message.Offset])
        {
            return browserHost.SendDevToolsMessage((IntPtr)messagePtr, message.Count);
        }
    }
}
