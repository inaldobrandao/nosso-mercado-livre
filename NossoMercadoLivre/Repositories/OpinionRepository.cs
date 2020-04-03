using Microsoft.Extensions.Configuration;
using NossoMercadoLivre.Models.Entities;
using NossoMercadoLivre.Repositories.Interfaces;

namespace NossoMercadoLivre.Repositories
{
    public class OpinionRepository : AbstractRepository<Opinion>, IOpinionRepository
    {
        public OpinionRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
