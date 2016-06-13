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



using System;
namespace Chromium
{
	/// <summary>
	/// Collection of global static CEF functions.
	/// </summary>
	public static partial class CfxRuntime {

        internal static event Action OnCfxShutdown;

        /// <summary>
        /// Set the path to the directory containing the libcef library.
        /// If left blank the default locations are searched.
        /// </summary>
        public static string LibCefDirPath {
            get {
                return CfxApi.libCefDirPath;
            }
            set {
                if(CfxApi.librariesLoaded)
                    throw new CfxException("Unable to change libcfx directory path: library already loaded.");
                CfxApi.libCefDirPath = value;
            }
        }

        /// <summary>
        /// Set the path to the directory containing the libcfx library.
        /// If left blank the default locations are searched.
        /// </summary>
        public static string LibCfxDirPath {
            get {
                return CfxApi.libCfxDirPath;
            }
            set {
                if(CfxApi.librariesLoaded)
                    throw new CfxException("Unable to change libcef directory path: library already loaded.");
                CfxApi.libCfxDirPath = value;
            }
        }

        /// <summary>
        /// True if the native libraries are loaded.
        /// </summary>
        public static bool LibrariesLoaded { get { return CfxApi.librariesLoaded; } }

        /// <summary>
        /// The operating system ChromiumFX is currently running on.
        /// </summary>
        public static CfxPlatformOS PlatformOS {
            get {
                CfxApi.Probe();
                return CfxApi.PlatformOS;
            }
        }

        /// <summary>
        /// The system architecture ChromiumFX is currently running on.
        /// </summary>
        public static CfxPlatformArch PlatformArch {
            get {
                switch(IntPtr.Size) {
                    case 4:
                        return CfxPlatformArch.x86;
                    case 8:
                        return CfxPlatformArch.x64;
                    default:
                        throw new CfxException("Unknown platform architecture.");
                }
            }
        }

        /// <summary>
        /// This function should be called from the application entry point function to
        /// execute a secondary process. It can be used to run secondary processes from
        /// the browser client executable (default behavior) or from a separate
        /// executable specified by the CefSettings.browser_subprocess_path value. If
        /// called for the browser process (identified by no "type" command-line value)
        /// it will return immediately with a value of -1. If called for a recognized
        /// secondary process it will block until the process should exit and then return
        /// the process exit code.
        /// 
        /// If the browser process was initialized with a valid render process startup callback,
        /// the render main thread will be redirected through the remoting interface into the
        /// browser process. The browser process' render process startup callback routine
        /// is then responsible for calling CfrRuntime.ExecuteProcess().
        /// 
        /// The chromium sandbox is currently not supported within ChromiumFX.
        /// </summary>
        public static int ExecuteProcess() {
            return ExecuteProcess(null);
        }

        /// <summary>
        /// This function should be called from the application entry point function to
        /// execute a secondary process. It can be used to run secondary processes from
        /// the browser client executable (default behavior) or from a separate
        /// executable specified by the CefSettings.browser_subprocess_path value. If
        /// called for the browser process (identified by no "type" command-line value)
        /// it will return immediately with a value of -1. If called for a recognized
        /// secondary process it will block until the process should exit and then return
        /// the process exit code. The |application| parameter may be NULL.
        /// 
        /// If the browser process was initialized with a valid render process startup callback,
        /// the render main thread will be redirected through the remoting interface into the
        /// browser process. The browser process' render process startup callback routine
        /// is then responsible for calling CfrRuntime.ExecuteProcess() and the |application|
        /// parameter will be ignored.
        /// 
        /// The chromium sandbox is currently not supported within ChromiumFX.
        /// </summary>
        public static int ExecuteProcess(CfxApp application) {
            
            CfxApi.Probe();

            var cmd = Environment.CommandLine;
            var ex = new System.Text.RegularExpressions.Regex(@"cfxremote=(\w+)");
            var m = ex.Match(cmd);

            if(m.Success) {
                return Chromium.Remote.RemoteClient.ExecuteProcess(m.Groups[1].Value);
            } else {
                return ExecuteProcessInternal(application);
            }
        }

        internal static int ExecuteProcessInternal(CfxApp application) {
            switch(CfxApi.PlatformOS) {
                case CfxPlatformOS.Windows:
                    return ExecuteProcessPrivate(null, application, IntPtr.Zero);
                case CfxPlatformOS.Linux:
                    using(var mainArgs = CfxMainArgs.ForLinux()) {
                        var retval = ExecuteProcessPrivate(mainArgs, application, IntPtr.Zero);
                        mainArgs.mainArgsLinux.Free();
                        return retval;
                    }
                default:
                    throw new CfxException("Unsupported platform.");
            }
        }

        /// <summary>
        /// This function should be called on the main application thread to initialize
        /// the CEF browser process with support for the remote interface to the render
        /// process. The |application| parameter may be NULL. A return value of true (1) 
        /// indicates that it succeeded and false (0) indicates that it failed.
        /// 
        /// If |renderProcessMain| is provided, then every newly created render process 
        /// main thread will be redirected through this callback and the callee is
        /// responsible for calling CfrRuntime.ExecuteProcess() from within the 
        /// scope of this callback.
        /// 
        /// The chromium sandbox is currently not supported within ChromiumFX.
        /// </summary>
        public static bool Initialize(CfxSettings settings, CfxApp application, CfxRenderProcessMainDelegate renderProcessMain) {
            CfxApi.Probe();
            Chromium.Remote.RemoteService.Initialize(renderProcessMain, ref application);
            return Initialize(settings, application);
        }

        /// <summary>
        /// This function should be called on the main application thread to initialize
        /// the CEF browser process. The |application| parameter may be NULL. A return
        /// value of true (1) indicates that it succeeded and false (0) indicates that it
        /// failed.
        /// 
        /// The chromium sandbox is currently not supported within ChromiumFX.
        /// </summary>
        public static bool Initialize(CfxSettings settings, CfxApp application) {
            CfxApi.Probe();
            switch(CfxApi.PlatformOS) {
                case CfxPlatformOS.Windows:
                    return InitializePrivate(null, settings, application, IntPtr.Zero);
                case CfxPlatformOS.Linux:
                    using(var mainArgs = CfxMainArgs.ForLinux()) {
                        var retval = InitializePrivate(mainArgs, settings, application, IntPtr.Zero);
                        mainArgs.mainArgsLinux.Free();
                        return retval;
                    }
                default:
                    throw new CfxException();
            }
        }

        public static string GetCefVersion() {
            CfxApi.Probe();
            return String.Format("{0}.{1}.{2}", VersionInfo(0), VersionInfo(4), VersionInfo(1));
        }

        public static string GetChromeVersion() {
            CfxApi.Probe();
            return String.Format("{0}.{1}.{2}.{3}", VersionInfo(2), VersionInfo(3), VersionInfo(4), VersionInfo(5));
        }

        /// <summary>
        /// This function should be called on the main application thread to shut down
        /// the CEF browser process before the application exits.
        /// </summary>
        public static void Shutdown() {
            var handler = OnCfxShutdown;
            if(handler != null)
                handler();
            ShutdownPrivate();
        }

    }
}
