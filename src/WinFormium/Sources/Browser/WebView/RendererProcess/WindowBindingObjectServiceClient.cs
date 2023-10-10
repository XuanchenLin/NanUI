// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

using System.IO.Pipes;

namespace WinFormium.Browser;

internal class WindowBindingObjectServiceClient
{
    public string PipeName { get; }

    public WindowBindingObjectServiceClient(string pipeName)
    {
        PipeName = pipeName;
    }

    public string? Request(string request)
    {
        var client = new NamedPipeClientStream(PipeName);

        //MessageBox.Show($"CLIENT: {PipeName}");

        try
        {
            client.Connect();

            client.ReadMode = PipeTransmissionMode.Byte;

            var stream = new MessageBridgePipeStream(client);

            if (!client.CanWrite) return null;

            stream.WriteMessage(request);

            client.Flush();

            client.WaitForPipeDrain();

            var message = stream.ReadMessage();

            return message;
        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.ToString());
            Logger.Instance.Log.LogError(ex);
            return null;
        }
        finally
        {
            client.Close();
            client.Dispose();
        }
    }

    public Task<string?> RequestAsync(string request)
    {
        return Task.Run(() =>
        {
            return Request(request);
        });
    }

}