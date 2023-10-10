// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using System.IO.Pipes;

namespace WinFormium.Browser;

internal class WindowBindingObjectServiceServer : IDisposable
{
    private CancellationTokenSource? _cancellationTokenSource = new CancellationTokenSource();

    private bool _isTokenSourceDisposed = false;

    public WindowBindingObjectServiceServer(string pipeName)
    {
        //MessageBox.Show($"SERVER: {pipeName}");

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

                        Logger.Instance.Log.LogError(ex);


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
                _isTokenSourceDisposed = true;
            }
        });
    }

    private void AcceptClient(NamedPipeServerStream server)
    {

        using var stream = new MessageBridgePipeStream(server);

        string response = string.Empty;

        try
        {
            var message = stream.ReadMessage();

            switch (message)
            {
                case "GetWindowBindingObjects":
                    response = GetWindowBindingObjects();
                    break;
            }

        }
        catch (Exception ex)
        {
            Logger.Instance.Log.LogError(ex);
        }

        try
        {
            stream.WriteMessage(response);

            server.Flush();

            server.WaitForPipeDrain();
        }
        catch (Exception ex)
        {
            Logger.Instance.Log.LogError(ex);
        }
        finally
        {

            server.Disconnect();
            server.Dispose();

        }
    }

    private string GetWindowBindingObjects()
    {
        var objectTypes = JavaScriptWindowBindingObjectBridge.WindowBindingObjectTypes;

        var objects = new List<JavaScriptWindowBindingObjectDescriper>();

        foreach (var type in objectTypes)
        {
            var fileInfo = new FileInfo(new Uri(type.Assembly.Location).LocalPath);
            var filePath = fileInfo.FullName;
            var typeName = type.FullName;

            if (typeName == null) continue;

            var describer = new JavaScriptWindowBindingObjectDescriper(filePath, typeName);

            objects.Add(describer);
        }

        return JsonSerializer.Serialize(objects);
    }

    public void Dispose()
    {
        if (!_isTokenSourceDisposed)
        {
            //_cancellationTokenSource?.Cancel();
        }
    }
}

