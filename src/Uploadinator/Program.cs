using System;
using Uploadino;
using Uploadinator;
using McMaster.Extensions.CommandLineUtils;
using Uploadino.Hardware;

var logger = new UploadinoLogger();
var app = new CommandLineApplication
{
    Name = "uploadinator",
    Description = "A simple .hex arduino flasher",
};

app.HelpOption(inherited: true); 

app.OnExecute(() =>
{
    app.Description = "upload a .hex file to a board listed in a serial port";
    app.AllowArgumentSeparator = true;
    app.ShowInHelpText = true;
    var port = app.Option<string>("-port", "COM port", CommandOptionType.SingleValue).IsRequired();
    var board = app.Option<ArduinoModel>("-board", "Arduino board", CommandOptionType.SingleValue).IsRequired();
    var file = app.Option<string>("file", "file path", CommandOptionType.SingleValue).IsRequired();

    if (!port.HasValue())
    {
        Console.Error.WriteLine("Missing COM port");
        return 0;
    }
    if (!board.HasValue())
    {
        Console.Error.WriteLine("Missing board model");
        return 0;
    }
    if (!file.HasValue())
    {
        Console.Error.WriteLine("Missing file path");
        return 0;
    }

    UploadinoOptions options = new UploadinoOptions()
    {
        ArduinoModel = board.ParsedValue,
        FileName = file.Value(),
        PortName = port.Value()
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

    return 1;
});



return app.Execute(args);
