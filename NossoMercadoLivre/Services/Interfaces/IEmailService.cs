using NossoMercadoLivre.Models.Entities;

namespace NossoMercadoLivre.Services.Interfaces
{
    public interface IEmailService
    {
        void Send(string title, string description, User userFrom, User userTo, string? urlRedirect);
    }
}
