using Dapper.Contrib.Extensions;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace NossoMercadoLivre.Models.Entities
{
    [Table("Opinions")]
    public class Opinion
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; private set; }
        [Required]
        public string Title { get; }
        [Required, MaxLength(500)]
        public string Description { get; }
        [Range(1, 5)]
        public int Rating { get; }
        public int? ProductId { get; set; }
        [Computed]
        [JsonIgnore]
        public Product Product { get; set; }
        public string UserId { get; set; }
        [Computed]
        [JsonIgnore]
        public User User { get; set; }

        [Obsolete]
        public Opinion()
        {

        }

        public Opinion(string title, string description, int rating, Product product, User user)
        {
            Title = title;
            Description = description;
            Rating = rating;
            ProductId = product.Id;
            Product = product;
            UserId = user.Id;
            User = user;
        }
    }
}
