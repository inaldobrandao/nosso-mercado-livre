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
    }
}
