using Dapper.Contrib.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace NossoMercadoLivre.Models.Entities
{
    [Table("Users")]
    public class User
    {
        [ExplicitKey]
        public Guid Id { get; }
        
        [Required, EmailAddress]
        public string Username { get; }

        [Required, MinLength(6)]
        public string Password { get; }
        public DateTime CreateAt { get; }

        public User([Required, EmailAddress] string username, [Required] DecodedPassword decodedPassword)
        {
            Id = Guid.NewGuid();
            Username = username;
            CreateAt = DateTime.Now.ToUniversalTime();
            Password = DecodedPassword.EncodeCleanPassword(this, decodedPassword.Password);
        }
    }
}
