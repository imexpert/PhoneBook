using Newtonsoft.Json;
using PhoneBook.Core.Utilities.Results;
using PhoneBook.Libraries.Book.Entities.ComplexTypes;
using PhoneBook.Libraries.Book.Entities.Concrete;
using PhoneBook.Web.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public Task<ResponseMessage<Person>> AddAsync(Person person)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseMessage<bool>> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseMessage<Person>> GetAsync(Guid id)
        {
            throw new NotImplementedException();
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

        public Task<ResponseMessage<Person>> UpdateAsync(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
