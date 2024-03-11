using ErrorOr;
using LifeLink.Contracts.EvacPerson;
using LifeLink.Models;
using LifeLink.Repositories.EvacPersons;
using LifeLink.ServiceErrors;
using LifeLink.Services.EvacPersons;
using Microsoft.AspNetCore.Mvc;

namespace LifeLink.Controllers;


[Route("evacPerson")]
public class EvacPersonController(IEvacPersonService evacPersonService) : ApiController 
{
    private readonly IEvacPersonService _evacPersonService = evacPersonService;

    [HttpPost()]
    public IActionResult CreateEvacPerson(CreateEvacPersonRequest request) 
    {
        ErrorOr<EvacPerson> requestToEvacPersonResult = EvacPerson.From(request);

        if(requestToEvacPersonResult.IsError) {
            return Problem(requestToEvacPersonResult.Errors);
        }

        var evacPerson = requestToEvacPersonResult.Value;
        ErrorOr<Created> createEvacPersonResult = _evacPersonService.CreateEvacPerson(evacPerson);

        return createEvacPersonResult.Match(
            created => CreatedAtGetEvacPerson(evacPerson),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetEvacPerson(Guid id) 
    {
        ErrorOr<EvacPerson> getEvacPersonResult = _evacPersonService.GetEvacPerson(id);

        return getEvacPersonResult.Match(
            evacPerson => Ok(MapEvacPersonToResponse(evacPerson)),
            errors => Problem(errors));      
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertEvacPerson(Guid id, UpsertEvacPersonRequest request) 
    {
        ErrorOr<EvacPerson> requestToEvacPersonResult = EvacPerson.From(id, request);

        if(requestToEvacPersonResult.IsError) {
            return Problem(requestToEvacPersonResult.Errors);
        }

        var evacPerson = requestToEvacPersonResult.Value;
        ErrorOr<UpsertedEvacPerson> upsertEvacPersonResult = _evacPersonService.UpsertEvacPerson(evacPerson);

        return upsertEvacPersonResult.Match(
            upserted => upserted.IsNewlyCreated ? CreatedAtGetEvacPerson(evacPerson) : NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteEvacPerson(Guid id) 
    {
         ErrorOr<Deleted> deleteEvacPersonResult =  _evacPersonService.DeleteEvacPerson(id);

         return deleteEvacPersonResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }

    private static EvacPersonResponse MapEvacPersonToResponse(EvacPerson evacPerson)
    {
        var response = new EvacPersonResponse(
            evacPerson.Id,
            evacPerson.CreatorId,
            evacPerson.CreateTime,
            evacPerson.ModifierId,
            evacPerson.ModifyTime,
            evacPerson.Name,
            evacPerson.BirthDate,
            evacPerson.Description,
            evacPerson.Medications
        );

        return response;
    }

    private CreatedAtActionResult CreatedAtGetEvacPerson (EvacPerson evacPerson) {
        return CreatedAtAction(actionName: nameof(GetEvacPerson),
                               routeValues: new { id = evacPerson.Id },
                               value: MapEvacPersonToResponse(evacPerson));
    }
}