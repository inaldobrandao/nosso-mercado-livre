using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NossoMercadoLivre.Filters;
using NossoMercadoLivre.Models.Entities;
using NossoMercadoLivre.Models.ViewModels;
using NossoMercadoLivre.Repositories;
using System.Threading.Tasks;
using System.Transactions;

namespace NossoMercadoLivre.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Products")]
    [Produces("application/json")]
    public class ProductController : Base
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(
            IProductRepository productRepository,
            IUserRepository userRepository,
            ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpPost("Create")]
        [TypeFilter(typeof(ValidateProductAttribute))]
        public async Task<IActionResult> Create([FromForm]CreateProductViewModel model)
        {
            User user = await _userRepository.FindById(GetUserId());

            Category category = await _categoryRepository.FindById(model.CategoryId);
            if (category is null)
            {
                return BadRequest("Not found Category");
            }

            Product product = model.ToProduct(user, category);
            
            using TransactionScope transacao = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            _productRepository.Create(product);
            transacao.Complete();

            return Ok();
        }
    }
}
