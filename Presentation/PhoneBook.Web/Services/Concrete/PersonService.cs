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
    public class PersonService : IPersonService
    {
        HttpClient _client;

        public PersonService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ResponseMessage<Person>> AddAsync(Person person)
        {
            string json = JsonConvert.SerializeObject(person,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

            using (StringContent content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                var response = await _client.PostAsync("Persons/Add", content);

                // Get string data
                string data = await response.Content.ReadAsStringAsync();

                var contact = JsonConvert.DeserializeObject<ResponseMessage<Person>>(data);

                // Deserialize the data
                return contact;
            }
        }

        public async Task<ResponseMessage<Person>> DeleteAsync(Guid id)
        {
            string json = JsonConvert.SerializeObject(id,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

            using (StringContent content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                var response = await _client.PutAsync("Persons/Delete", content);

                // Get string data
                string data = await response.Content.ReadAsStringAsync();

                var contact = JsonConvert.DeserializeObject<ResponseMessage<Person>>(data);

                // Deserialize the data
                return contact;
            }
        }

        public async Task<ResponseMessage<List<Person>>> GetListAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("Persons/GetAll");
            string data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ResponseMessage<List<Person>>>(data);
        }

        public async Task<ResponseMessage<PersonDetailModel>> GetPersonDetailAsync(Guid id)
        {
            HttpResponseMessage response = await _client.GetAsync("Persons/GetPersonDetail?id=" + id);
            string data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ResponseMessage<PersonDetailModel>>(data);
        }
    }
}
