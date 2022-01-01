namespace NetDimension.NanUI.HostWindow;

public class WindowDpiChangedEventArgs : EventArgs
{
    public int OldDPI { get; }
    public int NewDPI { get; }

    internal WindowDpiChangedEventArgs(int oldDpi, int newDpi)
    {
        OldDPI = oldDpi;
        NewDPI = newDpi;
    }
}
