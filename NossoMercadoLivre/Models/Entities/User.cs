using Dapper.Contrib.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace NossoMercadoLivre.Models.Entities
{
    [Table("Users")]
    public class User
    {
        [ExplicitKey]
        public string? Id { get; }
        
        [Required, EmailAddress]
        public string? Username { get; }

        [Required, MinLength(6)]
        public string? Password { get; }
        public DateTime CreateAt { get; }

        [Obsolete]
        private User()
        {

        }

        public User([Required, EmailAddress] string? username, [Required] DecodedPassword decodedPassword)
        {
            Id = Guid.NewGuid().ToString();
            Username = username;
            CreateAt = DateTime.Now.ToUniversalTime();
            Password = decodedPassword.EncodeCleanPassword(this);
        }
    }
}
