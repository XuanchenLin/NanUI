// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using System.IO.Pipes;


namespace WinFormium.Browser;
internal class MessageBridgePipeServer : IDisposable
{
    private CancellationTokenSource? _cancellationTokenSource = new CancellationTokenSource();

    public MessageBridge Bridge { get; }

    public MessageBridgePipeServer(MessageBridge bridge, string pipeName)
    {
        Bridge = bridge;

        Task.Run(async () =>
        {
            const int MaxErrorsAllowed = 5;

            var errorCount = 0;

            try
            {
                while (!_cancellationTokenSource.IsCancellationRequested)
                {
                    try
                    {
                        using var server = new NamedPipeServerStream(pipeName, PipeDirection.InOut, NamedPipeServerStream.MaxAllowedServerInstances, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);

                        await server.WaitForConnectionAsync(_cancellationTokenSource.Token);
                        AcceptClient(server);
                    }
                    catch (OperationCanceledException) { }
                    catch (Exception ex)
                    {

                        Bridge.ApplicationContext.Logger.LogError(ex);

                        errorCount++;

                        if (errorCount > MaxErrorsAllowed)
                        {
                            break;
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {

            }
            finally
            {
                var cancellationTokenSource = _cancellationTokenSource;
                _cancellationTokenSource = null;
                cancellationTokenSource.Dispose();
            }
        });
    }

    private void AcceptClient(NamedPipeServerStream server)
    {
        MessageBridgeResponse? response;

        using var stream = new MessageBridgePipeStream(server);

        try
        {
            var message = stream.ReadMessage();

            var request = JsonSerializer.Deserialize<MessageBridgeRequest>(message);

            if (request == null) throw new NullReferenceException($"{nameof(request)}");

            response = Bridge.OnMessageBridgeRequestReviced(request);
        }
        catch (Exception ex)
        {
            response = new MessageBridgeResponse
            {
                IsSuccess = false,
                Exception = ex.Message
            };
        }

        if (response == null)
        {
            response = new MessageBridgeResponse
            {
                IsSuccess = false,
                Exception = "Can't found handler for this request."
            };
        }

        try
        {
            stream.WriteMessage(response.ToJson());

            server.Flush();

            server.WaitForPipeDrain();
        }
        catch (Exception ex)
        {
            Bridge.ApplicationContext.Logger.LogError(ex);
        }
        finally
        {

            server.Disconnect();
            server.Dispose();

        }
    }

    public void Dispose()
    {
        _cancellationTokenSource?.Cancel();
    }
}
