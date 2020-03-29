using System.ComponentModel.DataAnnotations;

namespace NossoMercadoLivre.Models.ViewModels
{
    public class CreateCharacteristcViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
