using static Vanara.PInvoke.User32;

namespace NetDimension.NanUI.HostWindow;

internal class StandardHostWindow : SystemWindow, IFormiumHostWindow
{
    public StandardHostWindow(Formium formium)
    {
        Formium = formium;
    }

    public WindowMessageDelegate OnWindowsMessage { get; set; }
    public WindowMessageDelegate OnDefWindowsMessage { get; set; }
    public Formium Formium { get; }

    HitTestValues _hitTestValue = HitTestValues.HTCLIENT;

    protected override void WndProc(ref Message m)
    {


        var handled = OnWindowsMessage?.Invoke(ref m) ?? false;

        if (!handled)
        {
            base.WndProc(ref m);
        }
    }

    protected override void DefWndProc(ref Message m)
    {
        var handled = OnDefWindowsMessage?.Invoke(ref m) ?? false;

        if (!handled)
        {
            base.DefWndProc(ref m);
        }
    }

    public HitTestValues HitTest(Point point)
    {
        return _hitTestValue;
    }
}
