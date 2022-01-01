namespace NetDimension.NanUI.HostWindow;

public abstract class WindowStyleBase
{
    internal protected Form Owner { get; }

    public WindowStyleBase(Form window)
    {
        Owner = window;
    }


}
