// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using static Vanara.PInvoke.User32;



namespace NetDimension.NanUI.Forms;
internal sealed class WindowShadowDecorator : NativeWindow, IDisposable
{

    readonly Dictionary<ShadowEffect, ShadowEffectConfiguration> ShadowEffectConfiguration = new Dictionary<ShadowEffect, ShadowEffectConfiguration>()
    {
        [ShadowEffect.None] = new ShadowEffectConfiguration { OffsetX = 0, OffsetY = 0, Blur = 0 },
        [ShadowEffect.Glow] = new ShadowEffectConfiguration { OffsetX = 0, OffsetY = 0, Blur = 4 },
        [ShadowEffect.Small] = new ShadowEffectConfiguration { OffsetX = 1, OffsetY = 1, Blur = 7 },
        [ShadowEffect.Normal] = new ShadowEffectConfiguration { OffsetX = 1, OffsetY = 4, Blur = 10 },
        [ShadowEffect.Big] = new ShadowEffectConfiguration { OffsetX = 2, OffsetY = 4, Blur = 15 },
        [ShadowEffect.Huge] = new ShadowEffectConfiguration { OffsetX = 3, OffsetY = 5, Blur = 20 },
        [ShadowEffect.DropShadow] = new ShadowEffectConfiguration { OffsetX = 5, OffsetY = 15, Blur = 25 },
    };

    const int AcSrcOver = 0x00;
    const int AcSrcAlpha = 0x01;
    internal BLENDFUNCTION DefaultBlendFunciton { get; } = new BLENDFUNCTION
    {
        AlphaFormat = AcSrcAlpha,
        BlendOp = AcSrcOver,
        SourceConstantAlpha = 0xff,
        BlendFlags = 0x00
    };

    private ShadowEffect _shadowEffcet = ShadowEffect.DropShadow;

    private Color _shadowActiveColor = ColorTranslator.FromHtml("#99303030");

    private Color? _shadowInactiveColor = null;

    private bool _isShadowInitialized = false;

    private bool _isShadowEnabled = false;




    private FormWindowState? _lastWindowState = null;

    private ShadowElementState? _lastShadowState = null;

    private List<ShadowElementWindow> ShadowElements { get; } = new List<ShadowElementWindow>();


    private ShadowElementWindow? _topElementWindow;
    private ShadowElementWindow? _rightElementWindow;
    private ShadowElementWindow? _bottomElmentWindow;
    private ShadowElementWindow? _leftElementWindow;


    private bool IsShadowShownWithWindow => _lastWindowState.HasValue;

    private CancellationTokenSource _shadowCancellationSource = new CancellationTokenSource();


    public bool IsVisible { get; private set; }

    public ShadowElementRender? ShadowElementRender { get; private set; }

    public Color ShadowActiveColor
    {
        get => _shadowActiveColor;
        set
        {
            if (value != _shadowActiveColor)
            {
                _shadowActiveColor = value;

                if (_isShadowInitialized) CreateShadowElementRender();
            }
        }
    }

    public Color ShadowInactiveColor
    {
        get => _shadowInactiveColor ?? Color.FromArgb(Convert.ToByte(_shadowActiveColor.A * 0.6f), _shadowActiveColor);
        set
        {
            if (value != _shadowInactiveColor)
            {


                _shadowInactiveColor = value;

                if (_shadowInactiveColor == Color.Transparent)
                {
                    _shadowInactiveColor = null;
                }

                if (_isShadowInitialized) CreateShadowElementRender();
            }
        }
    }

    public ShadowEffect WindowShadowEffect
    {
        get => _shadowEffcet;
        set
        {
            if (value != _shadowEffcet)
            {
                _shadowEffcet = value;

                if (_isShadowInitialized) CreateShadowElementRender();
            }
        }
    }

    public FramelessWindowBase TargetWindow { get; }

    public Form? TargetWindowOwner => TargetWindow!.Owner;

    public HWND WND { get; private set; }

    public ShadowEffectConfiguration ShadowElementConfiguration => ShadowEffectConfiguration[WindowShadowEffect];

    public WindowShadowDecorator(FramelessWindowBase targetWindow)
    {
        TargetWindow = targetWindow;

        RegisterTargetWindowEvents();
    }

    public void EnableShadow(bool enable)
    {

        if (enable)
        {
            _isShadowEnabled = true;
            if (_lastShadowState != null)
            {
                UpdateShadowElements(true);
            }
            else
            {
                UpdateShadowElements(true, true, 100);
            }
        }
        else
        {
            UpdateShadowElements(false);
            _isShadowEnabled = false;
        }
    }

    public void UpdateZOrder(bool updateOwner = false)
    {
        if (!_isShadowInitialized || !IsVisible) return;

        foreach (var element in ShadowElements)
        {
            element.UpdateZOrder();
        }

        if (TargetWindow.Owner != null && updateOwner)
        {

            if (TargetWindow.Owner is WindowBorderlessForm)
            {
                var owner = TargetWindow.Owner as WindowBorderlessForm;

                owner?.ShadowDecorator.UpdateZOrder(false);
            }
        }
    }

    #region TargetWindow Events
    private void RegisterTargetWindowEvents()
    {
        TargetWindow.HandleCreated += TargetWindow_HandleCreated;
        TargetWindow.HandleDestroyed += TargetWindow_HandleDestroyed;
        TargetWindow.Shown += TargetWindow_Shown;
        TargetWindow.WindowStateChanged += TargetWindow_WindowStateChanged;
        TargetWindow.WindowActivated += TargetWindow_WindowActivated;
        TargetWindow.FormClosed += TargetWindow_FormClosed;
    }

    private void UnregisterTargetWindowEvents()
    {
        TargetWindow.FormClosed -= TargetWindow_FormClosed;
        TargetWindow.WindowActivated -= TargetWindow_WindowActivated;
        TargetWindow.WindowStateChanged -= TargetWindow_WindowStateChanged;
        TargetWindow.Shown -= TargetWindow_Shown;
        TargetWindow.HandleDestroyed -= TargetWindow_HandleDestroyed;
        TargetWindow.HandleCreated -= TargetWindow_HandleCreated;
    }

    private void TargetWindow_HandleCreated(object sender, EventArgs e)
    {
        AssignHandle(TargetWindow.Handle);

        WND = new HWND(TargetWindow.Handle);

        CreateShadowElements();
    }

    private void TargetWindow_HandleDestroyed(object sender, EventArgs e)
    {
        ReleaseHandle();
    }

    private void TargetWindow_WindowActivated(object sender, WindowActivatedEventArgs e)
    {
        UpdateZOrder(e.IsActivated);
    }

    private void TargetWindow_WindowStateChanged(object sender, WindowStateChangedEventArgs e)
    {
        if (TargetWindow.WindowState != FormWindowState.Normal)
        {
            _lastWindowState = TargetWindow.WindowState;
        }

        if (e.State == WindowChangeState.Restore)
        {
            if (_lastWindowState != FormWindowState.Normal)
            {
                if (_lastWindowState == null)
                {

                    UpdateShadowElements(true, true, 150);
                }
                else
                {
                    UpdateShadowElements(true, true, 200);

                }
            }
            else
            {
                UpdateShadowElements(true);

            }
        }
        else
        {
            UpdateShadowElements(false);
        }
    }

    private void TargetWindow_Shown(object sender, EventArgs e)
    {
        if (TargetWindow.WindowState == FormWindowState.Normal && WindowShadowEffect != ShadowEffect.None)
        {
            EnableShadow(true);

        }
        else
        {
            EnableShadow(false);
        }
    }

    private void TargetWindow_FormClosed(object sender, FormClosedEventArgs e)
    {
        EnableShadow(false);
    }





    #endregion





    #region ShadowElement operations
    private void SetOwner(HWND owner)
    {
        foreach (var element in ShadowElements)
        {
            element.SetOwner(owner);
        }
    }

    private void CreateShadowElementRender()
    {
        var shadowConfig = ShadowElementConfiguration;

        if (WindowShadowEffect == ShadowEffect.None)
        {
            ShadowElementRender = null;
            return;
        }

        ShadowElementRender = new ShadowElementRender(shadowConfig, ShadowActiveColor, ShadowInactiveColor);

        var setMinWidth = TargetWindow.MinimumSize.Width;
        var setMinHeight = TargetWindow.MinimumSize.Height;

        var templateMinWidth = ShadowElementRender.TemplateBoxSize.Width;
        var templateMinHeight = ShadowElementRender.TemplateBoxSize.Height;

        if (TargetWindow.MinimumSize == Size.Empty || setMinHeight < templateMinHeight && setMinWidth < templateMinWidth)
        {
            TargetWindow.MinimumSize = new Size(templateMinWidth, templateMinHeight);
        }
        else if (setMinHeight < templateMinHeight)
        {
            TargetWindow.MinimumSize = new Size(setMinWidth, templateMinHeight);
        }
        else if (setMinWidth < templateMinWidth)
        {
            TargetWindow.MinimumSize = new Size(templateMinWidth, setMinHeight);
        }

    }

    private void CreateShadowElements()
    {
        CreateShadowElementRender();

        if (_isShadowInitialized) return;

        _topElementWindow = new ShadowElementWindow(ShadowElementPosition.Top, this);
        _rightElementWindow = new ShadowElementWindow(ShadowElementPosition.Right, this);
        _bottomElmentWindow = new ShadowElementWindow(ShadowElementPosition.Bottom, this);
        _leftElementWindow = new ShadowElementWindow(ShadowElementPosition.Left, this);

        ShadowElements.Add(_topElementWindow);
        ShadowElements.Add(_rightElementWindow);
        ShadowElements.Add(_bottomElmentWindow);
        ShadowElements.Add(_leftElementWindow);

        if (TargetWindow.Owner != null)
        {
            SetOwner(TargetWindow.Owner.Handle);
        }


        _isShadowInitialized = true;

    }

    private void DestroyShadowElements()
    {
        foreach (var element in ShadowElements)
        {
            element.Close();
        }
    }

    System.Timers.Timer? _updateZOrderTimer = null;
    private void ShowShadowElements()
    {
        if (!_isShadowInitialized || !_isShadowEnabled) return;

        ShowWindow(_topElementWindow!.WND, ShowWindowCommand.SW_SHOWNOACTIVATE);
        ShowWindow(_rightElementWindow!.WND, ShowWindowCommand.SW_SHOWNOACTIVATE);
        ShowWindow(_bottomElmentWindow!.WND, ShowWindowCommand.SW_SHOWNOACTIVATE);
        ShowWindow(_leftElementWindow!.WND, ShowWindowCommand.SW_SHOWNOACTIVATE);


        if (_updateZOrderTimer != null)
        {
            _updateZOrderTimer.Stop();
            _updateZOrderTimer.Close();
            _updateZOrderTimer.Dispose();
        }

        _updateZOrderTimer = new()
        {
            Interval = 500,
            AutoReset = true,
            Enabled = false
        };

        _updateZOrderTimer.Elapsed += (s, e) =>
        {
            UpdateZOrder();
        };

        _updateZOrderTimer.Start();






        IsVisible = true;
    }

    private void HideShadowElements()
    {
        if (!_isShadowInitialized || !_isShadowEnabled) return;

        _updateZOrderTimer?.Stop();
        _updateZOrderTimer?.Close();

        ShowWindow(_topElementWindow!.WND, ShowWindowCommand.SW_HIDE);
        ShowWindow(_rightElementWindow!.WND, ShowWindowCommand.SW_HIDE);
        ShowWindow(_bottomElmentWindow!.WND, ShowWindowCommand.SW_HIDE);
        ShowWindow(_leftElementWindow!.WND, ShowWindowCommand.SW_HIDE);


        IsVisible = false;
    }

    private bool _isShadowAnimationDelayed = false;
    private bool _isShadowShowing = false;
    private bool _isShadowShown = false;
    private void UpdateShadowElements(bool show, bool delayed = false, int duration = 150)
    {
        if (!_isShadowInitialized) return;

        if (show == _isShadowShown) return;

        if (WindowShadowEffect == ShadowEffect.None) return;

        var shadowCancellation = _shadowCancellationSource.Token;


        void SetShadowVisibleImmediately()
        {
            if (show)
            {
                RefreshShadowElements();

                ShowShadowElements();

                UpdateZOrder();

                RefreshShadowElements();

                _lastWindowState = FormWindowState.Normal;
            }
            else
            {
                HideShadowElements();
            }

            _isShadowShown = show;
        }

        if (_isShadowAnimationDelayed)
        {
            if (show == _isShadowShowing)
            {
                return;
            }
            else
            {
                _shadowCancellationSource.Cancel();
            }
        }



        if (show && delayed)
        {
            _isShadowAnimationDelayed = true;

            _isShadowShowing = show;

            Task.Run(async () =>
            {
                if (shadowCancellation.IsCancellationRequested)
                {
                    if (_isShadowAnimationDelayed)
                    {
                        SetShadowVisibleImmediately();
                    }
                }
                else
                {
                    await Task.Delay(duration);

                    if (_isShadowAnimationDelayed)
                    {
                        SetShadowVisibleImmediately();
                    }
                }

                _isShadowAnimationDelayed = false;


            }, shadowCancellation);
        }
        else
        {
            SetShadowVisibleImmediately();
        }


    }

    private void RefreshShadowElements(RECT? rect = null, bool syncActions = false)
    {

        if (!_isShadowInitialized) return;

        if (!_isShadowEnabled)
            return;

        if (IsIconic(WND) || IsZoomed(WND)) return;




        if (rect == null)
        {
            GetWindowRect(Handle, out var winRect);

            rect = winRect;
        }

        var windowRect = rect!.Value;

        var state = new ShadowElementState
        {
            Width = windowRect.Width,
            Height = windowRect.Height,
            IsActive = TargetWindow.IsWindowActivated
        };

        var shouldUpdateBitmap = false;

        if (_lastShadowState == null || _lastShadowState.IsActive != state.IsActive)
        {
            shouldUpdateBitmap = true;
        }



        if (syncActions)
        {
            Parallel.Invoke(
                () => _rightElementWindow!.UpdateBitmap(windowRect, state.IsActive, shouldUpdateBitmap),
                () => _topElementWindow!.UpdateBitmap(windowRect, state.IsActive, shouldUpdateBitmap),
                () => _bottomElmentWindow!.UpdateBitmap(windowRect, state.IsActive, shouldUpdateBitmap),
                () => _leftElementWindow!.UpdateBitmap(windowRect, state.IsActive, shouldUpdateBitmap));
        }
        else
        {
            _rightElementWindow!.UpdateBitmap(windowRect, state.IsActive, shouldUpdateBitmap);
            _topElementWindow!.UpdateBitmap(windowRect, state.IsActive, shouldUpdateBitmap);
            _bottomElmentWindow!.UpdateBitmap(windowRect, state.IsActive, shouldUpdateBitmap);
            _leftElementWindow!.UpdateBitmap(windowRect, state.IsActive, shouldUpdateBitmap);
        }

        _lastShadowState = state;
    }

    #endregion

    private bool _isSizing;

    protected override void WndProc(ref Message m)
    {

        if (!_isShadowEnabled)
        {
            base.WndProc(ref m);

            return;
        }

        var msg = (WindowMessage)m.Msg;

        if (msg == WindowMessage.WM_SHOWWINDOW)
        {
            var isShown = m.WParam != (nint)0;

            if (IsShadowShownWithWindow)
            {
                UpdateShadowElements(isShown);
            }
        }

        if (msg == WindowMessage.WM_WINDOWPOSCHANGED && m.HWnd != (nint)0)
        {
            var windowpos = m.LParam.ToStructure<WINDOWPOS>();

            var rect = new RECT(windowpos.x, windowpos.y, windowpos.x + windowpos.cx, windowpos.y + windowpos.cy);


            if ((windowpos.flags & SetWindowPosFlags.SWP_NOMOVE) != SetWindowPosFlags.SWP_NOMOVE)
            {
                RefreshShadowElements(rect);
            }
            else if ((windowpos.flags & SetWindowPosFlags.SWP_NOSIZE) != SetWindowPosFlags.SWP_NOSIZE)
            {
                RefreshShadowElements(rect, true);
                _isSizing = true;
            }
        }

        if (msg == WindowMessage.WM_ACTIVATEAPP)
        {
            RefreshShadowElements(syncActions: true);
        }

        if (msg == WindowMessage.WM_ACTIVATE)
        {
            RefreshShadowElements(syncActions: true);
            UpdateZOrder();
        }

        if (msg == WindowMessage.WM_ENTERSIZEMOVE)
        {

        }

        if (msg == WindowMessage.WM_EXITSIZEMOVE)
        {
            if (_isSizing)
            {
                System.GC.Collect();

                _isSizing = false;
            }
        }



        base.WndProc(ref m);
    }


    #region IDispose
    bool _isDisposed = false;

    public void Dispose()
    {
        Dispose(true);
        System.GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (_isDisposed) return;


        if (disposing)
        {
            // release unmanaged resources
            DestroyShadowElements();
        }


        UnregisterTargetWindowEvents();

        _isDisposed = true;
    }
    #endregion




}
