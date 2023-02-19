namespace NetDimension.NanUI.HostWindow;

public sealed class LayeredWindowStyle : WindowStyleBase
{
    public LayeredWindowStyle(Form form)
        : base(form)
    {
        Host = (LayeredStyleHostWindow)form;
    }

    private LayeredStyleHostWindow Host { get; }



}
