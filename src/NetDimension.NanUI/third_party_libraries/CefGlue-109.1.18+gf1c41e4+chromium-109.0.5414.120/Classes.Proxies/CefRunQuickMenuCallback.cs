namespace Xilium.CefGlue
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using Xilium.CefGlue.Interop;
    
    /// <summary>
    /// Callback interface used for continuation of custom quick menu display.
    /// </summary>
    public sealed unsafe partial class CefRunQuickMenuCallback
    {
        /// <summary>
        /// Complete quick menu display by selecting the specified |command_id| and
        /// |event_flags|.
        /// </summary>
        public void Continue(int commandId, CefEventFlags eventFlags)
        {
            cef_run_quick_menu_callback_t.cont(_self, commandId, eventFlags);
        }

        /// <summary>
        /// Cancel quick menu display.
        /// </summary>
        public void Cancel()
        {
            cef_run_quick_menu_callback_t.cancel(_self);
        }
    }
}
