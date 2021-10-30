using PhoneBook.Core.Entities;
using PhoneBook.Libraries.Book.Entities.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Libraries.Book.Entities.Concrete
{
    public class PersonContact : BaseEntity
    {
        public Guid PersonId { get; set; }
        public int ContactTypeId { get; set; }
        public string Content { get; set; }
        public virtual Person Person { get; set; }
        public virtual ContactTypes ContactType { get; set; }
    }
}
