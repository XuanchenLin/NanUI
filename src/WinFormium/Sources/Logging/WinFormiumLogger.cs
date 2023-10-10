// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Logging;
internal class WinFormiumLogger : ILogger
{
    private readonly string _location;
    private readonly string _filename = "WinFormium.log";
    private readonly string _backupFilename = "WinFormium";
    private readonly int _maxSizeInKiloBytes;
    private readonly bool _logToConsole;

    private readonly object _lockObj = new();

    /// <summary>Initializes a new instance of the <see cref="WinFormiumLogger" /> class.</summary>
    /// <param name="fullFilePath">The full file path.</param>
    /// <param name="logToConsole">if set to <c>true</c> log to console.</param>
    /// <param name="maxFileSizeBeforeLogRotation">The maximum file size before log rotation in MB.</param>
    public WinFormiumLogger(string? fullFilePath = null, bool logToConsole = false, int maxFileSizeBeforeLogRotation = 10)
    {
        var exeLocation = AppDomain.CurrentDomain.BaseDirectory;
        var appName = Assembly.GetEntryAssembly()?.GetName().Name;
        appName = string.IsNullOrWhiteSpace(appName) ? Guid.NewGuid().ToString() : appName;
        _backupFilename = appName ?? _backupFilename;
        var fileName = $"{appName}.log";
        _location = Path.Combine(exeLocation, "Logs");

        if (string.IsNullOrEmpty(fullFilePath))
        {
            fullFilePath = Path.Combine(_location, fileName);
        }
        else
        {
            _backupFilename = Path.GetFileNameWithoutExtension(fullFilePath);
            _location = Path.GetDirectoryName(fullFilePath) ?? _location;
        }

        _filename = fullFilePath ?? _filename;
        _logToConsole = logToConsole;

        // 10 MB Max size before creating backup - not set
        maxFileSizeBeforeLogRotation = (maxFileSizeBeforeLogRotation < -0) ? 10 : maxFileSizeBeforeLogRotation;
        _maxSizeInKiloBytes = 1000 * maxFileSizeBeforeLogRotation;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel))
        {
            return;
        }

        var builder = new StringBuilder();
        if (formatter is not null)
        {
            builder.Append(formatter(state, exception));
        }

        if (exception is not null)
        {
            builder.Append($" {exception.Message}");
        }

        Log(new LogEntry(logLevel, builder.ToString()));
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }


    /// <summary>
    /// Log entry.
    /// </summary>
    /// <param name="entry">The entry data.</param>
    private void Log(LogEntry entry)
    {
        lock (_lockObj)
        {
            try
            {
                if (entry is not null)
                {
                    WriteToFile(entry.ToString());

                    if (_logToConsole)
                    {
                        Console.WriteLine(entry);
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }

    private void WriteToFile(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return;
        }

        var directoryName = Path.GetDirectoryName(_filename);
        if (!string.IsNullOrWhiteSpace(directoryName))
        {
            Directory.CreateDirectory(directoryName);
        }

        var fileInfo = new FileInfo(_filename);
        if (fileInfo.Exists && ((fileInfo.Length / 1024) >= _maxSizeInKiloBytes))
        {
            CreateCopyOfCurrentLogFile(_filename);
        }

        var writer = new StreamWriter(_filename, true, Encoding.UTF8) { AutoFlush = true };
        writer.WriteLine(text);
        writer.Close();
        writer.Dispose();
    }

    private void CreateCopyOfCurrentLogFile(string filePath)
    {
        try
        {
            for (var i = 1; i < 999; i++)
            {
                var backupPath = Path.Combine(_location, "backup");
                if (!Directory.Exists(backupPath))
                {
                    Directory.CreateDirectory(backupPath);
                }

                string? backupFile = $"{_backupFilename}_{DateTime.Now:yyyyMMdd}_{i}.backup";
                var possibleFilePath = Path.Combine(backupPath, backupFile);
                if (!File.Exists(possibleFilePath))
                {
                    File.Move(filePath, possibleFilePath);
                    break;
                }
            }
        }
        catch { }
    }

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return null;
    }
}


public static class LoggerExtensions
{
    public static void LogError(this ILogger logger, Exception exception)
    {
        logger.LogError(exception, "{exception?.Message}", exception?.Message);
    }
}