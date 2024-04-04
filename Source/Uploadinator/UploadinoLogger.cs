using NLog;
using System;
using Uploadino;

namespace Uploadinator;

public class UploadinoLogger : IUploadinoLogger
{
    private static readonly Logger Logger = LogManager.GetLogger("Uploadino");

    public void Error(string message, Exception exception)
    {
        Logger.Error(exception, message);
    }

    public void Warn(string message)
    {
        Logger.Warn(message);
    }

    public void Info(string message)
    {
        Logger.Info(message);
    }

    public void Debug(string message)
    {
        Logger.Debug(message);
    }

    public void Trace(string message)
    {
        Logger.Trace(message);
    }
}
