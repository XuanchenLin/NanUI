using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetDimension.NanUI.Browser.ProcessMessageBridge
{
    public class MessageBridgeNamedPipeClient
    {
        private string _pipeName;
        private CancellationTokenSource _cancellationTokenSource;
        const int BUFFER_SIZE = 4096;

        public MessageBridgeRenderSide JavascriptBridge { get; }

        public MessageBridgeNamedPipeClient(MessageBridgeRenderSide jsBridge, string pipeName, CancellationTokenSource cancellationTokenSource)
        {
            JavascriptBridge = jsBridge;
            _pipeName = pipeName;
            _cancellationTokenSource = cancellationTokenSource;
        }

        public Task<MessageBridgeResponse> RequestAsync(MessageBridgeRequest request)
        {
            return Task.Run(() =>
            {
                var pipe = new NamedPipeClientStream(_pipeName);
                try
                {
                    pipe.Connect();
                    pipe.ReadMode = PipeTransmissionMode.Message;

                    var buff = Encoding.UTF8.GetBytes(request.ToJson());

                    pipe.Write(buff, 0, buff.Length);
                    pipe.Flush();
                    pipe.WaitForPipeDrain();

                    buff = new byte[BUFFER_SIZE];
                    var ms = new MemoryStream();

                    do
                    {
                        ms.Write(buff, 0, pipe.Read(buff, 0, buff.Length));
                    }
                    while (!pipe.IsMessageComplete);

                    var json = Encoding.UTF8.GetString(ms.ToArray());
                    ms.Close();
                    ms.Dispose();

                    buff = null;


                    if (string.IsNullOrEmpty(json))
                    {
                        return MessageBridgeResponse.CreateFailureResponse("No content.");
                    }

                    pipe.Close();
                    pipe.Dispose();

                    return MessageBridgeResponse.CreateSuccessResponse(json);

                }
                catch (Exception ex)
                {
                    return MessageBridgeResponse.CreateFailureResponse(ex.Message);
                }
            });
        }


    }
}
