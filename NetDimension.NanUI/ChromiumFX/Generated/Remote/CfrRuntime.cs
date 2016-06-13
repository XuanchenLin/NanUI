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



namespace Chromium.Remote
{
	public partial class CfrRuntime {

        /// <summary>
        /// Returns true (1) if called on the specified thread. Equivalent to using
        /// CfrTaskRunner.GetForThread(threadId).BelongsToCurrentThread().
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
        /// </remarks>
        public static bool CurrentlyOn(CfxThreadId threadId) {
            var call = new CfxRuntimeCurrentlyOnRenderProcessCall();
            call.threadId = (int)threadId;
            call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
            return call.__retval;
        }

        /// <summary>
        /// This is a convenience function for formatting a URL in a concise and human-
        /// friendly way to help users make security-related decisions (or in other
        /// circumstances when people need to distinguish sites, origins, or otherwise-
        /// simplified URLs from each other). Internationalized domain names (IDN) may be
        /// presented in Unicode if |languages| accepts the Unicode representation. The
        /// returned value will (a) omit the path for standard schemes, excepting file
        /// and filesystem, and (b) omit the port if it is the default for the scheme. Do
        /// not use this for URLs which will be parsed or sent to other applications.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_parser_capi.h">cef/include/capi/cef_parser_capi.h</see>.
        /// </remarks>
        public static string FormatUrlForSecurityDisplay(string originUrl, string languages) {
            var call = new CfxRuntimeFormatUrlForSecurityDisplayRenderProcessCall();
            call.originUrl = originUrl;
            call.languages = languages;
            call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
            return call.__retval;
        }

        /// <summary>
        /// Post a task for delayed execution on the specified thread. Equivalent to
        /// using CfrTaskRunner.GetForThread(threadId).PostDelayedTask(task,
        /// delay_ms).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
        /// </remarks>
        public static bool PostDelayedTask(CfxThreadId threadId, CfrTask task, long delayMs) {
            var call = new CfxRuntimePostDelayedTaskRenderProcessCall();
            call.threadId = (int)threadId;
            call.task = CfrObject.Unwrap(task);
            call.delayMs = delayMs;
            call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
            return call.__retval;
        }

        /// <summary>
        /// Post a task for execution on the specified thread. Equivalent to using
        /// CfrTaskRunner.GetForThread(threadId).PostTask(task).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
        /// </remarks>
        public static bool PostTask(CfxThreadId threadId, CfrTask task) {
            var call = new CfxRuntimePostTaskRenderProcessCall();
            call.threadId = (int)threadId;
            call.task = CfrObject.Unwrap(task);
            call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
            return call.__retval;
        }

        /// <summary>
        /// Register a new V8 extension with the specified JavaScript extension code and
        /// handler. Functions implemented by the handler are prototyped using the
        /// keyword 'native'. The calling of a native function is restricted to the scope
        /// in which the prototype of the native function is defined. This function may
        /// only be called on the render process main thread.
        /// Example JavaScript extension code: &lt;pre>
        /// // create the 'example' global object if it doesn't already exist.
        /// if (!example)
        /// example = {};
        /// // create the 'example.test' global object if it doesn't already exist.
        /// if (!example.test)
        /// example.test = {};
        /// (function() {
        /// // Define the function 'example.test.myfunction'.
        /// example.test.myfunction = function() {
        /// // Call CfrV8Handler.Execute() with the function name 'MyFunction'
        /// // and no arguments.
        /// native function MyFunction();
        /// return MyFunction();
        /// };
        /// // Define the getter function for parameter 'example.test.myparam'.
        /// example.test.__defineGetter__('myparam', function() {
        /// // Call CfrV8Handler.Execute() with the function name 'GetMyParam'
        /// // and no arguments.
        /// native function GetMyParam();
        /// return GetMyParam();
        /// });
        /// // Define the setter function for parameter 'example.test.myparam'.
        /// example.test.__defineSetter__('myparam', function(b) {
        /// // Call CfrV8Handler.Execute() with the function name 'SetMyParam'
        /// // and a single argument.
        /// native function SetMyParam();
        /// if(b) SetMyParam(b);
        /// });
        /// // Extension definitions can also contain normal JavaScript variables
        /// // and functions.
        /// var myint = 0;
        /// example.test.increment = function() {
        /// myint += 1;
        /// return myint;
        /// };
        /// })();
        /// &lt;/pre> Example usage in the page: &lt;pre>
        /// // Call the function.
        /// example.test.myfunction();
        /// // Set the parameter.
        /// example.test.myparam = value;
        /// // Get the parameter.
        /// value = example.test.myparam;
        /// // Call another function.
        /// example.test.increment();
        /// &lt;/pre>
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static bool RegisterExtension(string extensionName, string javascriptCode, CfrV8Handler handler) {
            var call = new CfxRuntimeRegisterExtensionRenderProcessCall();
            call.extensionName = extensionName;
            call.javascriptCode = javascriptCode;
            call.handler = CfrObject.Unwrap(handler);
            call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
            return call.__retval;
        }

    }
}
