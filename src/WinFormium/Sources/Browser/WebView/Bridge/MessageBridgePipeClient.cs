// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using System.IO.Pipes;

namespace WinFormium.Browser;
internal class MessageBridgePipeClient
{

    public string PipeName { get; }

    public MessageBridgePipeClient( string pipeName)
    {

        PipeName = pipeName;
    }

    public Task<MessageBridgeResponse> RequestAsync(MessageBridgeRequest request)
    {
        return Task.Run(() =>
        {
            var client = new NamedPipeClientStream(PipeName);


            try
            {
                client.Connect();

                client.ReadMode = PipeTransmissionMode.Byte;

                var stream = new MessageBridgePipeStream(client);

                stream.WriteMessage(request.ToJson());

                client.Flush();

                client.WaitForPipeDrain();

                var message = stream.ReadMessage();

                return MessageBridgeResponse.FromJson(message);
            }
            catch (Exception ex)
            {
                return new MessageBridgeResponse
                {
                    IsSuccess = false,
                    Exception = ex.Message
                };
            }
            finally
            {
                client.Close();
                client.Dispose();
            }
        });
    }
}
