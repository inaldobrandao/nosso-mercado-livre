using Dapper.Contrib.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace NossoMercadoLivre.Models.Entities
{
    [Table("Questions")]
    public class Question
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; private set; }
        [Required]
        public string Title { get; }
        public DateTime CreateAt { get; }
        public int? ProductId { get; }
        [Computed]
        public Product Product { get; }
        public string UserId { get; }
        [Computed]
        public User User { get; }

        [Obsolete]
        public Question()
        {

        }

        public Question(string title, Product product, User user)
        {
            Title = title;
            ProductId = product.Id;
            Product = product;
            UserId = user.Id;
            User = user;
            CreateAt = DateTime.Now.ToUniversalTime();
        }
    }
}
