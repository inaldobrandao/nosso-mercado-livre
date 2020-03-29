﻿using Dapper.Contrib.Extensions;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace NossoMercadoLivre.Models.Entities
{
    [Table("Characteristics")]
    public class Characteristic : ISetProductRelationship
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; }
        [Required]
        public string Name { get; }
        [Required]
        public string Description { get; }
        public int ProductId { get; private set; }
        [Computed]
        [JsonIgnore]
        public Product Product { get; private set; }

        [Obsolete]
        public Characteristic()
        {

        }

        public Characteristic(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void SetProductRelationship(Product product)
        {
            ProductId = product.Id;
            Product = product;
        }
    }
}