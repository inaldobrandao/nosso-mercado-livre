using Dapper.Contrib.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace NossoMercadoLivre.Models.Entities
{
    [Table("Categories")]
    public class Category
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; private set; }
        [Required]
        public string? Name { get; }
        public int? CategoryMotherId { get; private set; }
        [Computed]
        public Category? CategoryMother { get; private set; }

        [Obsolete]
        public Category()
        {

        }

        public Category([Required] string? name)
        {
            Name = name;
        }

        public void SetCategoryMother(MotherCategory mother)
        {
            CategoryMother = new Category(mother.Name);
            CategoryMotherId = mother.CategoryMotherId;
        }
    }
}
