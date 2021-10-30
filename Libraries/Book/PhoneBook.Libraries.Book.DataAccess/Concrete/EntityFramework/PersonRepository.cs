using PhoneBook.Core.DataAccess.Postgres;
using PhoneBook.Libraries.Book.DataAccess.Abstract;
using PhoneBook.Libraries.Book.DataAccess.Concrete.EntityFramework.Contexts;
using PhoneBook.Libraries.Book.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Libraries.Book.DataAccess.Concrete.EntityFramework
{
    public class PersonRepository : EntityRepositoryBase<Person, ProjectDbContext>, IPersonRepository
    {
        public PersonRepository(ProjectDbContext context)
            : base(context)
        {
        }
    }
}
