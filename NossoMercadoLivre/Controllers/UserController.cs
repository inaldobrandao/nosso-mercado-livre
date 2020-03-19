using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NossoMercadoLivre.Models.ViewModels;
using NossoMercadoLivre.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NossoMercadoLivre.Controllers
{
    [Route("api/User")]
    [Produces("application/json")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseViewModel), 400)]
        public IActionResult Create([FromBody] CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _userService.Create(model);
                    return Ok();
                }
                catch(BaseException e)
                {
                    return BadRequest(new ErrorResponseViewModel { Error = new Error(e.Message, e.Type, e.Code) });
                }
                catch(Exception e)
                {
                    BaseException exception = new BaseException("Create User Failure - " + e.Message, (int)EnumExceptionResponseCode.Auth.CREATE_USER_FAILURE);
                    return BadRequest(new ErrorResponseViewModel { Error = new Error(exception.Message, exception.Type, exception.Code) });
                }
            }
            return BadRequest(ModelState);
        }
    }
}
