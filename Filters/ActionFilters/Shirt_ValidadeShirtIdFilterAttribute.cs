using CSharpRestfulAPI.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CSharpRestfulAPI.Filters.ActionFilters
{
    public class Shirt_ValidadeShirtIdFilterAttribute : ActionFilterAttribute
    {
        // Triggered before the action executes
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var shirtId = context.ActionArguments["id"] as int?;
            if (shirtId.HasValue)
            {
                if (shirtId.Value <= 0)
                {
                    context.ModelState.AddModelError("ShirtId", "The id must be greater than zero");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                else if (!ShirtRepository.ShirtExists(shirtId.Value))
                {
                    context.ModelState.AddModelError("ShirtId", "The shirt doesn't exist");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }
        }

        // Triggered after the action executes
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}
