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
    public class ContactTypeConfiguration : IEntityTypeConfiguration<ContactTypes>
    {
        public void Configure(EntityTypeBuilder<ContactTypes> builder)
        {
            builder.ToTable("ContactTypes", ProjectDbContext.DEFAULT_SCHEMA);
            builder.HasKey(s => s.Id);

            builder
                .Property(s => s.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            builder
                .Property(s => s.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasData(
                new ContactTypes(1, "Phone Number"),
                new ContactTypes(2, "E-Mail Address"),
                new ContactTypes(3, "Location"));
        }
    }
}
