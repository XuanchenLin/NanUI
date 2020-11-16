using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetDimension.NanUI.HostWindow
{
    internal partial class FakeClassToDisableWinFormDesigner
    {

    }
    partial class BorderlessWindow
    {

        private bool _isShown = false;

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (_shadowDecorator != null && !_shadowDecorator.IsEnabled && MinMaxState == FormWindowState.Normal)
            {
                PerformShadows(true);
            }
            else if (_shadowDecorator != null && MinMaxState != FormWindowState.Normal)
            {
                PerformShadows(false);
            }

            _isShown = true;

        }

        protected bool IsResizing { get; set; } = false;

        protected override void OnResizeBegin(EventArgs e)
        {
            base.OnResizeBegin(e);

            IsResizing = true;
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);

            IsResizing = false;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (_isShown)
            {
                if (_shadowDecorator != null && !_shadowDecorator.IsEnabled && MinMaxState == FormWindowState.Normal)
                {
                    PerformShadows(true);
                }
                else if (_shadowDecorator != null && _shadowDecorator.IsEnabled && MinMaxState != FormWindowState.Normal)
                {
                    PerformShadows(false);
                }
            }
        }

        private void PerformShadows(bool enabled)
        {
            if (_shadowDecorator == null)
                return;

            if (ShadowEffect == ShadowEffect.None)
            {
                _shadowDecorator.Enable(false);

                return;

            }

            _shadowDecorator.Enable(enabled);

            if (IsWindowActivatedCore && enabled)
            {
                _shadowDecorator.SetFocus();
            }
        }



        private void UpdateShadows()
        {
            if (DesignMode || _shadowDecorator == null)
            {
                return;
            }

            if (!IsMdiChild && FormBorderStyle != FormBorderStyle.None)
            {
                _shadowDecorator.InitializeShadows();


                if (Owner != null)
                {
                    _shadowDecorator.SetOwner(Owner.Handle);
                }
                //else
                //{
                //    _shadowDecorator.SetOwner(Handle);
                //}



            }
        }
    }
}
