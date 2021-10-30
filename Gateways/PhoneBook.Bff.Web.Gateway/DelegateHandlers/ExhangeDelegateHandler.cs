using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.Bff.Web.Gateway.DelegateHandlers
{
    public class ExhangeDelegateHandler : DelegatingHandler
    {
        private readonly HttpClient _httpClient;

        public ExhangeDelegateHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
