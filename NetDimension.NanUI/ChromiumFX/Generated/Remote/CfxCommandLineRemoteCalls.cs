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

	internal class CfxCommandLineCreateRenderProcessCall : RenderProcessCall {

        internal CfxCommandLineCreateRenderProcessCall()
            : base(RemoteCallId.CfxCommandLineCreateRenderProcessCall) {}

        internal IntPtr __retval;

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = RemoteProxy.Wrap(CfxCommandLine.Create());
        }
    }

    internal class CfxCommandLineGetGlobalRenderProcessCall : RenderProcessCall {

        internal CfxCommandLineGetGlobalRenderProcessCall()
            : base(RemoteCallId.CfxCommandLineGetGlobalRenderProcessCall) {}

        internal IntPtr __retval;

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            __retval = RemoteProxy.Wrap(CfxCommandLine.GetGlobal());
        }
    }

    internal class CfxCommandLineIsValidRenderProcessCall : RenderProcessCall {

        internal CfxCommandLineIsValidRenderProcessCall()
            : base(RemoteCallId.CfxCommandLineIsValidRenderProcessCall) {}

        internal IntPtr self;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxCommandLine)RemoteProxy.Unwrap(self);
            __retval = self_local.IsValid;
        }
    }

    internal class CfxCommandLineIsReadOnlyRenderProcessCall : RenderProcessCall {

        internal CfxCommandLineIsReadOnlyRenderProcessCall()
            : base(RemoteCallId.CfxCommandLineIsReadOnlyRenderProcessCall) {}

        internal IntPtr self;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxCommandLine)RemoteProxy.Unwrap(self);
            __retval = self_local.IsReadOnly;
        }
    }

    internal class CfxCommandLineCopyRenderProcessCall : RenderProcessCall {

        internal CfxCommandLineCopyRenderProcessCall()
            : base(RemoteCallId.CfxCommandLineCopyRenderProcessCall) {}

        internal IntPtr self;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxCommandLine)RemoteProxy.Unwrap(self);
            __retval = RemoteProxy.Wrap(self_local.Copy());
        }
    }

    internal class CfxCommandLineInitFromArgvRenderProcessCall : RenderProcessCall {

        internal CfxCommandLineInitFromArgvRenderProcessCall()
            : base(RemoteCallId.CfxCommandLineInitFromArgvRenderProcessCall) {}

        internal IntPtr self;
        internal int argc;
        internal IntPtr argv;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(argc);
            h.Write(argv);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out argc);
            h.Read(out argv);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxCommandLine)RemoteProxy.Unwrap(self);
            self_local.InitFromArgv(argc, argv);
        }
    }

    internal class CfxCommandLineInitFromStringRenderProcessCall : RenderProcessCall {

        internal CfxCommandLineInitFromStringRenderProcessCall()
            : base(RemoteCallId.CfxCommandLineInitFromStringRenderProcessCall) {}

        internal IntPtr self;
        internal string commandLine;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(commandLine);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out commandLine);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxCommandLine)RemoteProxy.Unwrap(self);
            self_local.InitFromString(commandLine);
        }
    }

    internal class CfxCommandLineResetRenderProcessCall : RenderProcessCall {

        internal CfxCommandLineResetRenderProcessCall()
            : base(RemoteCallId.CfxCommandLineResetRenderProcessCall) {}

        internal IntPtr self;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxCommandLine)RemoteProxy.Unwrap(self);
            self_local.Reset();
        }
    }

    internal class CfxCommandLineGetArgvRenderProcessCall : RenderProcessCall {

        internal CfxCommandLineGetArgvRenderProcessCall()
            : base(RemoteCallId.CfxCommandLineGetArgvRenderProcessCall) {}

        internal IntPtr self;
        internal System.Collections.Generic.List<string> __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxCommandLine)RemoteProxy.Unwrap(self);
            __retval = self_local.GetArgv();
        }
    }

    internal class CfxCommandLineGetCommandLineStringRenderProcessCall : RenderProcessCall {

        internal CfxCommandLineGetCommandLineStringRenderProcessCall()
            : base(RemoteCallId.CfxCommandLineGetCommandLineStringRenderProcessCall) {}

        internal IntPtr self;
        internal string __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxCommandLine)RemoteProxy.Unwrap(self);
            __retval = self_local.CommandLineString;
        }
    }

    internal class CfxCommandLineGetProgramRenderProcessCall : RenderProcessCall {

        internal CfxCommandLineGetProgramRenderProcessCall()
            : base(RemoteCallId.CfxCommandLineGetProgramRenderProcessCall) {}

        internal IntPtr self;
        internal string __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxCommandLine)RemoteProxy.Unwrap(self);
            __retval = self_local.Program;
        }
    }

    internal class CfxCommandLineSetProgramRenderProcessCall : RenderProcessCall {

        internal CfxCommandLineSetProgramRenderProcessCall()
            : base(RemoteCallId.CfxCommandLineSetProgramRenderProcessCall) {}

        internal IntPtr self;
        internal string value;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out value);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxCommandLine)RemoteProxy.Unwrap(self);
            self_local.Program = value;
        }
    }

    internal class CfxCommandLineHasSwitchesRenderProcessCall : RenderProcessCall {

        internal CfxCommandLineHasSwitchesRenderProcessCall()
            : base(RemoteCallId.CfxCommandLineHasSwitchesRenderProcessCall) {}

        internal IntPtr self;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxCommandLine)RemoteProxy.Unwrap(self);
            __retval = self_local.HasSwitches;
        }
    }

    internal class CfxCommandLineHasSwitchRenderProcessCall : RenderProcessCall {

        internal CfxCommandLineHasSwitchRenderProcessCall()
            : base(RemoteCallId.CfxCommandLineHasSwitchRenderProcessCall) {}

        internal IntPtr self;
        internal string name;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(name);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out name);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxCommandLine)RemoteProxy.Unwrap(self);
            __retval = self_local.HasSwitch(name);
        }
    }

    internal class CfxCommandLineGetSwitchValueRenderProcessCall : RenderProcessCall {

        internal CfxCommandLineGetSwitchValueRenderProcessCall()
            : base(RemoteCallId.CfxCommandLineGetSwitchValueRenderProcessCall) {}

        internal IntPtr self;
        internal string name;
        internal string __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(name);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out name);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxCommandLine)RemoteProxy.Unwrap(self);
            __retval = self_local.GetSwitchValue(name);
        }
    }

    internal class CfxCommandLineGetSwitchesRenderProcessCall : RenderProcessCall {

        internal CfxCommandLineGetSwitchesRenderProcessCall()
            : base(RemoteCallId.CfxCommandLineGetSwitchesRenderProcessCall) {}

        internal IntPtr self;
        internal System.Collections.Generic.List<string[]> __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxCommandLine)RemoteProxy.Unwrap(self);
            __retval = self_local.GetSwitches();
        }
    }

    internal class CfxCommandLineAppendSwitchRenderProcessCall : RenderProcessCall {

        internal CfxCommandLineAppendSwitchRenderProcessCall()
            : base(RemoteCallId.CfxCommandLineAppendSwitchRenderProcessCall) {}

        internal IntPtr self;
        internal string name;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(name);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out name);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxCommandLine)RemoteProxy.Unwrap(self);
            self_local.AppendSwitch(name);
        }
    }

    internal class CfxCommandLineAppendSwitchWithValueRenderProcessCall : RenderProcessCall {

        internal CfxCommandLineAppendSwitchWithValueRenderProcessCall()
            : base(RemoteCallId.CfxCommandLineAppendSwitchWithValueRenderProcessCall) {}

        internal IntPtr self;
        internal string name;
        internal string value;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(name);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out name);
            h.Read(out value);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxCommandLine)RemoteProxy.Unwrap(self);
            self_local.AppendSwitchWithValue(name, value);
        }
    }

    internal class CfxCommandLineHasArgumentsRenderProcessCall : RenderProcessCall {

        internal CfxCommandLineHasArgumentsRenderProcessCall()
            : base(RemoteCallId.CfxCommandLineHasArgumentsRenderProcessCall) {}

        internal IntPtr self;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxCommandLine)RemoteProxy.Unwrap(self);
            __retval = self_local.HasArguments;
        }
    }

    internal class CfxCommandLineGetArgumentsRenderProcessCall : RenderProcessCall {

        internal CfxCommandLineGetArgumentsRenderProcessCall()
            : base(RemoteCallId.CfxCommandLineGetArgumentsRenderProcessCall) {}

        internal IntPtr self;
        internal System.Collections.Generic.List<string> __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxCommandLine)RemoteProxy.Unwrap(self);
            __retval = self_local.GetArguments();
        }
    }

    internal class CfxCommandLineAppendArgumentRenderProcessCall : RenderProcessCall {

        internal CfxCommandLineAppendArgumentRenderProcessCall()
            : base(RemoteCallId.CfxCommandLineAppendArgumentRenderProcessCall) {}

        internal IntPtr self;
        internal string argument;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(argument);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out argument);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxCommandLine)RemoteProxy.Unwrap(self);
            self_local.AppendArgument(argument);
        }
    }

    internal class CfxCommandLinePrependWrapperRenderProcessCall : RenderProcessCall {

        internal CfxCommandLinePrependWrapperRenderProcessCall()
            : base(RemoteCallId.CfxCommandLinePrependWrapperRenderProcessCall) {}

        internal IntPtr self;
        internal string wrapper;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(self);
            h.Write(wrapper);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out self);
            h.Read(out wrapper);
        }

        protected override void ExecuteInTargetProcess(RemoteConnection connection) {
            var self_local = (CfxCommandLine)RemoteProxy.Unwrap(self);
            self_local.PrependWrapper(wrapper);
        }
    }

}
