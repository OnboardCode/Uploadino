namespace Uploadino.BootloaderProgrammers.Protocols.AVR109.Messages
{
    internal class EnterProgrammingModeRequest : Request
    {
        internal EnterProgrammingModeRequest()
        {
            Bytes = new[]
            {
                Constants.CmdEnterProgrammingMode
            };
        }
    }
}