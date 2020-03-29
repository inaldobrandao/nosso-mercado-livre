using Microsoft.AspNetCore.Http;
using NossoMercadoLivre.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NossoMercadoLivre.Models.ViewModels
{
    public class CreateProductViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required, Range(0, double.MaxValue), DataType(DataType.Currency)]
        public double Value { get; set; }
        [Required, Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        [Required, MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public IList<IFormFile> Photos { get; set; }
        public IList<CreateCharacteristcViewModel> Characteristics { get; set; }

        public Product ToProduct(User user, Category category)
        {
            IList<string> urlPhotos = new List<string>();
            foreach (var file in Photos)
            {
                //Poderia ter um serviço para fazer o upload das fotos
                urlPhotos.Add("https://nossomercadolivre.blob.net/photos-products/" + file.FileName);
            }

            return new Product(Name, Value, Quantity, Description, user, category, urlPhotos, Characteristics);
        }
    }
}
