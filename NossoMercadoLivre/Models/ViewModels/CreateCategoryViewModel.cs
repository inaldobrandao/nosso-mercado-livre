using NossoMercadoLivre.Models.Entities;

namespace NossoMercadoLivre.Models.ViewModels
{
    public class CreateCategoryViewModel
    {
        public string Name { get; set; }
        public MotherCategory MotherCategory { get; set; }

        public Category ToCategory()
        {
            return new Category(Name, MotherCategory);
        }
    }
}
