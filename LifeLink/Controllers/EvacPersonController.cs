using LifeLink.Contracts.EvacPerson;
using Microsoft.AspNetCore.Mvc;

namespace LifeLink.Controllers;

[ApiController]
public class EvacPersonController : ControllerBase 
{
    [HttpPost("/evacPerson")]
    public IActionResult CreateEvacPerson(CreateEvacPersonRequest request) 
    {
        return Ok(request);
    }

    [HttpGet("/evacPerson/{id:guid}")]
    public IActionResult GetEvacPerson(Guid id) 
    {
        return Ok(id);
    }

    [HttpPut("/evacPerson/{id:guid}")]
    public IActionResult UpsertEvacPerson(Guid id, UpsertEvacPersonRequest request) 
    {
        return Ok(request);
    }

    [HttpDelete("/evacPerson/{id:guid}")]
    public IActionResult DeleteEvacPerson(Guid id) 
    {
        return Ok(id);
    }
}