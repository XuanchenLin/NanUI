using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace NetDimension.WinForm
{
    public class ModernUIForm : FormChrome
    {

        

        #region Extended Methods

        [DllImport("USER32.dll")]
        private static extern bool DestroyMenu(IntPtr menu);
        [DllImport("user32.dll", EntryPoint = "GetSystemMenu")]
        private static extern IntPtr GetSystemMenuCore(IntPtr hWnd, bool bRevert);
        [System.Security.SecuritySafeCritical]
        internal static IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert)
        {
            return GetSystemMenuCore(hWnd, bRevert);
        }

        protected bool ShowSystemMenu(Form frm, Point pt)
        {
            const int TPM_LEFTALIGN = 0x0000, TPM_TOPALIGN = 0x0000, TPM_RETURNCMD = 0x0100;
            if (frm == null)
                return false;
            IntPtr menuHandle = GetSystemMenu(frm.Handle, false);
            IntPtr command = User32.TrackPopupMenu(menuHandle, TPM_RETURNCMD | TPM_TOPALIGN | TPM_LEFTALIGN, pt.X, pt.Y, 0, frm.Handle, IntPtr.Zero);
            if (frm.IsDisposed)
                return false;
            User32.PostMessage(frm.Handle, (uint)WindowsMessages.WM_SYSCOMMAND, command, IntPtr.Zero);
            return true;
        }
        #endregion

        #region Dialog
        public new DialogResult ShowDialog(IWin32Window owner)
        {
            return base.ShowDialog(CheckOwner(owner));
        }
        static IWin32Window CheckOwner(IWin32Window owner)
        {
            var form = owner as ModernUIForm;
            if (form != null)
            {
                if (form.Location == InvalidPoint)
                {
                    return form.OwnedForms.FirstOrDefault(x => IsAppropriateOwner(x));
                }
            }
            return owner;
        }
        static bool IsAppropriateOwner(Form condidateForm)
        {
            return true;
        }
        #endregion

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SizeF FormDpiScaleFactor => DpiScaleFactor;
    }
}
