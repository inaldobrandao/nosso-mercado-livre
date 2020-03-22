using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NossoMercadoLivre.Models.Entities;
using NossoMercadoLivre.Models.ViewModels;
using NossoMercadoLivre.Repositories;

namespace NossoMercadoLivre.Controllers
{
    [Route("api/Category")]
    [Produces("application/json")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] CreateCategoryViewModel model)
        {
            if (!_categoryRepository.AnyUserByName(model.Name))
            {
                Category newCategory = model.ToCategory();
                _categoryRepository.Create(newCategory);
                return Ok();
            }

            return BadRequest("Não foi possível criar categoria com este nome. :(");
        }
    }
}
