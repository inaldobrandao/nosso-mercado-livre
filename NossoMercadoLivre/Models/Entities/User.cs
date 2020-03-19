using System;
using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;

namespace NossoMercadoLivre.Models.Entities
{
    [Table("Users")]
    public class User
    {
        [ExplicitKey]
        public Guid Id { get; set; }
        
        [Required]
        [EmailAddress]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
            CreateAt = DateTime.Now.ToUniversalTime();
            UpdateAt = DateTime.Now.ToUniversalTime();
        }
    }
}
