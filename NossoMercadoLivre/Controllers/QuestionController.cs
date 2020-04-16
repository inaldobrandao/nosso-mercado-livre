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
        private readonly IQuestionEmailService _quesionEmailService;

        public QuestionController(
            ILoggedHelper logged,
            IProductRepository productRepository,
            IQuestionRepository questionRepository,
            IQuestionEmailService quesionEmailService
            ) : base (logged)
        {
            _productRepository = productRepository;
            _questionRepository = questionRepository;
            _quesionEmailService = quesionEmailService;
        }

        [HttpPost("/{productId}/question")]
        public async Task<IActionResult> Create(int productId, [FromBody] CreateQuestionViewModel model)
        {
            Product? product = await _productRepository.FindById(productId);
            if (product is null)
                throw new ArgumentException("Product Not found");

            User user = await UserLogged();

            Question question = model.ToQuestion(product, user);

            _questionRepository.Create(question);

            _quesionEmailService.SendAndSave(model.Title, model.Description, user, question, model.ProductUrl);

            return Ok();
        }
    }
}
