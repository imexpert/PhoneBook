using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Libraries.Book.DataAccess.Concrete.EntityFramework.Contexts;
using PhoneBook.Libraries.Book.Entities.Concrete;
using PhoneBook.Libraries.Book.Entities.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Libraries.Book.DataAccess.Concrete.Configurations
{
    public class PersonContactEntityConfiguration : BaseConfiguration<PersonContact>
    {
        public override void Configure(EntityTypeBuilder<PersonContact> builder)
        {
            builder.ToTable("PersonContacts", ProjectDbContext.DEFAULT_SCHEMA);

            builder.Property(x => x.ContactTypeId).IsRequired();
            builder.Property(x => x.Content).HasMaxLength(100).IsRequired();

            builder
                .HasOne<ContactTypes>()
                .WithMany()
                .IsRequired()
                .HasForeignKey("ContactTypeId");

            builder
                .HasOne<Person>()
                .WithMany()
                .IsRequired()
                .HasForeignKey("PersonId");

            base.Configure(builder);
        }
    }
}
