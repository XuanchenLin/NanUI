using System.IO.Pipes;

namespace NetDimension.NanUI.Browser.MessagePipe;

class JavaScriptPipeClient
{
    private string _pipeName;
    private CancellationToken _cancellationToken;
    const int BUFFER_SIZE = 4096;

    public JavaScriptPipeClient(string pipeName, CancellationToken tokenSource)
    {
        _pipeName = pipeName;
        _cancellationToken = tokenSource;
    }

    public Task<MessageResponse> RequestAsync(MessageRequest request)
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
                    return new MessageResponse(false, "No content.");
                }

                pipe.Close();
                pipe.Dispose();

                return MessageResponse.FromJson(json);

            }
            catch (Exception ex)
            {
                return new MessageResponse(false, ex.Message);
            }
        });
    }

}
