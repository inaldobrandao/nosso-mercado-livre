using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NossoMercadoLivre.Auth;
using NossoMercadoLivre.Models;
using NossoMercadoLivre.Models.Entities;
using NossoMercadoLivre.Models.ViewModels;
using NossoMercadoLivre.Repositories;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NossoMercadoLivre.Controllers
{
    [ApiController]
    [Route("api/Auth")]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;

        public AuthController(IUserRepository userRepository, IOptions<JwtIssuerOptions> jwtOptions, IJwtFactory jwtFactory)
        {
            _userRepository = userRepository;
            _jwtOptions = jwtOptions.Value;
            _jwtFactory = jwtFactory;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]CredentialsViewModel credentials)
        {
            var identity = await GetClaimsIdentity(credentials?.Username, credentials?.Password);
            
            if (identity == null)
            {
                return BadRequest("Invalid username or password.");
            }

            var response = new
            {
                id = identity.Claims.Single(c => c.Type == "id").Value,
                auth_token = await _jwtFactory.GenerateEncodedToken(credentials?.Username, identity),
                expires_in = (int)_jwtOptions.ValidFor.TotalSeconds
            };

            return Ok(response);
        }

        private async Task<ClaimsIdentity?> GetClaimsIdentity(string? username, string? password)
        {

            User? user = _userRepository.GetUserByUsername(username);

            if (user != null)
            {
                PasswordHasher<User> pHasher = new PasswordHasher<User>();

                PasswordVerificationResult pvResult = pHasher.VerifyHashedPassword(user, user.Password, password);
                if (pvResult == PasswordVerificationResult.Success)
                {
                    return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(username, user.Id));
                }
            }

            return await Task.FromResult<ClaimsIdentity?>(null);
        }
    }
}
