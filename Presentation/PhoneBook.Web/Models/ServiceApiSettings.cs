using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Web.Models
{
    public class ServiceApiSettings
    {
        public string GatewayBaseUri { get; set; }
        public ServiceApi Book { get; set; }
    }

    public class ServiceApi
    {
        public string Path { get; set; }
    }
}
