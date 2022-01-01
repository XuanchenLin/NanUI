namespace NetDimension.NanUI.HostWindow;

public sealed class BorderlessWindowStyle : WindowStyleBase
{
    private FramelessHostWindow Host { get; }

    public BorderlessWindowStyle(Form form)
        : base(form)
    {
        Host = (FramelessHostWindow)form;
    }

    public ShadowEffect ShadowEffect
    {
        get => Host.ShadowEffect;
        set => Host.ShadowEffect = value;
    }

    public CornerStyle CornerStyle
    {
        get => Host.CornerStyle;
        set => Host.CornerStyle = value;
    }

    public Color ShadowColor
    {
        get => Host.ShadowColor;
        set => Host.ShadowColor = value;
    }

    public Color? InactiveShadowColor
    {
        set => Host.InactiveShadowColor = value;
        get => Host?.InactiveShadowColor;
    }
}
