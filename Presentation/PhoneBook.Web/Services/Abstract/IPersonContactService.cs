using PhoneBook.Core.Utilities.Results;
using PhoneBook.Libraries.Book.Entities.ComplexTypes;
using PhoneBook.Libraries.Book.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Web.Services.Abstract
{
    public interface IPersonContactService
    {
        Task<ResponseMessage<PersonContact>> AddAsync(PersonContact personContact);
        Task<ResponseMessage<bool>> DeleteAsync(Guid id);
    }
}
