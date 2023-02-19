namespace NetDimension.NanUI.HostWindow;


public enum CornerStyle
{
    None = 0,
    Tiny = 4,
    Small = 7,
    Normal = 10,
    Big = 13,
    Huge = 16
}

public enum ShadowEffect
{
    None = 0,
    Glow,
    Small,
    Normal,
    Big,
    Huge,
    DropShadow,
    Custom
}

partial class _FackUnusedClass
{

}


internal partial class BorderlessWindow
{
    public CornerStyle CornerStyle
    {
        get => _windowCornerStyle;
        set
        {
            if (value != _windowCornerStyle)
            {
                _windowCornerStyle = value;


                if(_windowCornerStyle == CornerStyle.None)
                {
                    WindowNonclientAreaBorders = new Padding(1);
                }

                InvalidateNonClientArea();

                if (_isShadowInitialized)
                {
                    RedrawShadow();
                }


            }
        }
    }

    public ShadowEffect ShadowEffect
    {
        get => _windowShadowStyle; set
        {
            _windowShadowStyle = value;
            RedrawShadow();
        }
    }

    public override Size MinimumSize
    {
        get
        {
            return base.MinimumSize;
        }
        set
        {
            if (_minimumSize == null && value != Size.Empty)
                _minimumSize = value;

            base.MinimumSize = value;
        }
    }
    public Color ShadowColor
    {
        get => _shadowColor;
        set
        {
            if (value != _shadowColor)
            {
                _shadowColor = value;

                RedrawShadow();

                //BackColor = _shadowColor;
            }
        }
    }

    public Color? InactiveShadowColor
    {
        get => _inactiveShadowColor;
        set
        {
            if (value != _inactiveShadowColor)
            {
                _inactiveShadowColor = value;

                RedrawShadow();
            }
        }
    }

    public event EventHandler<WindowDpiChangedEventArgs> SystemDpiChanged;






}
