using NossoMercadoLivre.Models.Entities;
using NossoMercadoLivre.Services.Interfaces;
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

        public Question ToQuestion(Product product, User user, IEmailService emailService)
        {
            emailService.Send(Title, Description, user, product.User, ProductUrl);
            return new Question(Title, product, user);
        }
    }
}
