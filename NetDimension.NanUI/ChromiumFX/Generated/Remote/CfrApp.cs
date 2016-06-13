// Copyright (c) 2014-2015 Wolfgang Borgsmüller
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
// 1. Redistributions of source code must retain the above copyright 
//    notice, this list of conditions and the following disclaimer.
// 
// 2. Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution.
// 
// 3. Neither the name of the copyright holder nor the names of its 
//    contributors may be used to endorse or promote products derived 
//    from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS 
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS 
// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE 
// COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS 
// OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND 
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR 
// TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote
{
	using Event;

	/// <summary>
	/// Implement this structure to provide handler implementations. Methods will be
	/// called by the process and/or thread indicated.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
	/// </remarks>
	public class CfrApp : CfrBase {

        internal static CfrApp Wrap(IntPtr proxyId) {
            if(proxyId == IntPtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            lock(weakCache) {
                var cfrObj = (CfrApp)weakCache.Get(proxyId);
                if(cfrObj == null) {
                    cfrObj = new CfrApp(proxyId);
                    weakCache.Add(proxyId, cfrObj);
                }
                return cfrObj;
            }
        }


        internal static IntPtr CreateRemote() {
            var call = new CfxAppCtorRenderProcessCall();
            call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
            return call.__retval;
        }

        internal void raise_OnBeforeCommandLineProcessing(object sender, CfrOnBeforeCommandLineProcessingEventArgs e) {
            var handler = m_OnBeforeCommandLineProcessing;
            if(handler == null) return;
            handler(this, e);
            e.m_isInvalid = true;
        }

        internal void raise_OnRegisterCustomSchemes(object sender, CfrOnRegisterCustomSchemesEventArgs e) {
            var handler = m_OnRegisterCustomSchemes;
            if(handler == null) return;
            handler(this, e);
            e.m_isInvalid = true;
        }

        internal void raise_GetResourceBundleHandler(object sender, CfrGetResourceBundleHandlerEventArgs e) {
            var handler = m_GetResourceBundleHandler;
            if(handler == null) return;
            handler(this, e);
            e.m_isInvalid = true;
        }

        internal void raise_GetRenderProcessHandler(object sender, CfrGetRenderProcessHandlerEventArgs e) {
            var handler = m_GetRenderProcessHandler;
            if(handler == null) return;
            handler(this, e);
            e.m_isInvalid = true;
        }


        private CfrApp(IntPtr proxyId) : base(proxyId) {}
        public CfrApp() : base(CreateRemote()) {
            connection.weakCache.Add(proxyId, this);
        }

        /// <summary>
        /// Provides an opportunity to view and/or modify command-line arguments before
        /// processing by CEF and Chromium. The |ProcessType| value will be NULL for
        /// the browser process. Do not keep a reference to the CfrCommandLine
        /// object passed to this function. The CfrSettings.CommandLineArgsDisabled
        /// value can be used to start with an NULL command-line object. Any values
        /// specified in CfrSettings that equate to command-line arguments will be set
        /// before this function is called. Be cautious when using this function to
        /// modify command-line arguments for non-browser processes as this may result
        /// in undefined behavior including crashes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public event CfrOnBeforeCommandLineProcessingEventHandler OnBeforeCommandLineProcessing {
            add {
                if(m_OnBeforeCommandLineProcessing == null) {
                    var call = new CfxOnBeforeCommandLineProcessingActivateRenderProcessCall();
                    call.sender = proxyId;
                    call.RequestExecution(this);
                }
                m_OnBeforeCommandLineProcessing += value;
            }
            remove {
                m_OnBeforeCommandLineProcessing -= value;
                if(m_OnBeforeCommandLineProcessing == null) {
                    var call = new CfxOnBeforeCommandLineProcessingDeactivateRenderProcessCall();
                    call.sender = proxyId;
                    call.RequestExecution(this);
                }
            }
        }

        CfrOnBeforeCommandLineProcessingEventHandler m_OnBeforeCommandLineProcessing;


        /// <summary>
        /// Provides an opportunity to register custom schemes. Do not keep a reference
        /// to the |Registrar| object. This function is called on the main thread for
        /// each process and the registered schemes should be the same across all
        /// processes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public event CfrOnRegisterCustomSchemesEventHandler OnRegisterCustomSchemes {
            add {
                if(m_OnRegisterCustomSchemes == null) {
                    var call = new CfxOnRegisterCustomSchemesActivateRenderProcessCall();
                    call.sender = proxyId;
                    call.RequestExecution(this);
                }
                m_OnRegisterCustomSchemes += value;
            }
            remove {
                m_OnRegisterCustomSchemes -= value;
                if(m_OnRegisterCustomSchemes == null) {
                    var call = new CfxOnRegisterCustomSchemesDeactivateRenderProcessCall();
                    call.sender = proxyId;
                    call.RequestExecution(this);
                }
            }
        }

        CfrOnRegisterCustomSchemesEventHandler m_OnRegisterCustomSchemes;


        /// <summary>
        /// Return the handler for resource bundle events. If
        /// CfrSettings.PackLoadingDisabled is true (1) a handler must be returned.
        /// If no handler is returned resources will be loaded from pack files. This
        /// function is called by the browser and render processes on multiple threads.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public event CfrGetResourceBundleHandlerEventHandler GetResourceBundleHandler {
            add {
                if(m_GetResourceBundleHandler == null) {
                    var call = new CfxGetResourceBundleHandlerActivateRenderProcessCall();
                    call.sender = proxyId;
                    call.RequestExecution(this);
                }
                m_GetResourceBundleHandler += value;
            }
            remove {
                m_GetResourceBundleHandler -= value;
                if(m_GetResourceBundleHandler == null) {
                    var call = new CfxGetResourceBundleHandlerDeactivateRenderProcessCall();
                    call.sender = proxyId;
                    call.RequestExecution(this);
                }
            }
        }

        CfrGetResourceBundleHandlerEventHandler m_GetResourceBundleHandler;


        /// <summary>
        /// Return the handler for functionality specific to the render process. This
        /// function is called on the render process main thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public event CfrGetRenderProcessHandlerEventHandler GetRenderProcessHandler {
            add {
                if(m_GetRenderProcessHandler == null) {
                    var call = new CfxGetRenderProcessHandlerActivateRenderProcessCall();
                    call.sender = proxyId;
                    call.RequestExecution(this);
                }
                m_GetRenderProcessHandler += value;
            }
            remove {
                m_GetRenderProcessHandler -= value;
                if(m_GetRenderProcessHandler == null) {
                    var call = new CfxGetRenderProcessHandlerDeactivateRenderProcessCall();
                    call.sender = proxyId;
                    call.RequestExecution(this);
                }
            }
        }

        CfrGetRenderProcessHandlerEventHandler m_GetRenderProcessHandler;


        internal override void OnDispose(IntPtr proxyId) {
            connection.weakCache.Remove(proxyId);
        }
    }

    namespace Event
	{

		/// <summary>
		/// Provides an opportunity to view and/or modify command-line arguments before
		/// processing by CEF and Chromium. The |ProcessType| value will be NULL for
		/// the browser process. Do not keep a reference to the CfrCommandLine
		/// object passed to this function. The CfrSettings.CommandLineArgsDisabled
		/// value can be used to start with an NULL command-line object. Any values
		/// specified in CfrSettings that equate to command-line arguments will be set
		/// before this function is called. Be cautious when using this function to
		/// modify command-line arguments for non-browser processes as this may result
		/// in undefined behavior including crashes.
		/// </summary>
		/// <remarks>
		/// See also the original CEF documentation in
		/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
		/// </remarks>
		public delegate void CfrOnBeforeCommandLineProcessingEventHandler(object sender, CfrOnBeforeCommandLineProcessingEventArgs e);

        /// <summary>
        /// Provides an opportunity to view and/or modify command-line arguments before
        /// processing by CEF and Chromium. The |ProcessType| value will be NULL for
        /// the browser process. Do not keep a reference to the CfrCommandLine
        /// object passed to this function. The CfrSettings.CommandLineArgsDisabled
        /// value can be used to start with an NULL command-line object. Any values
        /// specified in CfrSettings that equate to command-line arguments will be set
        /// before this function is called. Be cautious when using this function to
        /// modify command-line arguments for non-browser processes as this may result
        /// in undefined behavior including crashes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public class CfrOnBeforeCommandLineProcessingEventArgs : CfrEventArgs {

            bool ProcessTypeFetched;
            string m_ProcessType;
            bool CommandLineFetched;
            CfrCommandLine m_CommandLine;

            internal CfrOnBeforeCommandLineProcessingEventArgs(ulong eventArgsId) : base(eventArgsId) {}

            /// <summary>
            /// Get the ProcessType parameter for the <see cref="CfrApp.OnBeforeCommandLineProcessing"/> render process callback.
            /// </summary>
            public string ProcessType {
                get {
                    CheckAccess();
                    if(!ProcessTypeFetched) {
                        ProcessTypeFetched = true;
                        var call = new CfxOnBeforeCommandLineProcessingGetProcessTypeRenderProcessCall();
                        call.eventArgsId = eventArgsId;
                        call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                        m_ProcessType = call.value;
                    }
                    return m_ProcessType;
                }
            }
            /// <summary>
            /// Get the CommandLine parameter for the <see cref="CfrApp.OnBeforeCommandLineProcessing"/> render process callback.
            /// </summary>
            public CfrCommandLine CommandLine {
                get {
                    CheckAccess();
                    if(!CommandLineFetched) {
                        CommandLineFetched = true;
                        var call = new CfxOnBeforeCommandLineProcessingGetCommandLineRenderProcessCall();
                        call.eventArgsId = eventArgsId;
                        call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                        m_CommandLine = CfrCommandLine.Wrap(call.value);
                    }
                    return m_CommandLine;
                }
            }

            public override string ToString() {
                return String.Format("ProcessType={{{0}}}, CommandLine={{{1}}}", ProcessType, CommandLine);
            }
        }

        /// <summary>
        /// Provides an opportunity to register custom schemes. Do not keep a reference
        /// to the |Registrar| object. This function is called on the main thread for
        /// each process and the registered schemes should be the same across all
        /// processes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public delegate void CfrOnRegisterCustomSchemesEventHandler(object sender, CfrOnRegisterCustomSchemesEventArgs e);

        /// <summary>
        /// Provides an opportunity to register custom schemes. Do not keep a reference
        /// to the |Registrar| object. This function is called on the main thread for
        /// each process and the registered schemes should be the same across all
        /// processes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public class CfrOnRegisterCustomSchemesEventArgs : CfrEventArgs {

            bool RegistrarFetched;
            CfrSchemeRegistrar m_Registrar;

            internal CfrOnRegisterCustomSchemesEventArgs(ulong eventArgsId) : base(eventArgsId) {}

            /// <summary>
            /// Get the Registrar parameter for the <see cref="CfrApp.OnRegisterCustomSchemes"/> render process callback.
            /// </summary>
            public CfrSchemeRegistrar Registrar {
                get {
                    CheckAccess();
                    if(!RegistrarFetched) {
                        RegistrarFetched = true;
                        var call = new CfxOnRegisterCustomSchemesGetRegistrarRenderProcessCall();
                        call.eventArgsId = eventArgsId;
                        call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                        m_Registrar = CfrSchemeRegistrar.Wrap(call.value);
                    }
                    return m_Registrar;
                }
            }

            public override string ToString() {
                return String.Format("Registrar={{{0}}}", Registrar);
            }
        }

        /// <summary>
        /// Return the handler for resource bundle events. If
        /// CfrSettings.PackLoadingDisabled is true (1) a handler must be returned.
        /// If no handler is returned resources will be loaded from pack files. This
        /// function is called by the browser and render processes on multiple threads.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public delegate void CfrGetResourceBundleHandlerEventHandler(object sender, CfrGetResourceBundleHandlerEventArgs e);

        /// <summary>
        /// Return the handler for resource bundle events. If
        /// CfrSettings.PackLoadingDisabled is true (1) a handler must be returned.
        /// If no handler is returned resources will be loaded from pack files. This
        /// function is called by the browser and render processes on multiple threads.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public class CfrGetResourceBundleHandlerEventArgs : CfrEventArgs {


            private bool returnValueSet;

            internal CfrGetResourceBundleHandlerEventArgs(ulong eventArgsId) : base(eventArgsId) {}

            /// <summary>
            /// Set the return value for the <see cref="CfrApp.GetResourceBundleHandler"/> render process callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfrResourceBundleHandler returnValue) {
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                var call = new CfxGetResourceBundleHandlerSetReturnValueRenderProcessCall();
                call.eventArgsId = eventArgsId;
                call.value = CfrObject.Unwrap(returnValue);
                call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                returnValueSet = true;
            }
        }

        /// <summary>
        /// Return the handler for functionality specific to the render process. This
        /// function is called on the render process main thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public delegate void CfrGetRenderProcessHandlerEventHandler(object sender, CfrGetRenderProcessHandlerEventArgs e);

        /// <summary>
        /// Return the handler for functionality specific to the render process. This
        /// function is called on the render process main thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public class CfrGetRenderProcessHandlerEventArgs : CfrEventArgs {


            private bool returnValueSet;

            internal CfrGetRenderProcessHandlerEventArgs(ulong eventArgsId) : base(eventArgsId) {}

            /// <summary>
            /// Set the return value for the <see cref="CfrApp.GetRenderProcessHandler"/> render process callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfrRenderProcessHandler returnValue) {
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                var call = new CfxGetRenderProcessHandlerSetReturnValueRenderProcessCall();
                call.eventArgsId = eventArgsId;
                call.value = CfrObject.Unwrap(returnValue);
                call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                returnValueSet = true;
            }
        }

    }
}
