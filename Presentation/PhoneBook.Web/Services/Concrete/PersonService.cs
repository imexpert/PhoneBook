using PhoneBook.Core.Utilities.Results;
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

        public Task<ResponseMessage<List<Person>>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseMessage<Person>> UpdateAsync(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
