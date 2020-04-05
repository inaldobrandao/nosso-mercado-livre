using Microsoft.AspNetCore.Http;
using NossoMercadoLivre.Models.Entities;
using NossoMercadoLivre.Repositories;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NossoMercadoLivre.Helpers
{
    public class LoggedHelper : ILoggedHelper
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContext;

        public LoggedHelper(IUserRepository userRepository, IHttpContextAccessor httpContext)
        {
            _userRepository = userRepository;
            _httpContext = httpContext;
        }

        public async Task<User> GetUser()
        {
            var userId = _httpContext.HttpContext.User.FindFirstValue("id");
            return await _userRepository.FindById(userId);
        }
    }
}
