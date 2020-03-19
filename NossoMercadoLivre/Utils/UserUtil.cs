using Microsoft.AspNetCore.Identity;
using NossoMercadoLivre.Models.Entities;

namespace NossoMercadoLivre.Utils
{
    public class UserUtil
    {
        public static string GeneratePass(User user, string pass)
        {
            try
            {
                PasswordHasher<User> pHasher = new PasswordHasher<User>();
                return pHasher.HashPassword(user, pass);
            }
            catch
            {
                throw new BaseException("Crete Password Failure", (int)EnumExceptionResponseCode.Auth.CREATE_PASS_FAILURE);
            }
        }
    }
}
