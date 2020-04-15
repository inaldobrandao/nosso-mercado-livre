using Dapper.Contrib.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace NossoMercadoLivre.Models.Entities
{
    [Table("Emails")]
    public class Email
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; private set; }
        [Required]
        public string Title { get; }
        [Required]
        public string Body { get; }
        public DateTime CreateAt { get; }
        [Required]
        public string UserToId { get; }
        [Computed]
        public User UserTo { get; }
        [Required]
        public int QuestionId { get; }
        [Computed]
        public Question Question { get; }
        [Required]
        public string UserFromId { get; }
        [Computed]
        public User UserFrom { get; }

        [Obsolete]
        public Email() {}

        public Email(string title, string body, Question question)
        {
            Title = title;
            Body = body;
            CreateAt = DateTime.Now.ToUniversalTime();
            UserToId = question.Product.User.Id;
            UserTo = question.Product.User;
            UserFromId = question.User.Id;
            UserFrom = question.User;
            QuestionId = question.Id;
            Question = question;
        }
    }
}
