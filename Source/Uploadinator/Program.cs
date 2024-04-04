using System;
using Uploadino;
using CommandLine;
using Uploadinator;

var logger = new UploadinoLogger();
var commandLineOptions = Parser.Default.ParseArguments<CommandLineOptions>(args).Value;

if (commandLineOptions == null) return;

var options = new UploadinoOptions
{
    PortName = commandLineOptions.PortName,
    FileName = commandLineOptions.FileName,
    ArduinoModel = commandLineOptions.ArduinoModel
};

var progress = new Progress<double>(
    p => logger.Info($"Upload progress: {p * 100:F1}% ..."));

var uploader = new Uploadino.Uploadino(options, logger, progress);
try
{
    uploader.Upload();
    Environment.Exit((int)StatusCodes.Success);
}
catch (UploadinoException)
{
    Environment.Exit((int)StatusCodes.UploadinoException);
}
catch (Exception ex)
{
    logger.Error($"Unexpected exception: {ex.Message}!", ex);
    Environment.Exit((int)StatusCodes.GeneralRuntimeException);
}


