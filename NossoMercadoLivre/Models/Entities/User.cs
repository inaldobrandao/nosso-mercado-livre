using Dapper.Contrib.Extensions;
using NossoMercadoLivre.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace NossoMercadoLivre.Models.Entities
{
    [Table("Users")]
    public class User
    {
        [ExplicitKey]
        public Guid Id { get; }
        
        [Required]
        [EmailAddress]
        public string Username { get; }

        [Required]
        [MinLength(6)]
        public string Password { get; }
        public DateTime CreateAt { get; }

        public User(string username, string password)
        {
            Id = Guid.NewGuid();
            Username = username;
            Password = UserUtil.GenerateEncryptedPass(this, password); ;
            CreateAt = DateTime.Now.ToUniversalTime();
        }
    }
}
