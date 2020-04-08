using Microsoft.Extensions.Configuration;
using NossoMercadoLivre.Models.Entities;
using NossoMercadoLivre.Repositories.Interfaces;

namespace NossoMercadoLivre.Repositories
{
    public class QuestionRepository : AbstractRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
