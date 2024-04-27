using System.Security.Claims;
using ErrorOr;
using LifeLink.ServiceErrors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LifeLink.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        if(errors.All(e => e.Type == ErrorType.Validation))
        {
            var modelStateDictionary = new ModelStateDictionary();

            foreach (var error in errors)
            {
                modelStateDictionary.AddModelError(error.Code, error.Description);
            }

            return ValidationProblem(modelStateDictionary);
        }

        if(errors.Any(e => e.Type == ErrorType.Unexpected))
        {
            return Problem();
        }

        var firstError = errors[0];

        var statusCode = firstError.Type switch 
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(statusCode: statusCode, title: firstError.Description, detail: firstError.Code);
    }

    protected ErrorOr<string> GetRequestOwnerId() 
    {
        var userClaims = HttpContext.User.Claims;

        var roleClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        if (roleClaim != null)
        {
            return roleClaim.Value;
        }

        return Errors.Identity.ClaimNotFound;
    }
}