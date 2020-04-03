using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NossoMercadoLivre.Helpers;
using NossoMercadoLivre.Models.Entities;
using NossoMercadoLivre.Models.ViewModels;
using NossoMercadoLivre.Repositories;
using NossoMercadoLivre.Repositories.Interfaces;
using NossoMercadoLivre.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace NossoMercadoLivre.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Products")]
    [Produces("application/json")]
    public class ProductController : Controller
    {
        private readonly ILoggedHelper _logged;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUploadFileService _uploadFileService;
        private readonly IOpinionRepository _opinionRepository;

        public ProductController(
            IProductRepository productRepository,
            ILoggedHelper logged,
            ICategoryRepository categoryRepository,
            IUploadFileService uploadFileService,
            IOpinionRepository opinionRepository)
        {
            _logged = logged;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _uploadFileService = uploadFileService;
            _opinionRepository = opinionRepository;
        }

        private async Task<User> UserLogged()
        {
            return await _logged.GetUser();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm]CreateProductViewModel model)
        {
            Product product = await model.ToProduct(
                await UserLogged(),
                _categoryRepository,
                _uploadFileService
            );

            TransactionHelper.Transacao(() => _productRepository.Create(product));

            return Ok();
        }

        [HttpPost("/{productId}/opinion")]
        public async Task<IActionResult> CreateOpinion(int productId, [FromBody] CreateOpinionViewModel model)
        {
            Product product = await _productRepository.FindById(productId);
            if (product is null)
                throw new ArgumentException("Product Not found");

            Opinion opinion = model.ToOpinion(product, await UserLogged());

            _opinionRepository.Create(opinion);

            return Ok();
        }
    }
}
