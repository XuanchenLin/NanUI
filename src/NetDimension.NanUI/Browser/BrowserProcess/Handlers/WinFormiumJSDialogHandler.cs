using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser
{
    internal sealed class WinFormiumJSDialogHandler : CefJSDialogHandler
    {
        private readonly Formium _owner;

        public WinFormiumJSDialogHandler(Formium owner)
        {
            _owner = owner;
        }

        protected override bool OnBeforeUnloadDialog(CefBrowser browser, string messageText, bool isReload, CefJSDialogCallback callback)
        {
            
            return false;
        }

        protected override void OnDialogClosed(CefBrowser browser)
        {
            
        }

        protected override bool OnJSDialog(CefBrowser browser, string originUrl, CefJSDialogType dialogType, string message_text, string default_prompt_text, CefJSDialogCallback callback, out bool suppress_message)
        {
            


            switch (dialogType)
            {
                case CefJSDialogType.Alert:
                    _owner.InvokeIfRequired(() =>
                    {

                        MessageBox.Show(_owner.HostWindow, message_text, Resources.Messages.JSDialog_AlertDialog_Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        callback.Continue(true, null);

                    });

                    suppress_message = false;
                    return true;
                case CefJSDialogType.Confirm:
                    _owner.InvokeIfRequired(() =>
                    {

                        var retval = MessageBox.Show(_owner.HostWindow, message_text, Resources.Messages.JSDialog_AlertDialog_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if(retval == DialogResult.Yes)
                        {
                            callback.Continue(true, null);
                        }
                        else
                        {
                            callback.Continue(false, null);
                        }

                    });


                    suppress_message = false;
                    return true;
            }

            suppress_message = false;
            return false;
        }

        protected override void OnResetDialogState(CefBrowser browser)
        {
            
        }
    }
}
