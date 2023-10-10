// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using WinFormium.Properties;

namespace WinFormium.Forms;


public abstract class FormStyle : IFormStyle
{
    WndProcDelegate? IFormStyle.OnWndProc { get => OnWndProc; set => OnWndProc = value; }
    WndProcDelegate? IFormStyle.OnDefWndProc { get => OnDefWndProc; set => OnDefWndProc = value; }
    OnOffscreenPaintDelegate? IFormStyle.OffscreenPaint { get => OnOffscreenPaint; set => OnOffscreenPaint = value; }

    internal protected abstract bool HasSystemTitleBar { get; set; }
    internal protected abstract bool UseBrowserHitTest { get; set; }
    internal protected virtual bool AsEmbeddedControl { get; } = false;
    internal protected WndProcDelegate? OnWndProc { internal get; set; }
    internal protected WndProcDelegate? OnDefWndProc { internal get; set; }
    internal protected OnOffscreenPaintDelegate? OnOffscreenPaint { internal get; set; }

    protected Formium FormiumInstance { get; }

    private Point? _location = null;

    internal protected bool OffScreenRenderEnabled
    {
        get;
        protected set;
    } = false;

    public Size Size { get; set; } = new Size(960, 640);
    public Size MaximumSize { get; set; } = Size.Empty;
    public Size MinimumSize { get; set; } = Size.Empty;
    public Icon? Icon { get; set; } = Resources.DefaultIcon;
    public string DefaultAppTitle { get; set; } = "WinFormium";
    public bool UsePageTitle { get; set; }
    internal protected bool IsLocationSet => _location != null;
    public Point Location { get => _location ?? Point.Empty; set => _location = value; }
    public bool AllowFullScreen { get; set; } = true;
    public bool ShowInTaskbar { get; set; } = true;
    public StartCenteredMode StartCentered { get; set; } =  StartCenteredMode.None;
    public bool Sizable { get; set; } = true;
    public bool Maximizable { get; set; } = true;
    public bool Minimizable { get; set; } = true;
    public bool TopMost { get; set; } = false;

    public bool AllowSystemMenu { get; set; } = true;

    public FormiumColorMode ColorMode { get; set; } = FormiumColorMode.SystemPreference;

    public FormiumWindowState WindowState { get; set; } = FormiumWindowState.Normal;

    public FormStyle(Formium formium)
    {
        FormiumInstance = formium;
    }

    public abstract CreateHostWindowDelegate CreateHostWindow();

    internal protected virtual void OverwriteHostWindowProperties(Form form)
    {

    }
}

public enum StartCenteredMode
{
    None,
    CenterScreen,
    CenterParent
}