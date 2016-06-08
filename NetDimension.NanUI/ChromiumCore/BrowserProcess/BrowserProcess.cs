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



using Chromium;
using System;

namespace NetDimension.NanUI.ChromiumCore
{
	internal class BrowserProcess {

		internal static CfxApp app;
		internal static CfxBrowserProcessHandler processHandler;

		internal static bool initialized;

		internal static void Initialize() {

			if(initialized)
				throw new HtmlUIException("ChromiumWebBrowser library already initialized.");


			int retval = CfxRuntime.ExecuteProcess();
			if(retval >= 0)
				Environment.Exit(retval);


			app = new CfxApp();
			processHandler = new CfxBrowserProcessHandler();

			app.GetBrowserProcessHandler += (s, e) => e.SetReturnValue(processHandler);
			app.OnBeforeCommandLineProcessing += (s, e) => HtmlUILauncher.RaiseOnBeforeCommandLineProcessing(e);
			app.OnRegisterCustomSchemes += (s, e) => HtmlUILauncher.RaiseOnRegisterCustomSchemes(e);


			var settings = new CfxSettings();
			settings.MultiThreadedMessageLoop = true;
			settings.NoSandbox = true;

			HtmlUILauncher.RaiseOnBeforeCfxInitialize(settings, processHandler);

			if(!CfxRuntime.Initialize(settings, app, RenderProcess.RenderProcessMain))
				throw new HtmlUIException("Failed to initialize CEF library.");

			initialized = true;
		}
	}
}
