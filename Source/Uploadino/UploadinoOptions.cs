using Uploadino.Hardware;

namespace Uploadino
{
    public class UploadinoOptions
    {
        public string FileName { get; set; }

        public string PortName { get; set; }

        public ArduinoModel ArduinoModel { get; set; }
    }
}