using System.IO.Pipes;

namespace NetDimension.NanUI.Browser.MessagePipe;

class MessageBridgePipeClient
{
    private string _pipeName;
    private CancellationToken _cancellationToken;
    const int BUFFER_SIZE = 4096;

    public MessageBridgePipeClient(string pipeName, CancellationToken tokenSource)
    {
        _pipeName = pipeName;
        _cancellationToken = tokenSource;
    }

    public Task<BridgeMessageResponse> RequestAsync(BridgeMessageRequest request)
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
                    return new BridgeMessageResponse(false, "No content.");
                }

                pipe.Close();
                pipe.Dispose();

                return BridgeMessageResponse.FromJson(json);

            }
            catch (Exception ex)
            {
                return new BridgeMessageResponse(false, ex.Message);
            }
        });
    }

}
