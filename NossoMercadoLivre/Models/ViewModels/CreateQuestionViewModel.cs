using NossoMercadoLivre.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace NossoMercadoLivre.Models.ViewModels
{
    public class CreateQuestionViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ProductUrl { get; set; }

        public Question ToQuestion(Product product, User user)
        {
            return new Question(Title, product, user);
        }
    }
}
