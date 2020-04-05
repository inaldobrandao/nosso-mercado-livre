using Microsoft.AspNetCore.Http;
using NossoMercadoLivre.Models.Entities;
using NossoMercadoLivre.Repositories;
using NossoMercadoLivre.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

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
        [MinLength(1, ErrorMessage = "Minimum 1 characteristics required")]
        public IList<IFormFile> Photos { get; set; }
        [MinLength(3, ErrorMessage = "Minimum 3 characteristics required")]
        public IList<CreateCharacteristcViewModel> Characteristics { get; set; }

        public async Task<Product> ToProduct(User user, ICategoryRepository _categoryRepository, IUploadFileService _uploadFileService)
        {
            Category? category = await _categoryRepository.FindById(CategoryId);
            if (category is null)
            {
                throw new ArgumentException("Category Not found");
            }

            var urlPhotos = _uploadFileService.UploadImages(Photos);

            return new Product(Name, Value, Quantity, Description, user, category, urlPhotos, Characteristics);
        }
    }
}
