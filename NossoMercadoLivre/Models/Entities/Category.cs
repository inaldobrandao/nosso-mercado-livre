using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;

namespace NossoMercadoLivre.Models.Entities
{
    [Table("Categories")]
    public class Category
    {
        [Dapper.Contrib.Extensions.Key]
        public long Id { get; private set; }
        [Required]
        public string Name { get; }
        public long? CategoryMotherId { get; }
        [Computed]
        public Category CategoryMother { get; }

        public Category([Required] string name, MotherCategory motherCategory)
        {
            Name = name;
            CategoryMotherId = motherCategory?.CategoryMotherId;
        }
    }
}
