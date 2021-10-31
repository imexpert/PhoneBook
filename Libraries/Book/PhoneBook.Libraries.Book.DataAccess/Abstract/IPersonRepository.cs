using PhoneBook.Core.DataAccess;
using PhoneBook.Libraries.Book.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Libraries.Book.DataAccess.Abstract
{
    public interface IPersonRepository : IEntityRepository<Person>
    {

    }
}
