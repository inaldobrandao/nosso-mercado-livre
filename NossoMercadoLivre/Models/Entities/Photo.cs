using System;
using Newtonsoft.Json;
using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;

namespace NossoMercadoLivre.Models.Entities
{
    [Table("Photos")]
    public class Photo : AllowRetrieveRelationId
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; private set; }
        [Required]
        public string? Url { get; }
        public int? ProductId { get; private set; }
        [Computed]
        [JsonIgnore]
        public Product Product { get; private set; }

        [Obsolete]
        public Photo()
        {

        }

        public Photo(string url, Product product)
        {
            Url = url;
            Product = product;
        }

        public void GetRelationId()
        {
            if (Product.Id is null)
                throw new ArgumentException();

            ProductId = Product.Id;
        }
    }
}