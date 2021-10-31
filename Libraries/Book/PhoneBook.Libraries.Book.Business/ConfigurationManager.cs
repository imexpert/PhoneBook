using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Libraries.Book.Business
{
    public enum ApplicationMode
    {
        Development,
        Production,
    }

    public class ConfigurationManager
    {
        private readonly IConfiguration _configuration;

        public ConfigurationManager(IConfiguration configuration, IHostEnvironment env)
        {
            _configuration = configuration;
            Mode = (ApplicationMode)Enum.Parse(typeof(ApplicationMode), env.EnvironmentName);
        }

        public ApplicationMode Mode { get; private set; }
    }
}
