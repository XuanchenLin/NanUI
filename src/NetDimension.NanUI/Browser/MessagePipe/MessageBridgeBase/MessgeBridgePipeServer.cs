using System.IO.Pipes;

namespace NetDimension.NanUI.Browser.MessagePipe;

internal sealed class MessgeBridgePipeServer : IDisposable
{
    private readonly string _pipeName;
    private readonly CancellationToken CancellationToken;


    const int BUFFER_SIZE = 4096;

    public MessageBridgeOnBrowserSide JavaScriptBridge { get; }

    public MessgeBridgePipeServer(MessageBridgeOnBrowserSide bridge, string pipeName, CancellationToken token)
    {
        JavaScriptBridge = bridge;
        _pipeName = pipeName;
        CancellationToken = token;

        Start();
    }

    private async void Start()
    {
        while (!CancellationToken.IsCancellationRequested)
        {
            var pipe = new NamedPipeServerStream(_pipeName, PipeDirection.InOut, NamedPipeServerStream.MaxAllowedServerInstances, PipeTransmissionMode.Message, PipeOptions.WriteThrough, BUFFER_SIZE, BUFFER_SIZE);

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

                var json = Encoding.UTF8.GetString(ms.ToArray());

                ms.Close();
                ms.Dispose();
                buff = null;


                var request = BridgeMessageRequest.Deserialize(json);

                var handlers = JavaScriptBridge.MessageHandlers.SelectMany(x => x.Handlers);

                BridgeMessageResponse response = null;

                foreach (var handler in handlers)
                {
                    try
                    {
                        BridgeMessageResponse retval = null;

                        retval = handler?.Invoke(request);

                        if (retval != null)
                        {
                            response = retval;
                            break;
                        }

                    }
                    catch (Exception ex)
                    {


                        response = new BridgeMessageResponse(false, ex.Message);

                        WinFormium.GetLogger().Error(ex);
                    }
                }

                if (response == null)
                {
                    response = new BridgeMessageResponse(false, "Can't found handler for this request.");
                }

                buff = Encoding.UTF8.GetBytes(response.ToJson());

                try
                {
                    pipe.Write(buff, 0, buff.Length);
                    pipe.Flush();
                    pipe.WaitForPipeDrain();
                }
                catch (Exception ex)
                {
                    WinFormium.GetLogger().Debug($"NamedPipeServer can't write to client. {ex.Message}");
                }
                finally
                {
                    pipe.Disconnect();
                    pipe.Dispose();
                }
            }
            catch (Exception ex)
            {
                WinFormium.GetLogger().Error(ex);
            }

        }, CancellationToken);
    }

    public void Dispose()
    {

    }
}
