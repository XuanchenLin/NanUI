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
                    var reader = new StreamReader(pipe);
                    var writer = new StreamWriter(pipe);

                    writer.Write(request.ToJson());
                    writer.Flush();
                    pipe.WaitForPipeDrain();

                    var json = reader.ReadToEnd();

                    if (string.IsNullOrEmpty(json))
                    {
                        return MessageBridgeResponse.CreateFailureResponse("No content.");
                    }

                    pipe.Close();
                    pipe.Dispose();

                    return MessageBridgeResponse.CreateSuccessResponse(json);

                }
                catch(Exception ex)
                {
                    return MessageBridgeResponse.CreateFailureResponse(ex.Message);
                }
            });
        }


    }
}
