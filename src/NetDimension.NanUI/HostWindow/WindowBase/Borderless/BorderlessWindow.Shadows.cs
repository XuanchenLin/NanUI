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
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            PerformShadows(true);

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

            if(_shadowDecorator!=null && !_shadowDecorator.IsEnabled && MinMaxState == FormWindowState.Normal)
            {
                PerformShadows(true);
            }
        }

        private void PerformShadows(bool enabled)
        {
            if (_shadowDecorator == null )
                return;

            if(ShadowEffect == ShadowEffect.None)
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

            if (!IsMdiChild && FormBorderStyle != FormBorderStyle.None && Parent == null)
            {
                _shadowDecorator.InitializeShadows();

                if (Owner != null)
                {
                    _shadowDecorator.SetOwner(Owner.Handle);
                }

            }
        }
    }
}
