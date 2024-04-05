using System;

namespace Uploadino
{
    public class UploadinoException : Exception
    {
        public UploadinoException(string message) : base(message)
        {
        }
    }
}