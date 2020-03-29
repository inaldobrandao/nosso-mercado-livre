using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NossoMercadoLivre.Models.Entities;
using NossoMercadoLivre.Models.ViewModels;
using NossoMercadoLivre.Repositories;
using NossoMercadoLivre.Services.Interfaces;
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
        private readonly IUploadFileService _uploadFileService;

        public ProductController(
            IProductRepository productRepository,
            IUserRepository userRepository,
            ICategoryRepository categoryRepository,
            IUploadFileService uploadFileService)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _uploadFileService = uploadFileService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm]CreateProductViewModel model)
        {
            User user = await GetLoggedUser(_userRepository);

            Product product = await model.ToProduct(user, _categoryRepository, _uploadFileService);
            
            using TransactionScope transacao = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            _productRepository.Create(product);
            transacao.Complete();

            return Ok();
        }
    }
}
