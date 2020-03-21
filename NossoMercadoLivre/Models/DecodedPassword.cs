using Microsoft.AspNetCore.Identity;
using NossoMercadoLivre.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace NossoMercadoLivre.Models
{
    public class DecodedPassword
    {
        [Required, MinLength(6)]
        public string Password { get; }

        public DecodedPassword([Required, MinLength(6)] string password)
        {
            Password = password;
        }

        public static string EncodeCleanPassword(User user, string password)
        {
            PasswordHasher<User> pHasher = new PasswordHasher<User>();
            return pHasher.HashPassword(user, password);
        }
    }
}
