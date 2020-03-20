using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NossoMercadoLivre.Models;
using NossoMercadoLivre.Models.Entities;
using NossoMercadoLivre.Models.ViewModels;
using NossoMercadoLivre.Repositories;

namespace NossoMercadoLivre.Controllers
{
    [Route("api/User")]
    [Produces("application/json")]
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
            if (ModelState.IsValid)
            {
                DecodedPassword decodedPassword = new DecodedPassword(model.Password);

                User newUser = new User(model.Username, decodedPassword);
                _userRepository.CreateUser(newUser);
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
