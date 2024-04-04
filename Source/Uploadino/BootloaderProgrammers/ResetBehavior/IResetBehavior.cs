using RJCP.IO.Ports;

namespace Uploadino.BootloaderProgrammers.ResetBehavior
{
    internal interface IResetBehavior
    {
        SerialPortStream Reset(SerialPortStream serialPort, SerialPortConfig config);
    }
}