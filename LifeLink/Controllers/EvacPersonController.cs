using LifeLink.Contracts.EvacPerson;
using LifeLink.Models;
using Microsoft.AspNetCore.Mvc;

namespace LifeLink.Controllers;

[ApiController]
[Route("evacPerson")]
public class EvacPersonController : ControllerBase 
{
    [HttpPost()]
    public IActionResult CreateEvacPerson(CreateEvacPersonRequest request) 
    {
        var evacPerson = new EvacPerson(
            Guid.NewGuid(),
            Guid.Empty,
            DateTime.UtcNow,
            Guid.Empty,
            DateTime.Now,
            request.Name,
            request.Surname,
            request.BirthDay,
            request.Description
        );

        // TODO: save evacPerson to db

        var response = new EvacPersonResponse(
            evacPerson.Id,
            evacPerson.CreatorId,
            evacPerson.CreateTime,
            evacPerson.ModifierId,
            evacPerson.ModifyTime,
            evacPerson.Name,
            evacPerson.Surname,
            evacPerson.BirthDate,
            evacPerson.Description
        );

        return CreatedAtAction(
            actionName: nameof(GetEvacPerson),
            routeValues: new { id = evacPerson.Id },
            value: response
        );
    }

    [HttpGet("/{id:guid}")]
    public IActionResult GetEvacPerson(Guid id) 
    {
        return Ok(id);
    }

    [HttpPut("/{id:guid}")]
    public IActionResult UpsertEvacPerson(Guid id, UpsertEvacPersonRequest request) 
    {
        return Ok(request);
    }

    [HttpDelete("/{id:guid}")]
    public IActionResult DeleteEvacPerson(Guid id) 
    {
        return Ok(id);
    }
}