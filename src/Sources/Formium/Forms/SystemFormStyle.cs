// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using NetDimension.NanUI.Forms.SystemForm;

namespace NetDimension.NanUI.Forms;

public sealed class SystemFormStyle : FormStyle
{
    private bool _useDirectCompositon = false;

    private SystemFormBackdropType _backdropType = SystemFormBackdropType.None;

    private SystemFormRenderType _renderType = SystemFormRenderType.Hwnd;
    internal protected override bool UseBrowserHitTest { get; set; }
    internal Func<Bitmap?>? ShouldDrawSpalsh { get; set; }

    internal SystemFormStyle(Formium formium) : base(formium)
    {
    }

    public bool TitleBar { get; set; } = true;

    internal SystemFormRenderType RenderType
    {
        get => _renderType;

        set
        {
            if (_renderType == value) return;

            _renderType = value;

            OffScreenRenderEnabled = _renderType == SystemFormRenderType.Offscreen;
        }
    }

    internal bool UseDirectComposition {
        get => RenderType == SystemFormRenderType.Hwnd ? false : _useDirectCompositon;

        set
        {
            if(value != _useDirectCompositon)
            {
                _useDirectCompositon = value;
            }
        }
    }


    public SystemFormBackdropType BackdropType
    {
        get=> _backdropType;
        set
        {
            if(value != _backdropType)
            {
                _backdropType = value;
            }

            switch (_backdropType)
            {
                case SystemFormBackdropType.None:
                    UseDirectComposition = false;
                    RenderType = SystemFormRenderType.Hwnd;
                    break;
                case SystemFormBackdropType.Surface:
                    UseDirectComposition = false;
                    RenderType = SystemFormRenderType.Offscreen;
                    break;
                case SystemFormBackdropType.Transparent:
                case SystemFormBackdropType.Acrylic:
                case SystemFormBackdropType.Mica:
                case SystemFormBackdropType.Transient:
                case SystemFormBackdropType.MicaAlt:
                    UseDirectComposition = true;
                    RenderType = SystemFormRenderType.Offscreen;
                    break;

            }
        }
    }

    protected internal override bool HasSystemTitleBar { get; set; }


    public override CreateHostWindowDelegate CreateHostWindow()
    {
        return () =>
        {
            StandardWindowBase target;

            if (TitleBar)
            {
                UseBrowserHitTest = false;
                HasSystemTitleBar = true;
                target = new SystemStandardWindow(this);

            }
            else
            {
                UseBrowserHitTest = true;
                HasSystemTitleBar = false;
                target = new SystemBorderlessWindow(this);
            }

            return target;
        };
    }
}

public static class SystemFormStyleExtension
{
    public static SystemFormStyle UseSystemForm(this WindowStyleBuilder builder)
    {
        return new SystemFormStyle(builder.FormiumInstance);
    }
}

