using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NossoMercadoLivre.Helpers;
using NossoMercadoLivre.Models.Entities;
using NossoMercadoLivre.Models.ViewModels;
using NossoMercadoLivre.Repositories;
using NossoMercadoLivre.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace NossoMercadoLivre.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Products")]
    [Produces("application/json")]
    public class OpinionController : Base
    {
        private readonly IProductRepository _productRepository;
        private readonly IOpinionRepository _opinionRepository;

        public OpinionController(
            ILoggedHelper logged,
            IProductRepository productRepository,
            IOpinionRepository opinionRepository
            ) : base(logged)
        {
            _productRepository = productRepository;
            _opinionRepository = opinionRepository;
        }


        [HttpPost("/{productId}/opinion")]
        public async Task<IActionResult> CreateOpinion(int productId, [FromBody] CreateOpinionViewModel model)
        {
            Product? product = await _productRepository.FindById(productId);
            if (product is null)
                throw new ArgumentException("Product Not found");

            Opinion opinion = model.ToOpinion(product, await UserLogged());

            _opinionRepository.Create(opinion);

            return Ok();
        }
    }
}
