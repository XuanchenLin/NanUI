// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxCommandLineCreateRemoteCall : RemoteCall {

        internal CfxCommandLineCreateRemoteCall()
            : base(RemoteCallId.CfxCommandLineCreateRemoteCall) {}

        internal IntPtr __retval;

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.CommandLine.cfx_command_line_create();
        }
    }

    internal class CfxCommandLineGetGlobalRemoteCall : RemoteCall {

        internal CfxCommandLineGetGlobalRemoteCall()
            : base(RemoteCallId.CfxCommandLineGetGlobalRemoteCall) {}

        internal IntPtr __retval;

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.CommandLine.cfx_command_line_get_global();
        }
    }

    internal class CfxCommandLineIsValidRemoteCall : RemoteCall {

        internal CfxCommandLineIsValidRemoteCall()
            : base(RemoteCallId.CfxCommandLineIsValidRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.CommandLine.cfx_command_line_is_valid(@this);
        }
    }

    internal class CfxCommandLineIsReadOnlyRemoteCall : RemoteCall {

        internal CfxCommandLineIsReadOnlyRemoteCall()
            : base(RemoteCallId.CfxCommandLineIsReadOnlyRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.CommandLine.cfx_command_line_is_read_only(@this);
        }
    }

    internal class CfxCommandLineCopyRemoteCall : RemoteCall {

        internal CfxCommandLineCopyRemoteCall()
            : base(RemoteCallId.CfxCommandLineCopyRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.CommandLine.cfx_command_line_copy(@this);
        }
    }

    internal class CfxCommandLineInitFromArgvRemoteCall : RemoteCall {

        internal CfxCommandLineInitFromArgvRemoteCall()
            : base(RemoteCallId.CfxCommandLineInitFromArgvRemoteCall) {}

        internal IntPtr @this;
        internal int argc;
        internal IntPtr argv;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(argc);
            h.Write(argv);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out argc);
            h.Read(out argv);
        }

        protected override void RemoteProcedure() {
            CfxApi.CommandLine.cfx_command_line_init_from_argv(@this, argc, argv);
        }
    }

    internal class CfxCommandLineInitFromStringRemoteCall : RemoteCall {

        internal CfxCommandLineInitFromStringRemoteCall()
            : base(RemoteCallId.CfxCommandLineInitFromStringRemoteCall) {}

        internal IntPtr @this;
        internal string commandLine;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(commandLine);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out commandLine);
        }

        protected override void RemoteProcedure() {
            var commandLine_pinned = new PinnedString(commandLine);
            CfxApi.CommandLine.cfx_command_line_init_from_string(@this, commandLine_pinned.Obj.PinnedPtr, commandLine_pinned.Length);
            commandLine_pinned.Obj.Free();
        }
    }

    internal class CfxCommandLineResetRemoteCall : RemoteCall {

        internal CfxCommandLineResetRemoteCall()
            : base(RemoteCallId.CfxCommandLineResetRemoteCall) {}

        internal IntPtr @this;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void RemoteProcedure() {
            CfxApi.CommandLine.cfx_command_line_reset(@this);
        }
    }

    internal class CfxCommandLineGetArgvRemoteCall : RemoteCall {

        internal CfxCommandLineGetArgvRemoteCall()
            : base(RemoteCallId.CfxCommandLineGetArgvRemoteCall) {}

        internal IntPtr @this;
        internal System.Collections.Generic.List<string> __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = new System.Collections.Generic.List<string>();
            var list = StringFunctions.AllocCfxStringList();
            CfxApi.CommandLine.cfx_command_line_get_argv(@this, list);
            StringFunctions.CfxStringListCopyToManaged(list, __retval);
            StringFunctions.FreeCfxStringList(list);
        }
    }

    internal class CfxCommandLineGetCommandLineStringRemoteCall : RemoteCall {

        internal CfxCommandLineGetCommandLineStringRemoteCall()
            : base(RemoteCallId.CfxCommandLineGetCommandLineStringRemoteCall) {}

        internal IntPtr @this;
        internal string __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.CommandLine.cfx_command_line_get_command_line_string(@this));
        }
    }

    internal class CfxCommandLineGetProgramRemoteCall : RemoteCall {

        internal CfxCommandLineGetProgramRemoteCall()
            : base(RemoteCallId.CfxCommandLineGetProgramRemoteCall) {}

        internal IntPtr @this;
        internal string __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.CommandLine.cfx_command_line_get_program(@this));
        }
    }

    internal class CfxCommandLineSetProgramRemoteCall : RemoteCall {

        internal CfxCommandLineSetProgramRemoteCall()
            : base(RemoteCallId.CfxCommandLineSetProgramRemoteCall) {}

        internal IntPtr @this;
        internal string value;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out value);
        }

        protected override void RemoteProcedure() {
            var value_pinned = new PinnedString(value);
            CfxApi.CommandLine.cfx_command_line_set_program(@this, value_pinned.Obj.PinnedPtr, value_pinned.Length);
            value_pinned.Obj.Free();
        }
    }

    internal class CfxCommandLineHasSwitchesRemoteCall : RemoteCall {

        internal CfxCommandLineHasSwitchesRemoteCall()
            : base(RemoteCallId.CfxCommandLineHasSwitchesRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.CommandLine.cfx_command_line_has_switches(@this);
        }
    }

    internal class CfxCommandLineHasSwitchRemoteCall : RemoteCall {

        internal CfxCommandLineHasSwitchRemoteCall()
            : base(RemoteCallId.CfxCommandLineHasSwitchRemoteCall) {}

        internal IntPtr @this;
        internal string name;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(name);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out name);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var name_pinned = new PinnedString(name);
            __retval = 0 != CfxApi.CommandLine.cfx_command_line_has_switch(@this, name_pinned.Obj.PinnedPtr, name_pinned.Length);
            name_pinned.Obj.Free();
        }
    }

    internal class CfxCommandLineGetSwitchValueRemoteCall : RemoteCall {

        internal CfxCommandLineGetSwitchValueRemoteCall()
            : base(RemoteCallId.CfxCommandLineGetSwitchValueRemoteCall) {}

        internal IntPtr @this;
        internal string name;
        internal string __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(name);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out name);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var name_pinned = new PinnedString(name);
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.CommandLine.cfx_command_line_get_switch_value(@this, name_pinned.Obj.PinnedPtr, name_pinned.Length));
            name_pinned.Obj.Free();
        }
    }

    internal class CfxCommandLineGetSwitchesRemoteCall : RemoteCall {

        internal CfxCommandLineGetSwitchesRemoteCall()
            : base(RemoteCallId.CfxCommandLineGetSwitchesRemoteCall) {}

        internal IntPtr @this;
        internal System.Collections.Generic.List<string[]> __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = new System.Collections.Generic.List<string[]>();
            var list = StringFunctions.AllocCfxStringMap();
            CfxApi.CommandLine.cfx_command_line_get_switches(@this, list);
            StringFunctions.CfxStringMapCopyToManaged(list, __retval);
            StringFunctions.FreeCfxStringMap(list);
        }
    }

    internal class CfxCommandLineAppendSwitchRemoteCall : RemoteCall {

        internal CfxCommandLineAppendSwitchRemoteCall()
            : base(RemoteCallId.CfxCommandLineAppendSwitchRemoteCall) {}

        internal IntPtr @this;
        internal string name;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(name);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out name);
        }

        protected override void RemoteProcedure() {
            var name_pinned = new PinnedString(name);
            CfxApi.CommandLine.cfx_command_line_append_switch(@this, name_pinned.Obj.PinnedPtr, name_pinned.Length);
            name_pinned.Obj.Free();
        }
    }

    internal class CfxCommandLineAppendSwitchWithValueRemoteCall : RemoteCall {

        internal CfxCommandLineAppendSwitchWithValueRemoteCall()
            : base(RemoteCallId.CfxCommandLineAppendSwitchWithValueRemoteCall) {}

        internal IntPtr @this;
        internal string name;
        internal string value;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(name);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out name);
            h.Read(out value);
        }

        protected override void RemoteProcedure() {
            var name_pinned = new PinnedString(name);
            var value_pinned = new PinnedString(value);
            CfxApi.CommandLine.cfx_command_line_append_switch_with_value(@this, name_pinned.Obj.PinnedPtr, name_pinned.Length, value_pinned.Obj.PinnedPtr, value_pinned.Length);
            name_pinned.Obj.Free();
            value_pinned.Obj.Free();
        }
    }

    internal class CfxCommandLineHasArgumentsRemoteCall : RemoteCall {

        internal CfxCommandLineHasArgumentsRemoteCall()
            : base(RemoteCallId.CfxCommandLineHasArgumentsRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.CommandLine.cfx_command_line_has_arguments(@this);
        }
    }

    internal class CfxCommandLineGetArgumentsRemoteCall : RemoteCall {

        internal CfxCommandLineGetArgumentsRemoteCall()
            : base(RemoteCallId.CfxCommandLineGetArgumentsRemoteCall) {}

        internal IntPtr @this;
        internal System.Collections.Generic.List<string> __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = new System.Collections.Generic.List<string>();
            var list = StringFunctions.AllocCfxStringList();
            CfxApi.CommandLine.cfx_command_line_get_arguments(@this, list);
            StringFunctions.CfxStringListCopyToManaged(list, __retval);
            StringFunctions.FreeCfxStringList(list);
        }
    }

    internal class CfxCommandLineAppendArgumentRemoteCall : RemoteCall {

        internal CfxCommandLineAppendArgumentRemoteCall()
            : base(RemoteCallId.CfxCommandLineAppendArgumentRemoteCall) {}

        internal IntPtr @this;
        internal string argument;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(argument);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out argument);
        }

        protected override void RemoteProcedure() {
            var argument_pinned = new PinnedString(argument);
            CfxApi.CommandLine.cfx_command_line_append_argument(@this, argument_pinned.Obj.PinnedPtr, argument_pinned.Length);
            argument_pinned.Obj.Free();
        }
    }

    internal class CfxCommandLinePrependWrapperRemoteCall : RemoteCall {

        internal CfxCommandLinePrependWrapperRemoteCall()
            : base(RemoteCallId.CfxCommandLinePrependWrapperRemoteCall) {}

        internal IntPtr @this;
        internal string wrapper;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(wrapper);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out wrapper);
        }

        protected override void RemoteProcedure() {
            var wrapper_pinned = new PinnedString(wrapper);
            CfxApi.CommandLine.cfx_command_line_prepend_wrapper(@this, wrapper_pinned.Obj.PinnedPtr, wrapper_pinned.Length);
            wrapper_pinned.Obj.Free();
        }
    }

}
