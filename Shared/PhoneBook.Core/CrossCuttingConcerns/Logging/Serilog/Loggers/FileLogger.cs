using System;
using System.IO;
using PhoneBook.Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using PhoneBook.Core.Utilities.IoC;
using PhoneBook.Core.Utilities.Messages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace PhoneBook.Core.CrossCuttingConcerns.Logging.Serilog.Loggers
{
    public class FileLogger2 : LoggerServiceBase
    {
        public FileLogger2()
        {
            var configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();

            var logConfig = configuration.GetSection("SeriLogConfigurations:FileLogConfiguration")
                                .Get<FileLogConfiguration>() ??
                            throw new Exception(SerilogMessages.NullOptionsMessage);

            var logFilePath = string.Format("{0}{1}", Directory.GetCurrentDirectory() + logConfig.FolderPath, ".txt");

            Logger = new LoggerConfiguration()
                .WriteTo.File(
                    logFilePath,
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: null,
                    fileSizeLimitBytes: 5000000,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}")
                .CreateLogger();
        }
    }
}