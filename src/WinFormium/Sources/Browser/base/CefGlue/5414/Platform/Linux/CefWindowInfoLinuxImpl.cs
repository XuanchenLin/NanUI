// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;
using WinFormium.CefGlue.Platform.Windows;

namespace WinFormium.CefGlue.Platform;
internal unsafe sealed class CefWindowInfoLinuxImpl : CefWindowInfo
{
    private cef_window_info_t_linux* _self;

    public CefWindowInfoLinuxImpl()
        : base(true)
    {
        _self = cef_window_info_t_linux.Alloc();
    }

    public CefWindowInfoLinuxImpl(cef_window_info_t* ptr)
        : base(false)
    {
        if (CefRuntime.Platform != CefRuntimePlatform.Linux)
            throw new InvalidOperationException();

        _self = (cef_window_info_t_linux*)ptr;
    }

    internal override cef_window_info_t* GetNativePointer()
    {
        return (cef_window_info_t*)_self;
    }

    protected internal override void DisposeNativePointer()
    {
        cef_window_info_t_linux.Free(_self);
        _self = null;
    }

    public override IntPtr ParentHandle
    {
        get { ThrowIfDisposed(); return _self->parent_window; }
        set { ThrowIfDisposed(); _self->parent_window = value; }
    }

    public override IntPtr Handle
    {
        get { ThrowIfDisposed(); return _self->window; }
        set { ThrowIfDisposed(); _self->window = value; }
    }

    public override string Name
    {
        get { ThrowIfDisposed(); return cef_string_t.ToString(&_self->window_name); }
        set { ThrowIfDisposed(); cef_string_t.Copy(value, &_self->window_name); }
    }

    public override CefRectangle Bounds
    {
        get
        {
            ThrowIfDisposed();
            return new CefRectangle(_self->bounds);
        }
        set
        {
            ThrowIfDisposed();
            _self->bounds = value.AsNative();
        }
    }

    public override WindowStyle Style
    {
        get { return default(WindowStyle); }
        set { }
    }

    public override WindowStyleEx StyleEx
    {
        get { return default(WindowStyleEx); }
        set { }
    }

    public override IntPtr MenuHandle
    {
        get { return default(IntPtr); }
        set { }
    }

    public override bool Hidden
    {
        get { return default(bool); }
        set { }
    }

    public override bool WindowlessRenderingEnabled
    {
        get { ThrowIfDisposed(); return _self->windowless_rendering_enabled != 0; }
        set { ThrowIfDisposed(); _self->windowless_rendering_enabled = value ? 1 : 0; }
    }

    public override bool SharedTextureEnabled
    {
        get { ThrowIfDisposed(); return _self->shared_texture_enabled != 0; }
        set { ThrowIfDisposed(); _self->shared_texture_enabled = value ? 1 : 0; }
    }

    public override bool ExternalBeginFrameEnabled
    {
        get { ThrowIfDisposed(); return _self->external_begin_frame_enabled != 0; }
        set { ThrowIfDisposed(); _self->external_begin_frame_enabled = value ? 1 : 0; }
    }
}
