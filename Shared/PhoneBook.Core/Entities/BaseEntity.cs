using System;

namespace PhoneBook.Core.Entities
{
    public class BaseEntity : IEntity
    {
        public virtual Guid Id { get; set; }
    }
}
