namespace NetDimension.NanUI.HostWindow;

public class SystemBorderlessWindowStyle : WindowStyleBase
{

    private DwmFramelessHostWindow Host { get; }

    public SystemBorderlessWindowStyle(Form form) : base(form)
    {
        Host = (DwmFramelessHostWindow)form;
    }


}
