using CSharpRestfulAPI.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CSharpRestfulAPI.Filters.ExceptionFilters
{
    public class Shirt_HandleUpdateExceptionsFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var strShirId = context.RouteData.Values["id"] as string;

            if (int.TryParse(strShirId, out int shirtId))
            {
                if (!ShirtRepository.ShirtExists(shirtId))
                {
                    context.ModelState.AddModelError("ShirtId", "The shirt doesn't exist anymore");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }
        }
    }
}
