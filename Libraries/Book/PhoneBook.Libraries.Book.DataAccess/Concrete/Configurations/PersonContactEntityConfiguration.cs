using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Libraries.Book.DataAccess.Concrete.EntityFramework.Contexts;
using PhoneBook.Libraries.Book.Entities.Concrete;
namespace PhoneBook.Libraries.Book.DataAccess.Concrete.Configurations
{
    public class PersonContactEntityConfiguration : BaseConfiguration<PersonContact>
    {
        public override void Configure(EntityTypeBuilder<PersonContact> builder)
        {
            builder.ToTable("PersonContacts", ProjectDbContext.DEFAULT_SCHEMA);

            builder.Property(x => x.PhoneNumber).HasMaxLength(15).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Location).HasMaxLength(50).IsRequired();

            base.Configure(builder);
        }
    }
}
