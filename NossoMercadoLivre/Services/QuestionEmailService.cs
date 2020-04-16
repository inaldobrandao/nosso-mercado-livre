using NossoMercadoLivre.Models.Entities;
using NossoMercadoLivre.Repositories.Interfaces;
using NossoMercadoLivre.Services.Interfaces;

namespace NossoMercadoLivre.Services
{
    public class QuestionEmailService : IQuestionEmailService
    {
        private readonly IEmailService _emailService;
        private readonly IEmailRepository _emailRepository;

        public QuestionEmailService(IEmailService emailService, IEmailRepository emailRepository)
        {
            _emailService = emailService;
            _emailRepository = emailRepository;
        }

        public void SendAndSave(string title, string description, User userFrom, Question question, string? urlRedirect)
        {
            _emailService.Send(title, description, userFrom, question.Product.User, urlRedirect);
            Email email = new Email(title, description, question);
            _emailRepository.Create(email);
        }
    }
}
