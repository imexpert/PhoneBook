using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Libraries.Book.DataAccess.Concrete.EntityFramework.Contexts;
using PhoneBook.Libraries.Book.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Libraries.Book.DataAccess.Concrete.Configurations
{
    public class PersonEntityConfiguration : BaseConfiguration<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons", ProjectDbContext.DEFAULT_SCHEMA);

            builder.Property(x => x.Firstname).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Lastname).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Company).HasMaxLength(150).IsRequired();

            base.Configure(builder);
        }
    }
}
