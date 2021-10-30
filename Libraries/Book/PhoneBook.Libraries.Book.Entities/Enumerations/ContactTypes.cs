using PhoneBook.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Libraries.Book.Entities.Enumerations
{
    public class ContactTypes : Enumeration
    {
        public ContactTypes(int id, string name) :
            base(id, name)
        {

        }

        public static ContactTypes PhoneNumber = new ContactTypes(1, "Phone Number");
        public static ContactTypes Email = new ContactTypes(2, "Email Address");
        public static ContactTypes Location = new ContactTypes(3, "Location");
    }
}
