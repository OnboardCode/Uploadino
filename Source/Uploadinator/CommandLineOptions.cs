﻿using Uploadino.Hardware;
using CommandLine; 
namespace Uploadinator;

internal class CommandLineOptions
{
    [Option('f', "file", Required = true,
        HelpText = "Path to the input file (in intel HEX format) which is to be uploaded to the Arduino.")]
    public string FileName { get; set; }

    [Option('p', "port", Required = false,
        HelpText = "Name of the COM port where the Arduino is attached (e.g. 'COM1', 'COM2', 'COM3'...).")]
    public string PortName { get; set; }

    [Option('m', "model", Required = true,
        HelpText = "Arduino model. Valid parameters are any of the following: "
            + "[Leonardo, Mega1284, Mega2560, Micro, NanoR2, NanoR3, UnoR3].")]
    public ArduinoModel ArduinoModel { get; set; }

}
internal enum StatusCodes
{
    Success,
    UploadinoException,
    GeneralRuntimeException
}