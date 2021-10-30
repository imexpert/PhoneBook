using PhoneBook.Libraries.Book.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Libraries.Book.Entities.ComplexTypes
{
    public class PersonDetailModel
    {
        public Person Person { get; set; }
        public IEnumerable<PersonContact> PersonContacts { get; set; }
    }
}
