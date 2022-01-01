using System.Diagnostics;
using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser.MessagePipe;

public class FormiumMessageBridge
{
    internal static CancellationToken CancellationToken { get; } = new CancellationTokenSource().Token;


    internal const string MESSAGE_PREFIX = "!__formium_process_message_";

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

    public static MessageResponse ExecuteRequest(MessageRequest request)
    {
        return ExecuteRequestAsync(request).GetAwaiter().GetResult();
    }

    public static Task<MessageResponse> ExecuteRequestAsync(MessageRequest request)
    {
        return Task.Run(() =>
        {
            var serviceName = GetServiceName(request.BrowserId);

            var client = new JavaScriptPipeClient(serviceName, CancellationToken);

            return client.RequestAsync(request);


        }, CancellationToken);
    }

    public static void SendBridgeMessage(CefProcessId side, CefFrame frame, BridgeMessage message)
    {
        var msg = CefProcessMessage.Create(PROCESS_MESSAGE_BRIDGE_MESSAGE);

        var json = JsonConvert.SerializeObject(message);

        var buff = Encoding.UTF8.GetBytes(json);

        var base64str = Convert.ToBase64String(buff);

        msg.Arguments.SetString(0, base64str);

        frame.SendProcessMessage(side, msg);
        msg.Dispose();
    }

}
