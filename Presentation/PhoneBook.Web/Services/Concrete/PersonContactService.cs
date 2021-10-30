using Newtonsoft.Json;
using PhoneBook.Core.Utilities.Results;
using PhoneBook.Libraries.Book.Entities.ComplexTypes;
using PhoneBook.Libraries.Book.Entities.Concrete;
using PhoneBook.Web.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Web.Services.Concrete
{
    public class PersonContactService : IPersonContactService
    {
        HttpClient _client;

        public PersonContactService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ResponseMessage<PersonContact>> AddAsync(PersonContact personContact)
        {
            string json = JsonConvert.SerializeObject(personContact,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

            using (StringContent content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                var response = await _client.PostAsync("PersonContacts/Add", content);

                // Get string data
                string data = await response.Content.ReadAsStringAsync();

                var group = JsonConvert.DeserializeObject<ResponseMessage<PersonContact>>(data);

                if (group.IsSuccess)
                {
                    await AddAsync(group.Data);
                }

                // Deserialize the data
                return group;
            }
        }

        public Task<ResponseMessage<bool>> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
