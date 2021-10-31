using PhoneBook.Core.Utilities.Results;
using PhoneBook.Libraries.Book.Entities.ComplexTypes;
using PhoneBook.Libraries.Book.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Web.Services.Abstract
{
    public interface IPersonService
    {
        Task<ResponseMessage<PersonDetailModel>> GetPersonDetailAsync(Guid id);
        Task<ResponseMessage<List<Person>>> GetListAsync();
        Task<ResponseMessage<Person>> AddAsync(Person person);
        Task<ResponseMessage<Person>> DeleteAsync(Guid id);
    }
}
