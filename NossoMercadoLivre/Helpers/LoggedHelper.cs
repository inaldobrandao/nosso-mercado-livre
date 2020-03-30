using NossoMercadoLivre.Models.Entities;
using NossoMercadoLivre.Repositories;
using System.Threading.Tasks;

namespace NossoMercadoLivre.Helpers
{
    public class LoggedHelper : ILoggedHelper
    {
        private readonly IUserRepository _userRepository;

        public LoggedHelper(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUser(string usuarioId)
        {
            return await _userRepository.FindById(usuarioId);
        }
    }
}
