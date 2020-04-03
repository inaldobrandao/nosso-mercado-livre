using Dapper.Contrib.Extensions;
using NossoMercadoLivre.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NossoMercadoLivre.Models.Entities
{
    [Table("Products")]
    public class Product
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; private set; }
        [Required]
        public string? Name { get; }
        [Required, Range(0, double.MaxValue), DataType(DataType.Currency)]
        public double Value { get; }
        [Required, Range(0, int.MaxValue)]
        public int Quantity { get; }
        [Required, MaxLength(1000)]
        public string? Description { get; }
        public DateTime CreateAt { get; }
        public string? UserId { get; }
        [Computed]
        public User? User { get; }
        [Required]
        public int CategoryId { get; }
        [Computed]
        public Category? Category { get; }
        [Computed]
        public IList<Photo> Photos { get; private set; } = new List<Photo>();
        [Computed]
        public IList<Characteristic> Characteristics { get; private set; } = new List<Characteristic>();

        [Obsolete]
        public Product()
        {

        }

        public Product(string name, double value, int quantity, string description, User user, Category category, 
            IList<string> urlPhotos, IList<CreateCharacteristcViewModel> characteristics)
        {
            Name = name;
            Value = value;
            Quantity = quantity;
            Description = description;
            UserId = user.Id;
            User = user;
            CategoryId = category.Id;
            Category = category;
            CreateAt = DateTime.Now.ToUniversalTime();
            ToPhotos(urlPhotos);
            ToCharacteristics(characteristics);
        }

        public void ToPhotos(IList<string> urlPhotos)
        {
            foreach(var url in urlPhotos)
            {
                Photo photo = new Photo(url, this);
                Photos.Add(photo);
            }
        }

        public void ToCharacteristics(IList<CreateCharacteristcViewModel> models)
        {
            foreach(var model in models)
            {
                Characteristic characteristic = new Characteristic(model.Name, model.Description, this);
                Characteristics.Add(characteristic);
            }
        }
    }
}
