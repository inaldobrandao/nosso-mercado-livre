using NossoMercadoLivre.Models.Entities;

namespace NossoMercadoLivre.Services.Interfaces
{
    public interface IQuestionEmailService
    {
        void SendAndSave(string title, string description, User userFrom, Question question, string? urlRedirect);
    }
}
