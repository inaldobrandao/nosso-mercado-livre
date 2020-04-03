using NossoMercadoLivre.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace NossoMercadoLivre.Models.ViewModels
{
    public class CreateCategoryViewModel
    {
        [Required]
        public string Name { get; set; }
        public MotherCategory? MotherCategory { get; set; }

        public Category ToCategory()
        {
            Category category = new Category(Name);
            if(MotherCategory != null)
                category.SetCategoryMother(MotherCategory);
            return category;
        }
    }
}
