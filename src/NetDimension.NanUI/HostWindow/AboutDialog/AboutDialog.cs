namespace NetDimension.NanUI.HostWindow;

internal class AboutDialog : Formium
{
    public override HostWindowType WindowType { get; } = HostWindowType.SystemBorderless;
    public override string StartUrl { get; } = "res://formium/AboutDialog/index.html"; //"res://formium/AboutDialog/index.html";

    protected override bool DisableAboutMenu => true;
    public AboutDialog()
    {
        Size = new Size(540, 360);
        StartPosition = FormStartPosition.CenterParent;
        Sizable = false;
        EnableSplashScreen = false;
        ShowInTaskBar = false;
        Maximizable = false;
        Minimizable = false;

        BeforePopup += HandlePopupWindow;
        BeforeContextMenu += (_, e) =>
        {
            e.Model.Clear();
        };
    }

    private void OpenExternalUrl(string url)
    {
        var ps = new System.Diagnostics.ProcessStartInfo(url)
        {
            UseShellExecute = true,
            Verb = "open"
        };
        System.Diagnostics.Process.Start(ps);
    }

    private void HandlePopupWindow(object sender, Browser.BeforePopupEventArgs e)
    {
        e.Handled = true;

        InvokeIfRequired(() =>
        {
            OpenExternalUrl(e.TargetUrl);
        });
    }

    protected override void OnReady()
    {

    }
}
