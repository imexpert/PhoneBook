using PhoneBook.Core.Entities.Concrete;

namespace PhoneBook.Core.Utilities.URI
{
    public interface IUriService
    {
        System.Uri GeneratePageRequestUri(PaginationFilter filter, string route);
    }
}