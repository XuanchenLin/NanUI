// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using static Vanara.PInvoke.User32;

namespace WinFormium.Browser;
internal static class BrowserRenderWidgetHostFinder
{
    private class ClassDetails
    {
        public HWND DescendantFound { get; set; }
    }

    private static bool EnumWindow(HWND hWnd, IntPtr lParam)
    {
        const string CHROMIUM_WIDGET_HOST_CLASS_NAME = "Chrome_RenderWidgetHostHWND";

        var buffer = new StringBuilder(256);


        GetClassName(hWnd, buffer, buffer.Capacity);

        if (buffer.ToString() == CHROMIUM_WIDGET_HOST_CLASS_NAME)
        {
            var gcHandle = GCHandle.FromIntPtr(lParam);

            var classDetails = (ClassDetails)gcHandle.Target!;

            classDetails.DescendantFound = hWnd;
            return false;
        }

        return true;
    }

    internal static bool TryFindHandle(IntPtr browserHandle, out HWND chromeWidgetHostHandle)
    {
        var classDetails = new ClassDetails();
        var gcHandle = GCHandle.Alloc(classDetails);

        var childProc = new EnumWindowsProc(EnumWindow);

        EnumChildWindows(browserHandle, childProc, GCHandle.ToIntPtr(gcHandle));

        chromeWidgetHostHandle = classDetails.DescendantFound;

        gcHandle.Free();

        return classDetails.DescendantFound != HWND.NULL;
    }

}
