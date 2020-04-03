using NossoMercadoLivre.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace NossoMercadoLivre.Models.ViewModels
{
    public class CreateOpinionViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required, MaxLength(500)]
        public string Description { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }

        public Opinion ToOpinion(Product product, User user)
        {
            return new Opinion(Title, Description, Rating, product, user);
        }
    }
}
