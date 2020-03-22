using NossoMercadoLivre.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace NossoMercadoLivre.Models.ViewModels
{
    public class CreateUserViewModel
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        public User ToUser()
        {
            DecodedPassword decodedPassword = new DecodedPassword(this.Password);
            return new User(this.Username, decodedPassword);            
        }
    }
}
