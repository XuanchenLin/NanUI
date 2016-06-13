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

namespace Chromium
{
	/// <summary>
	/// Structure used to create and/or parse command line arguments. Arguments with
	/// '--', '-' and, on Windows, '/' prefixes are considered switches. Switches
	/// will always precede any arguments without switch prefixes. Switches can
	/// optionally have a value specified using the '=' delimiter (e.g.
	/// "-switch=value"). An argument of "--" will terminate switch parsing with all
	/// subsequent tokens, regardless of prefix, being interpreted as non-switch
	/// arguments. Switch names are considered case-insensitive. This structure can
	/// be used before cef_initialize() is called.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_command_line_capi.h">cef/include/capi/cef_command_line_capi.h</see>.
	/// </remarks>
	public class CfxCommandLine : CfxBase {

        static CfxCommandLine () {
            CfxApiLoader.LoadCfxCommandLineApi();
        }

        private static readonly WeakCache weakCache = new WeakCache();

        internal static CfxCommandLine Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            lock(weakCache) {
                var wrapper = (CfxCommandLine)weakCache.Get(nativePtr);
                if(wrapper == null) {
                    wrapper = new CfxCommandLine(nativePtr);
                    weakCache.Add(wrapper);
                } else {
                    CfxApi.cfx_release(nativePtr);
                }
                return wrapper;
            }
        }


        internal CfxCommandLine(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Create a new CfxCommandLine instance.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_command_line_capi.h">cef/include/capi/cef_command_line_capi.h</see>.
        /// </remarks>
        public static CfxCommandLine Create() {
            return CfxCommandLine.Wrap(CfxApi.cfx_command_line_create());
        }

        /// <summary>
        /// Returns the singleton global CfxCommandLine object. The returned object
        /// will be read-only.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_command_line_capi.h">cef/include/capi/cef_command_line_capi.h</see>.
        /// </remarks>
        public static CfxCommandLine GetGlobal() {
            return CfxCommandLine.Wrap(CfxApi.cfx_command_line_get_global());
        }

        /// <summary>
        /// Returns true (1) if this object is valid. Do not call any other functions
        /// if this function returns false (0).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_command_line_capi.h">cef/include/capi/cef_command_line_capi.h</see>.
        /// </remarks>
        public bool IsValid {
            get {
                return 0 != CfxApi.cfx_command_line_is_valid(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if the values of this object are read-only. Some APIs may
        /// expose read-only objects.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_command_line_capi.h">cef/include/capi/cef_command_line_capi.h</see>.
        /// </remarks>
        public bool IsReadOnly {
            get {
                return 0 != CfxApi.cfx_command_line_is_read_only(NativePtr);
            }
        }

        /// <summary>
        /// Constructs and returns the represented command line string. Use this
        /// function cautiously because quoting behavior is unclear.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_command_line_capi.h">cef/include/capi/cef_command_line_capi.h</see>.
        /// </remarks>
        public string CommandLineString {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_command_line_get_command_line_string(NativePtr));
            }
        }

        /// <summary>
        /// Get or set the program part of the command line string (the first item).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_command_line_capi.h">cef/include/capi/cef_command_line_capi.h</see>.
        /// </remarks>
        public string Program {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_command_line_get_program(NativePtr));
            }
            set {
                var value_pinned = new PinnedString(value);
                CfxApi.cfx_command_line_set_program(NativePtr, value_pinned.Obj.PinnedPtr, value_pinned.Length);
                value_pinned.Obj.Free();
            }
        }

        /// <summary>
        /// Returns true (1) if the command line has switches.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_command_line_capi.h">cef/include/capi/cef_command_line_capi.h</see>.
        /// </remarks>
        public bool HasSwitches {
            get {
                return 0 != CfxApi.cfx_command_line_has_switches(NativePtr);
            }
        }

        /// <summary>
        /// True if there are remaining command line arguments.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_command_line_capi.h">cef/include/capi/cef_command_line_capi.h</see>.
        /// </remarks>
        public bool HasArguments {
            get {
                return 0 != CfxApi.cfx_command_line_has_arguments(NativePtr);
            }
        }

        /// <summary>
        /// Returns a writable copy of this object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_command_line_capi.h">cef/include/capi/cef_command_line_capi.h</see>.
        /// </remarks>
        public CfxCommandLine Copy() {
            return CfxCommandLine.Wrap(CfxApi.cfx_command_line_copy(NativePtr));
        }

        /// <summary>
        /// Initialize the command line with the specified |argc| and |argv| values.
        /// The first argument must be the name of the program. This function is only
        /// supported on non-Windows platforms.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_command_line_capi.h">cef/include/capi/cef_command_line_capi.h</see>.
        /// </remarks>
        public void InitFromArgv(int argc, IntPtr argv) {
            CfxApi.cfx_command_line_init_from_argv(NativePtr, argc, argv);
        }

        /// <summary>
        /// Initialize the command line with the string returned by calling
        /// GetCommandLineW(). This function is only supported on Windows.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_command_line_capi.h">cef/include/capi/cef_command_line_capi.h</see>.
        /// </remarks>
        public void InitFromString(string commandLine) {
            var commandLine_pinned = new PinnedString(commandLine);
            CfxApi.cfx_command_line_init_from_string(NativePtr, commandLine_pinned.Obj.PinnedPtr, commandLine_pinned.Length);
            commandLine_pinned.Obj.Free();
        }

        /// <summary>
        /// Reset the command-line switches and arguments but leave the program
        /// component unchanged.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_command_line_capi.h">cef/include/capi/cef_command_line_capi.h</see>.
        /// </remarks>
        public void Reset() {
            CfxApi.cfx_command_line_reset(NativePtr);
        }

        /// <summary>
        /// Retrieve the original command line string as a vector of strings. The argv
        /// array: { program, [(--|-|/)switch[=value]]*, [--], [argument]* }
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_command_line_capi.h">cef/include/capi/cef_command_line_capi.h</see>.
        /// </remarks>
        public System.Collections.Generic.List<string> GetArgv() {
            System.Collections.Generic.List<string> argv = new System.Collections.Generic.List<string>();
            PinnedString[] argv_handles;
            var argv_unwrapped = StringFunctions.UnwrapCfxStringList(argv, out argv_handles);
            CfxApi.cfx_command_line_get_argv(NativePtr, argv_unwrapped);
            StringFunctions.FreePinnedStrings(argv_handles);
            StringFunctions.CfxStringListCopyToManaged(argv_unwrapped, argv);
            CfxApi.cfx_string_list_free(argv_unwrapped);
            return argv;
        }

        /// <summary>
        /// Returns true (1) if the command line contains the given switch.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_command_line_capi.h">cef/include/capi/cef_command_line_capi.h</see>.
        /// </remarks>
        public bool HasSwitch(string name) {
            var name_pinned = new PinnedString(name);
            var __retval = CfxApi.cfx_command_line_has_switch(NativePtr, name_pinned.Obj.PinnedPtr, name_pinned.Length);
            name_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Returns the value associated with the given switch. If the switch has no
        /// value or isn't present this function returns the NULL string.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_command_line_capi.h">cef/include/capi/cef_command_line_capi.h</see>.
        /// </remarks>
        public string GetSwitchValue(string name) {
            var name_pinned = new PinnedString(name);
            var __retval = CfxApi.cfx_command_line_get_switch_value(NativePtr, name_pinned.Obj.PinnedPtr, name_pinned.Length);
            name_pinned.Obj.Free();
            return StringFunctions.ConvertStringUserfree(__retval);
        }

        /// <summary>
        /// Returns the map of switch names and values. If a switch has no value an
        /// NULL string is returned.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_command_line_capi.h">cef/include/capi/cef_command_line_capi.h</see>.
        /// </remarks>
        public System.Collections.Generic.List<string[]> GetSwitches() {
            System.Collections.Generic.List<string[]> switches = new System.Collections.Generic.List<string[]>();
            PinnedString[] switches_handles;
            var switches_unwrapped = StringFunctions.UnwrapCfxStringMap(switches, out switches_handles);
            CfxApi.cfx_command_line_get_switches(NativePtr, switches_unwrapped);
            StringFunctions.FreePinnedStrings(switches_handles);
            StringFunctions.CfxStringMapCopyToManaged(switches_unwrapped, switches);
            CfxApi.cfx_string_map_free(switches_unwrapped);
            return switches;
        }

        /// <summary>
        /// Add a switch to the end of the command line. If the switch has no value
        /// pass an NULL value string.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_command_line_capi.h">cef/include/capi/cef_command_line_capi.h</see>.
        /// </remarks>
        public void AppendSwitch(string name) {
            var name_pinned = new PinnedString(name);
            CfxApi.cfx_command_line_append_switch(NativePtr, name_pinned.Obj.PinnedPtr, name_pinned.Length);
            name_pinned.Obj.Free();
        }

        /// <summary>
        /// Add a switch with the specified value to the end of the command line.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_command_line_capi.h">cef/include/capi/cef_command_line_capi.h</see>.
        /// </remarks>
        public void AppendSwitchWithValue(string name, string value) {
            var name_pinned = new PinnedString(name);
            var value_pinned = new PinnedString(value);
            CfxApi.cfx_command_line_append_switch_with_value(NativePtr, name_pinned.Obj.PinnedPtr, name_pinned.Length, value_pinned.Obj.PinnedPtr, value_pinned.Length);
            name_pinned.Obj.Free();
            value_pinned.Obj.Free();
        }

        /// <summary>
        /// Get the remaining command line arguments.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_command_line_capi.h">cef/include/capi/cef_command_line_capi.h</see>.
        /// </remarks>
        public System.Collections.Generic.List<string> GetArguments() {
            System.Collections.Generic.List<string> arguments = new System.Collections.Generic.List<string>();
            PinnedString[] arguments_handles;
            var arguments_unwrapped = StringFunctions.UnwrapCfxStringList(arguments, out arguments_handles);
            CfxApi.cfx_command_line_get_arguments(NativePtr, arguments_unwrapped);
            StringFunctions.FreePinnedStrings(arguments_handles);
            StringFunctions.CfxStringListCopyToManaged(arguments_unwrapped, arguments);
            CfxApi.cfx_string_list_free(arguments_unwrapped);
            return arguments;
        }

        /// <summary>
        /// Add an argument to the end of the command line.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_command_line_capi.h">cef/include/capi/cef_command_line_capi.h</see>.
        /// </remarks>
        public void AppendArgument(string argument) {
            var argument_pinned = new PinnedString(argument);
            CfxApi.cfx_command_line_append_argument(NativePtr, argument_pinned.Obj.PinnedPtr, argument_pinned.Length);
            argument_pinned.Obj.Free();
        }

        /// <summary>
        /// Insert a command before the current command. Common for debuggers, like
        /// "valgrind" or "gdb --args".
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_command_line_capi.h">cef/include/capi/cef_command_line_capi.h</see>.
        /// </remarks>
        public void PrependWrapper(string wrapper) {
            var wrapper_pinned = new PinnedString(wrapper);
            CfxApi.cfx_command_line_prepend_wrapper(NativePtr, wrapper_pinned.Obj.PinnedPtr, wrapper_pinned.Length);
            wrapper_pinned.Obj.Free();
        }

        internal override void OnDispose(IntPtr nativePtr) {
            weakCache.Remove(nativePtr);
            base.OnDispose(nativePtr);
        }
    }
}
