using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NetDimension.NanUI.HostWindow
{

    internal partial class FakeClassToDisableWinFormDesigner
    {

    }

    partial class BorderlessWindow
    {
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal protected new AutoScaleMode AutoScaleMode => AutoScaleMode.None;
        internal ShadowDecorator _shadowDecorator;

        public BorderlessWindow()
        {
            base.AutoScaleMode = AutoScaleMode.None;

            base.BackColor = Color.FromArgb(33,33,33);

            DpiHelper.InitializeDpiHelper();

            InitializeReflectedFields();

            _deviceDpi = DpiHelper.DeviceDpi;



            _shadowDecorator = new ShadowDecorator(this, false);

            SuspendLayout();
        }



        protected override void OnHandleCreated(EventArgs e)
        {

            try
            {
                UxTheme.SetWindowTheme(Handle, string.Empty, string.Empty);
                User32.DisableProcessWindowsGhosting();

                ScaleFactor = DpiHelper.GetScaleFactorForCurrentWindow(Handle);


            }
            catch { }

            base.OnHandleCreated(e);

            CheckResetDPIAutoScale(true);

            ResumeLayout();
        }



        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (!DesignMode)
            {
                if (ScaleFactor != 1.0f)
                {
                    Scale(new SizeF(ScaleFactor, ScaleFactor));
                }

                var currentScreenScaleFactor = DpiHelper.GetScaleFactorForCurrentWindow(Handle);

                var primaryScreenScaleFactor = DpiHelper.GetScreenDpi(Screen.PrimaryScreen) / 96f;

                if (primaryScreenScaleFactor != 1.0f)
                {
                    Font = new Font(Font.FontFamily, (float)Math.Round(Font.Size / primaryScreenScaleFactor), Font.Style);
                }

                Font = new Font(Font.FontFamily, (float)Math.Round(Font.Size * currentScreenScaleFactor), Font.Style);

                CorrectFormPostion();

                UpdateShadows();

            }

            _isLoaded = true;

        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            IsWindowActivated = true;
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);

            IsWindowActivated = false;
        }



        protected override Rectangle GetScaledBounds(Rectangle bounds, SizeF factor, BoundsSpecified specified)
        {

            var rect = base.GetScaledBounds(bounds, factor, specified);

            Size sz = SizeFromClientSize(Size.Empty);
            if (!GetStyle(ControlStyles.FixedWidth) && ((specified & BoundsSpecified.Width) != BoundsSpecified.None))
            {
                int clientWidth = bounds.Width - sz.Width;
                rect.Width = ((int)Math.Round((double)(clientWidth * factor.Width))) + sz.Width;
            }
            if (!GetStyle(ControlStyles.FixedHeight) && ((specified & BoundsSpecified.Height) != BoundsSpecified.None))
            {
                int clientHeight = bounds.Height - sz.Height;
                rect.Height = ((int)Math.Round((double)(clientHeight * factor.Height))) + sz.Height;
            }

            return rect;
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {

            if (!_allowBoundsChange)
            {
                return;
            }

            if (DesignMode)
            {
                base.SetBoundsCore(x, y, width, height, specified);

                return;
            }

            if (_isMaximizedTest && WindowState != FormWindowState.Minimized)
            {
                if (y != Top)
                {
                    y = Top;

                }

                if (x != Left)
                {
                    x = Left;
                }

                _isMaximizedTest = false;
            }

            var size = PatchFormSizeInRestoreWindowBoundsIfNecessary(width, height);

            base.SetBoundsCore(x, y, size.Width, size.Height, specified);
        }

        Size startupSize = Size.Empty;


        protected override void SetClientSizeCore(int x, int y)
        {

            if (_clientWidthField != null && _clientHeightField != null && _formStateField != null && _formStateSetClientSizeField != null)
            {

                _clientWidthField.SetValue(this, x);
                _clientHeightField.SetValue(this, y);

                BitVector32.Section section = (BitVector32.Section)_formStateSetClientSizeField.GetValue(this);

                var vector = (BitVector32)_formStateField.GetValue(this);

                vector[section] = 1;

                _formStateField.SetValue(this, vector);

                OnClientSizeChanged(EventArgs.Empty);

                vector[section] = 0;

                _formStateField.SetValue(this, vector);

                Size = SizeFromClientSize(new Size(x, y));

                //Size = new Size(x, y);

                if (startupSize == Size.Empty)
                {
                    startupSize = Size;
                }

            }
            else
            {
                base.SetClientSizeCore(x, y);
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            _shadowDecorator.Dispose();
            base.OnClosed(e);
        }

        protected override Size SizeFromClientSize(Size clientSize)
        {
            //TODO:修理一下边框的大小

            if (BorderEffect == BorderEffect.BorderLine)
            {
                clientSize.Width += FormBorders.Horizontal;
                clientSize.Height += FormBorders.Vertical;

            }

            return clientSize;
        }

        protected override void OnSizeChanged(EventArgs e)
        {


            PatchClientSize();

            base.OnSizeChanged(e);
        }

        


        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            var maxSizeState = MaximumSize;
            var minSizeState = MinimumSize;

            MinimumSize = Size.Empty;
            MaximumSize = Size.Empty;

            base.ScaleControl(factor, specified);


            if (minSizeState != Size.Empty)
            {
                minSizeState = new Size((int)Math.Round(minSizeState.Width * factor.Width), (int)Math.Round(minSizeState.Height * factor.Height));
            }
            if (maxSizeState != Size.Empty)
            {
                maxSizeState = new Size((int)Math.Round(maxSizeState.Width * factor.Width), (int)Math.Round(maxSizeState.Height * factor.Height));
            }

            MinimumSize = minSizeState;
            MaximumSize = maxSizeState;

        }







    }
}
