using Microsoft.AspNetCore.Identity;
using NossoMercadoLivre.Models.Entities;

namespace NossoMercadoLivre.Utils
{
    public class UserUtil
    {
        public static string EncodePassword(User user, string pass)
        {
            PasswordHasher<User> pHasher = new PasswordHasher<User>();
            return pHasher.HashPassword(user, pass);
        }
    }
}
