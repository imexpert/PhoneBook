using System;
using PhoneBook.Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using PhoneBook.Core.Utilities.IoC;
using PhoneBook.Core.Utilities.Messages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace PhoneBook.Core.CrossCuttingConcerns.Logging.Serilog.Loggers
{
    public class MsTeamsLogger : LoggerServiceBase
    {
        public MsTeamsLogger()
        {
            var configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();

            var logConfig = configuration.GetSection("SeriLogConfigurations:MsTeamsConfiguration")
                                .Get<MsTeamsConfiguration>() ??
                            throw new Exception(SerilogMessages.NullOptionsMessage);

            Logger = new LoggerConfiguration()
                .WriteTo.MicrosoftTeams(logConfig.ChannelHookAddress)
                .CreateLogger();
        }
    }
}