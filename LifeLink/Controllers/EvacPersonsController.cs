using LifeLink.Contracts.EvacPerson;
using Microsoft.AspNetCore.Mvc;

namespace LifeLink.Controllers;

[ApiController]
public class EvacPersonsController : ControllerBase 
{
    [HttpPost("/evacPersons")]
    public IActionResult CreateEvacPerson(CreateEvacPersonRequest request) 
    {
        return Ok(request);
    }

    [HttpGet("/evacPersons/{id:guid}")]
    public IActionResult GetEvacPerson(Guid id) 
    {
        return Ok(id);
    }

    [HttpPut("/evacPersons/{id:guid}")]
    public IActionResult UpsertEvacPerson(Guid id, UpsertEvacPersonRequest request) 
    {
        return Ok(request);
    }

    [HttpDelete("/evacPersons/{id:guid}")]
    public IActionResult DeleteEvacPerson(Guid id) 
    {
        return Ok(id);
    }
}