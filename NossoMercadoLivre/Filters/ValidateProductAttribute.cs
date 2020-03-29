using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NossoMercadoLivre.Models.ViewModels;
using System.Linq;

namespace NossoMercadoLivre.Filters
{
    public class ValidateProductAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var arguments = context.ActionArguments.FirstOrDefault();
            var type = arguments.Value.GetType().Name;
            switch (type)
            {
                case "CreateProductViewModel":
                    CreateProductViewModel model = (CreateProductViewModel)arguments.Value;
                    if (model.Photos.Count() < 1)
                        context.Result = new BadRequestObjectResult("");
                    if (model.Characteristics.Count() < 3)
                        context.Result = new BadRequestObjectResult("");
                    break;
                default:
                    context.Result = new BadRequestObjectResult("");
                    break;
            }
        }
    }
}
