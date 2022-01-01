namespace NetDimension.NanUI.Logging;

public class DebugLogger : ILogger
{
    public void Critial(string message)
    {
        System.Diagnostics.Debug.WriteLine(message);
    }

    public void Debug(string message)
    {
        System.Diagnostics.Debug.WriteLine(message);
    }

    public void Error(string message)
    {
        System.Diagnostics.Debug.WriteLine(message);
    }

    public void Error(Exception exception)
    {
        System.Diagnostics.Debug.WriteLine(exception);
    }

    public void Error(Exception exception, string message)
    {
        System.Diagnostics.Debug.WriteLine($"{message}");
        System.Diagnostics.Debug.WriteLine($"{exception}");

    }

    public void Fatal(string message)
    {
        System.Diagnostics.Debug.WriteLine(message);

    }

    public void Info(string message)
    {
        System.Diagnostics.Debug.WriteLine(message);

    }

    public void Verbose(string message)
    {
        System.Diagnostics.Debug.WriteLine(message);

    }

    public void Warn(string message)
    {
        System.Diagnostics.Debug.WriteLine(message);

    }
}
