using ErrorOr;
using LifeLink.Contracts.EvacPerson.Requests;
using LifeLink.Contracts.EvacPerson.Responses;
using LifeLink.Models;
using LifeLink.Repositories.BaseRepository;
using LifeLink.Services.EvacPersons;
using Microsoft.AspNetCore.Authorization;
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
        ErrorOr<Created> createEvacPersonResult = _evacPersonService.Create(evacPerson);

        return createEvacPersonResult.Match(
            created => CreatedAtGetEvacPerson(evacPerson),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetEvacPerson(Guid id) 
    {
        ErrorOr<EvacPerson> getEvacPersonResult = _evacPersonService.Get(id);

        return getEvacPersonResult.Match(
            evacPerson => Ok(MapEvacPersonToResponse(evacPerson)),
            errors => Problem(errors));      
    }

    [HttpGet()]
    public IActionResult GetAllEvacPersons() 
    {
        ErrorOr<List<EvacPerson>> getAllEvacPersonsResult = _evacPersonService.GetAll();

        return getAllEvacPersonsResult.Match(
            evacPersons => {
                    var list = evacPersons.Select(MapEvacPersonToResponse).ToList();
                    return Ok(new EvacPersonListResponse(Count: list.Count, Items: list));
                },
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
        ErrorOr<UpsertedObject> upsertEvacPersonResult = _evacPersonService.Upsert(evacPerson);

        return upsertEvacPersonResult.Match(
            upserted => upserted.IsNewlyCreated ? CreatedAtGetEvacPerson(evacPerson) : NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteEvacPerson(Guid id) 
    {
         ErrorOr<Deleted> deleteEvacPersonResult =  _evacPersonService.Delete(id);

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