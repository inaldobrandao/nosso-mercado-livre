using NossoMercadoLivre.Models.Entities;
using System.Threading.Tasks;

namespace NossoMercadoLivre.Helpers
{
    public interface ILoggedHelper
    {
        Task<User> GetUser(string usuarioId);
    }
}
