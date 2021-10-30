using PhoneBook.Core.Utilities.Results;
using PhoneBook.Libraries.Book.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Web.Services.Abstract
{
    public interface IPersonService
    {
        Task<ResponseMessage<Person>> GetAsync(Guid id);
        Task<ResponseMessage<List<Person>>> GetListAsync();
        Task<ResponseMessage<Person>> AddAsync(Person person);
        Task<ResponseMessage<Person>> UpdateAsync(Person person);
        Task<ResponseMessage<bool>> DeleteAsync(Guid id);
    }
}
