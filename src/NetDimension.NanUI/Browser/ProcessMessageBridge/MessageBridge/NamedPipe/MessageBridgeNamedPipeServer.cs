using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace NetDimension.NanUI.Browser.ProcessMessageBridge
{
    internal sealed class MessageBridgeNamedPipeServer : IDisposable
    {
        private readonly string _pipeName;
        private readonly CancellationTokenSource _cancellationTokenSource;
        const int BUFFER_SIZE = 4096;

        CancellationToken CancellationToken => _cancellationTokenSource.Token;

        public MessageBridgeBrowserSide JavascriptBridge { get; }

        public MessageBridgeNamedPipeServer(MessageBridgeBrowserSide jsBridge, string pipeName, CancellationTokenSource cancellationTokenSource)
        {
            JavascriptBridge = jsBridge;
            this._pipeName = pipeName;
            this._cancellationTokenSource = cancellationTokenSource;


            StartListening();
        }

        private async void StartListening()
        {
            while (!CancellationToken.IsCancellationRequested)
            {
                var pipe = new NamedPipeServerStream(_pipeName, PipeDirection.InOut, 254, PipeTransmissionMode.Message, PipeOptions.Asynchronous | PipeOptions.WriteThrough, BUFFER_SIZE, BUFFER_SIZE);

                await pipe.WaitForConnectionAsync(CancellationToken);


                AcceptClient(pipe);
            }
        }

        private void AcceptClient(NamedPipeServerStream pipe)
        {

            Task.Run(() =>
            {
                try
                {
                    var buff = new byte[BUFFER_SIZE];
                    var ms = new MemoryStream();

                    do
                    {
                        ms.Write(buff, 0, pipe.Read(buff, 0, buff.Length));
                    }
                    while (!pipe.IsMessageComplete);

                    var body = Encoding.UTF8.GetString(ms.ToArray());

                    ms.Close();
                    ms.Dispose();
                    buff = null;

                    var request = MessageBridgeRequest.Create(body);

                    MessageBridgeResponse response = null;

                    foreach (var handler in JavascriptBridge.JavascriptRequestHandlers)
                    {
                        try
                        {
                            var retval = handler?.Invoke(request);
                            if (retval != null)
                            {
                                response = retval;
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            response = MessageBridgeResponse.CreateFailureResponse(ex.Message);
                        }

                    }

                    if (response == null)
                    {
                        response = MessageBridgeResponse.CreateFailureResponse("Can't found handler for this request.");
                    }
                    buff = Encoding.UTF8.GetBytes(response.ToJson());
                    try
                    {
                        pipe.Write(buff, 0, buff.Length);
                        pipe.Flush();
                        pipe.WaitForPipeDrain();
                    }
                    catch(Exception ex)
                    {
                        WinFormium.GetLogger().Debug($"NamedPipeServer can't write to client. {ex.Message}");
                    }
                    finally
                    {
                        pipe.Disconnect();
                    }




                }
                catch(Exception ex)
                {
                    WinFormium.GetLogger().Error(ex);
                }


            }, CancellationToken);
        }

        public void Dispose()
        {

        }
    }
}
