using static Vanara.PInvoke.User32;

namespace NetDimension.NanUI.HostWindow;

public enum HostWindowType
{
    /// <summary>
    /// System default style
    /// </summary>
    System,
    /// <summary>
    /// System borderless style with DWM
    /// </summary>
    SystemBorderless,
    /// <summary>
    /// Customable borderless window style
    /// </summary>
    Borderless,
    /// <summary>
    /// Fullscreen style
    /// </summary>
    Kiosk,
    /// <summary>
    /// Layerd window style
    /// </summary>
    Layered,
    ///// <summary>
    ///// Acrylic background style
    ///// </summary>
    //Acrylic,
    /// <summary>
    /// Use your own window style
    /// </summary>
    Custom
}



public interface IFormiumHostWindow
{

    WindowMessageDelegate OnWindowsMessage { get; set; }

    WindowMessageDelegate OnDefWindowsMessage { get; set; }

    HitTestValues HitTest(Point point);

}
