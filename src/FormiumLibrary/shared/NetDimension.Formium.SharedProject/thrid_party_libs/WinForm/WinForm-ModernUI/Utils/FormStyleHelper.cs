using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetDimension.WinForm
{
    public static class FormStyleHelper
    {
        public static bool IsWindows8OrLower
        {
            get { return (Environment.OSVersion.Version.Major < 6 || (Environment.OSVersion.Version.Major == 6 && Environment.Version.Minor < 3)); }
        }

        public static bool IsWindows81OrHigher
        {
            get { return (Environment.OSVersion.Version.Major >= 6 || (Environment.OSVersion.Version.Major == 6 && Environment.Version.Minor >= 3)); }
        }

        /// <summary>
        /// Gets the size of the borders requested by the real window.
        /// </summary>
        /// <param name="cp">Window style parameters.</param>
        /// <returns>Border sizing.</returns>
        public static Padding GetWindowBorders(CreateParams cp)
        {
            RECT rect = new RECT();

            // Start with a zero sized rectangle
            rect.left = 0;
            rect.right = 0;
            rect.top = 0;
            rect.bottom = 0;


            // Adjust rectangle to add on the borders required
            User32.AdjustWindowRectEx(ref rect, cp.Style, false, cp.ExStyle);

            // Return the per side border values
            return new Padding(-rect.left, -rect.top, rect.right, rect.bottom);
        }

        public static Size ScaleSize(Size value, SizeF scaleFactor)
        {
            return new Size(
                (int)Math.Round(value.Width * scaleFactor.Width, MidpointRounding.AwayFromZero),
                (int)Math.Round(value.Height * scaleFactor.Height, MidpointRounding.AwayFromZero));
        }

        /// <summary>
        /// Discover if the provided Form is currently maximized.
        /// </summary>
        /// <param name="f">Form reference.</param>
        /// <returns>True if maximized; otherwise false.</returns>
        public static bool IsFormMaximized(Form f)
        {
            // Get the current window style (cannot use the 
            // WindowState property as it can be slightly out of date)
            uint style = User32.GetWindowLong(f.Handle, GetWindowLongFlags.GWL_STYLE);

            return ((style &= (uint)WindowStyles.WS_MAXIMIZE) != 0);
        }


        /// <summary>
        /// Discover if the provided Form is currently minimized.
        /// </summary>
        /// <param name="f">Form reference.</param>
        /// <returns>True if minimized; otherwise false.</returns>
        public static bool IsFormMinimized(Form f)
        {
            // Get the current window style (cannot use the 
            // WindowState property as it can be slightly out of date)
            uint style = User32.GetWindowLong(f.Handle, GetWindowLongFlags.GWL_STYLE);

            return ((style &= (uint)WindowStyles.WS_MINIMIZE) != 0);
        }

        /// <summary>
        /// Gets the real client rectangle of the list.
        /// </summary>
        /// <param name="handle">Window handle of the control.</param>
        public static Rectangle RealClientRectangle(IntPtr handle)
        {
            // Grab the actual current size of the window, this is more accurate than using
            // the 'this.Size' which is out of date when performing a resize of the window.
            RECT windowRect = new RECT();
            User32.GetWindowRect(handle, ref windowRect);

            // Create rectangle that encloses the entire window
            return new Rectangle(0, 0,
                                 windowRect.right - windowRect.left,
                                 windowRect.bottom - windowRect.top);
        }


    }
}
