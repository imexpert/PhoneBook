using PhoneBook.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Libraries.Book.Entities.Enumerations
{
    public class ContactType : Enumeration
    {
        public ContactType(int id, string name) :
            base(id, name)
        {

        }

        public static ContactType PhoneNumber = new ContactType(1, "Phone Number");
        public static ContactType Email = new ContactType(2, "Email Address");
        public static ContactType Location = new ContactType(3, "Location");
    }
}
