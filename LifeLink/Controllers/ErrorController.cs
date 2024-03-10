using Microsoft.AspNetCore.Mvc;

namespace LifeLink.Contracts;

[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : ControllerBase
{
    [Route("/error")]

    public IActionResult Error() 
    {
        return Problem();
    }
}