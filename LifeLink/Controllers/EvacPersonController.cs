using System.Security.Claims;
using ErrorOr;
using LifeLink.Contracts.EvacPerson.Requests;
using LifeLink.Contracts.EvacPerson.Responses;
using LifeLink.Identity;
using LifeLink.Models;
using LifeLink.Models.Dtos;
using LifeLink.Services.EvacPersons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeLink.Controllers;

[Route("evacPerson")]
public class EvacPersonController(IEvacPersonService evacPersonService) : ApiController 
{
    private readonly IEvacPersonService _evacPersonService = evacPersonService;

    [Authorize]
    [RequiresClaim(ClaimTypes.Role, IdentityData.AdminUserClaimId)]
    [HttpPost()]
    public IActionResult CreateEvacPerson(CreateEvacPersonRequest request) 
    {
        var claimValue = GetRequestOwnerId();

        if(claimValue.IsError){
            return Problem(claimValue.Errors);
        }

        var requestOwner = claimValue.Value;

        ErrorOr<EvacPerson> requestToEvacPersonResult = EvacPerson.From(request, requestOwner);

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

    [Authorize]
    [RequiresClaim(ClaimTypes.Role, IdentityData.AdminUserClaimId)]
    [HttpGet("{id:guid}")]
    public IActionResult GetEvacPerson(Guid id) 
    {
        ErrorOr<EvacPerson> getEvacPersonResult = _evacPersonService.Get(id);

        return getEvacPersonResult.Match(
            evacPerson => Ok(MapEvacPersonToResponse(evacPerson)),
            errors => Problem(errors));      
    }

    [Authorize]
    [RequiresClaim(ClaimTypes.Role, IdentityData.AdminUserClaimId)]
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

    [Authorize]
    [RequiresClaim(ClaimTypes.Role, IdentityData.AdminUserClaimId)]
    [HttpPut("{id:guid}")]
    public IActionResult UpdateEvacPerson(Guid id, UpdateEvacPersonRequest request) 
    {
        var claimValue = GetRequestOwnerId();

        if(claimValue.IsError){
            return Problem(claimValue.Errors);
        }

        var requestOwner = claimValue.Value;       

        ErrorOr<EvacPersonUpdateDto> requestToEvacPersonUpdateDtoResult = EvacPersonUpdateDto.From(request);

        if(requestToEvacPersonUpdateDtoResult.IsError) {
            return Problem(requestToEvacPersonUpdateDtoResult.Errors);
        }

        var evacPersonUpdateDto = requestToEvacPersonUpdateDtoResult.Value;

        ErrorOr<Updated> updateEvacPersonResult = _evacPersonService.Update(id, evacPersonUpdateDto, requestOwner);

        return updateEvacPersonResult.Match(
            updated =>  NoContent(),
            errors => Problem(errors)
        );
    }

    [Authorize]
    [RequiresClaim(ClaimTypes.Role, IdentityData.AdminUserClaimId)]
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
        DateTime birthDate = evacPerson.BirthDate;
        DateTime currentDate = DateTime.Now;

        int age = currentDate.Year - birthDate.Year;

        var response = new EvacPersonResponse(
            evacPerson.Id,
            evacPerson.CreatorId,
            evacPerson.CreateTime,
            evacPerson.ModifierId,
            evacPerson.ModifyTime,
            evacPerson.Name,
            evacPerson.BirthDate,
            age - (birthDate.Date > currentDate.Date.AddYears(-age) ? 1 : 0),
            evacPerson.Medications,
            evacPerson.Illnesses,
            evacPerson.Description,
            new Contracts.HelperClasses.Coordinate(evacPerson.Location.Latitude, evacPerson.Location.Longitude),
            evacPerson.LocationNote,
            evacPerson.AssignedOperators,
            evacPerson.Status
        );

        return response;
    }

    private CreatedAtActionResult CreatedAtGetEvacPerson (EvacPerson evacPerson) {
        return CreatedAtAction(actionName: nameof(GetEvacPerson),
                               routeValues: new { id = evacPerson.Id },
                               value: MapEvacPersonToResponse(evacPerson));
    }
}