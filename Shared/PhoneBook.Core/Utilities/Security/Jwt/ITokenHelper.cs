using PhoneBook.Core.Entities.Concrete;

namespace PhoneBook.Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        TAccessToken CreateToken<TAccessToken>(User user)

          where TAccessToken : IAccessToken, new();

        string GenerateRefreshToken();
    }
}