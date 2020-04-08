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
    [Route("api/Question")]
    [Produces("application/json")]
    public class QuestionController : Base
    {
        private readonly IProductRepository _productRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IEmailService _emailService;

        public QuestionController(
            ILoggedHelper logged,
            IProductRepository productRepository,
            IQuestionRepository questionRepository,
            IEmailService emailService
            ) : base (logged)
        {
            _productRepository = productRepository;
            _questionRepository = questionRepository;
            _emailService = emailService;
        }

        [HttpPost("/{productId}/question")]
        public async Task<IActionResult> Create(int productId, [FromBody] CreateQuestionViewModel model)
        {
            Product? product = await _productRepository.FindById(productId);
            if (product is null)
                throw new ArgumentException("Product Not found");

            Question question = model.ToQuestion(product, await UserLogged(), _emailService);

            _questionRepository.Create(question);

            return Ok();
        }
    }
}
