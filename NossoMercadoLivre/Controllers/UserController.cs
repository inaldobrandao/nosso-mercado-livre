using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NossoMercadoLivre.Models.Entities;
using NossoMercadoLivre.Models.ViewModels;
using NossoMercadoLivre.Repositories;

namespace NossoMercadoLivre.Controllers
{
    [Route("api/User")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] CreateUserViewModel model)
        {
            if (!_userRepository.AnyUserByUsername(model.Username))
            {
                User newUser = model.ToUser();
                _userRepository.Create(newUser);
                return Ok();
            }
            
            return BadRequest("Não foi possível realizar cadastro com este email");
        }
    }
}
