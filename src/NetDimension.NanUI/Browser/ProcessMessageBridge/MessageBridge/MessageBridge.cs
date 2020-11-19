using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NetDimension.NanUI.Browser
{
    internal static class MessageBridge
    {
        internal const string MESSAGE_PREFIX = "!__formium_process_message:";

        internal const string FUNCTION_PREFIX = "__function_uuid__";

        internal const string PROCESS_MESSAGE_BRIDGE_MESSAGE = MESSAGE_PREFIX + "ProcessMessageBridge";

        internal const string NAMED_PIPE_BASE_ADDRESS = "formium//ProcessMessageProxy";


        internal static string GetServiceName(int browserId)
        {
            int processId;
            if (WinFormium.Runtime.ProcessType == CefProcessType.Browser)
            {
                processId = Process.GetCurrentProcess().Id;
            }
            else
            {
                processId = WinFormium.Runtime.BrowserProcessId;
            }

            return string.Join("/", NAMED_PIPE_BASE_ADDRESS, processId, browserId);
        }
    }
}
