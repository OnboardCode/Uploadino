using System;

namespace Uploadino
{
    public interface IUploadinoLogger
    {
        void Error(string message, Exception exception);

        void Warn(string message);

        void Info(string message);

        void Debug(string message);

        void Trace(string message);
    }
}
