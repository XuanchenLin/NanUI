using Chromium;
using Chromium.Remote;
using NetDimension.NanUI.Browser;
using NetDimension.WinForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace NetDimension.NanUI
{

    internal sealed class HostWindowJavascriptExtension : ChromiumExtensionBase
    {
        private readonly Formium hostWindow;

        private Form Container => hostWindow.ContainerForm;
        private IntPtr ContainerHandle { get; }
        public override string DefinitionJavascriptCode => Properties.Resources.HostWindowExtension;


        internal HostWindowJavascriptExtension(Formium hostWindow)
        {
            this.hostWindow = hostWindow;
            ContainerHandle = Container.Handle;
        }

        public override CfrV8Value OnExtensionExecute(string nativeFunctionName, CfrV8Value[] arguments, CfrV8Value @this, ref string exception)
        {
            CfrV8Value retval = null;
            switch (nativeFunctionName)
            {
                case nameof(Minimize):
                    Minimize();
                    break;
                case nameof(Maximize):
                    Maximize();
                    break;
                case nameof(Restore):
                    Restore();
                    break;
                case nameof(Close):
                    Close();
                    break;
                case nameof(SizeTo):

                    if(arguments.Length == 2)
                    {
                        var w = arguments[0].IntValue;
                        var h = arguments[1].IntValue;
                        SizeTo(w, h);
                    }
                    else
                    {
                        exception = "sizeTo should have 2 arguemnts with int value.";
                    }

                    
                    break;
                case nameof(MoveTo):
                    if (arguments.Length == 2)
                    {
                        var x = arguments[0].IntValue;
                        var y = arguments[1].IntValue;
                        MoveTo(x, y);
                    }
                    else
                    {
                        exception = "moveTo should have 2 arguemnts with int value.";
                    }
                    break;
                case nameof(GetHostWindowState):
                    retval = GetHostWindowState();

                    break;
                case nameof(GetHostWindowWidth):
                    retval = GetHostWindowWidth();
                    break;
                case nameof(GetHostWindowHeight):
                    retval = GetHostWindowHeight();
                    break;

            }

            return retval;
        }

        public CfrV8Value GetHostWindowState()
        {
            var windowStateName = Container.WindowState.ToString().ToLower();
            var windowStateCode = (int)Container.WindowState;
            var clientRect = new RECT();

            User32.GetClientRect(ContainerHandle, ref clientRect);

            var retval = CfrV8Value.CreateObject(new CfrV8Accessor());
            var windowState = CfrV8Value.CreateObject(new CfrV8Accessor());



            windowState.SetValue("state", CfrV8Value.CreateString(windowStateName), CfxV8PropertyAttribute.ReadOnly | CfxV8PropertyAttribute.DontDelete);
            windowState.SetValue("code", CfrV8Value.CreateInt(windowStateCode), CfxV8PropertyAttribute.ReadOnly | CfxV8PropertyAttribute.DontDelete);

            retval.SetValue("windowState", windowState, CfxV8PropertyAttribute.ReadOnly | CfxV8PropertyAttribute.DontDelete);

            retval.SetValue("clientWidth", CfrV8Value.CreateInt(clientRect.Width), CfxV8PropertyAttribute.ReadOnly | CfxV8PropertyAttribute.DontDelete);
            retval.SetValue("clientHeight", CfrV8Value.CreateInt(clientRect.Height), CfxV8PropertyAttribute.ReadOnly | CfxV8PropertyAttribute.DontDelete);

            retval.SetValue("width", CfrV8Value.CreateInt(Container.Width), CfxV8PropertyAttribute.ReadOnly | CfxV8PropertyAttribute.DontDelete);
            retval.SetValue("height", CfrV8Value.CreateInt(Container.Height), CfxV8PropertyAttribute.ReadOnly | CfxV8PropertyAttribute.DontDelete);

            return retval;
        }

        public CfrV8Value GetHostWindowWidth()
        {
            return CfrV8Value.CreateInt(Container.Width);
        }

        public CfrV8Value GetHostWindowHeight()
        {
            return CfrV8Value.CreateInt(Container.Height);
        }



        public void SizeTo(int? width, int? height)
        {
            Container.InvokeIfRequired(() =>
            {
                if (width.HasValue && width.Value > 0)
                {
                    Container.Width = width.Value;
                }

                if (height.HasValue && height.Value > 0)
                {
                    Container.Height = height.Value;
                }
            });
        }

        public void MoveTo(int? x, int? y)
        {
            Container.InvokeIfRequired(() =>
            {
                if (x.HasValue)
                {
                    Container.Left = x.Value;

                }

                if (y.HasValue)
                {
                    Container.Top = y.Value;
                }
            });
        }

        public void Minimize()
        {
            Container.InvokeIfRequired(() =>
            {
                Container.WindowState = FormWindowState.Minimized;
            });
        }

        public void Maximize()
        {
            Container.InvokeIfRequired(() =>
            {
                Container.WindowState = Container.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
            });
        }

        public void Restore()
        {
            Container.InvokeIfRequired(() =>
            {
                Container.WindowState = FormWindowState.Normal;
            });
        }

        public void Close()
        {
            if (!Container.IsDisposed)
            {
                Container.InvokeIfRequired(() =>
                {
                    Container.Close();
                });
            }
        }




    }


}
