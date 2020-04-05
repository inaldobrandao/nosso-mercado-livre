using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NossoMercadoLivre.Helpers;
using NossoMercadoLivre.Models.Entities;
using NossoMercadoLivre.Models.ViewModels;
using NossoMercadoLivre.Repositories;
using NossoMercadoLivre.Services.Interfaces;
using System.Threading.Tasks;

namespace NossoMercadoLivre.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Products")]
    [Produces("application/json")]
    public class ProductController : Base
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUploadFileService _uploadFileService;

        public ProductController(
            ILoggedHelper logged,
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IUploadFileService uploadFileService
            ) : base (logged)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _uploadFileService = uploadFileService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm]CreateProductViewModel model)
        {
            Product product = await model.ToProduct(
                await UserLogged(),
                _categoryRepository,
                _uploadFileService
            );

            TransactionHelper.Transaction(() => _productRepository.Create(product));

            return Ok();
        }
    }
}
