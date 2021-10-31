using PhoneBook.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Libraries.Book.Entities.Concrete
{
    public class Person : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Company { get; set; }
    }
}
