using Microsoft.Extensions.Configuration;
using NossoMercadoLivre.Models.Entities;
using NossoMercadoLivre.Repositories.Interfaces;

namespace NossoMercadoLivre.Repositories
{
    public class EmailRepository : AbstractRepository<Email>, IEmailRepository
    {
        public EmailRepository(IConfiguration configuration) : base(configuration) {}
    }
}
