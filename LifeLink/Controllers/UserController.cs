using System.Security.Claims;
using ErrorOr;
using LifeLink.Contracts.User.Requests;
using LifeLink.Contracts.User.Responses;
using LifeLink.Helpers;
using LifeLink.Identity;
using LifeLink.Models;
using LifeLink.Models.BaseModels;
using LifeLink.Models.Dtos.CreateDtos;
using LifeLink.Services.BaseService;
using LifeLink.Services.FieldOperators;
using LifeLink.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeLink.Controllers;

[Route("user")]
public class UserController(IUserService userService, IFieldOperatorService fieldOperatorService) : ApiController 
{
    private readonly IUserService _userService = userService;
    private readonly IFieldOperatorService _fieldOperatorService = fieldOperatorService;

    [HttpPost("signup")]
    public IActionResult SignupUser(SignupUserRequest request) 
    {
        // turn request to user
        ErrorOr<User> requestToUserResult = Models.User.From(request);

        if(requestToUserResult.IsError) 
        {
            return Problem(requestToUserResult.Errors);
        }

        var user = requestToUserResult.Value;
        
        ErrorOr<Created> createUserResult = _userService.Create(user);

        if(createUserResult.IsError)
        {
            return Problem(createUserResult.Errors);
        }

        // turn request to field operator if valid
        if(user.Roles.Contains(UserRoles.FieldOperator))
        {
            var fieldOperatorCreateDto = new FieldOperatorCreateDto(
                request.Location != null ? new Coordinate(){
                    Latitude = request.Location.Latitude,
                    Longitude = request.Location.Longitude
                } : null,
                request.LocationNote
            ){};

            ErrorOr<FieldOperator> requestToFieldOperatorResult = FieldOperator.From(fieldOperatorCreateDto, user.Id);

            if(requestToFieldOperatorResult.IsError) {
                _userService.Delete(user.Id);
                return Problem(requestToFieldOperatorResult.Errors);
            }

            var fieldOperator = requestToFieldOperatorResult.Value;
            ErrorOr<Created> fieldOperatorCreateResult = _fieldOperatorService.Create(fieldOperator);

            return fieldOperatorCreateResult.Match(
                created => {
                    var userToken = TokenService.GenerateToken(user.Id, user.Email, user.Roles);
                    return CreatedAtGetUser(user, fieldOperator, userToken);
                },
                errors => {
                    _userService.Delete(user.Id);
                    return Problem(errors);
                }
            );
        }      
        else 
        {
            var userToken = TokenService.GenerateToken(user.Id, user.Email, user.Roles);
            return CreatedAtGetUser(user, null, userToken);            
        }  
    }

    [HttpPost("login")]
    public IActionResult LoginUser(LoginUserRequest request) 
    {
        ErrorOr<User> loginUserResult = _userService.Login(request);    

        if(loginUserResult.IsError)
        {
            return Problem(loginUserResult.Errors);
        }    

        var user = loginUserResult.Value;

        if(user.Roles.Contains(UserRoles.FieldOperator))
        {
            ErrorOr<FieldOperator> fieldOperatorResult = _fieldOperatorService.GetFieldOperatorByUserId(user.Id);

            return fieldOperatorResult.Match(
                fieldOperator => {
                    var userToken = TokenService.GenerateToken(user.Id, user.Email, user.Roles);
                    return Ok(MapFieldOperatorToLoginResponse(user, fieldOperator, userToken));
                },
                errors => Problem(errors)
            );
        }
        else 
        {
            var userToken = TokenService.GenerateToken(user.Id, user.Email, user.Roles);
            return Ok(MapUserToLoginResponse(user, userToken));
        }
    }

    [Authorize]
    [RequiresClaim(ClaimTypes.Role, IdentityData.AdminUserClaimId)]
    [HttpGet("{id:guid}")]
    public IActionResult GetUser(Guid id) 
    {
        ErrorOr<User> getUserResult = _userService.Get(id);

        if(getUserResult.IsError)
        {
            return Problem(getUserResult.Errors);
        }    

        var user = getUserResult.Value;

        if(user.Roles.Contains(UserRoles.FieldOperator))
        {
            ErrorOr<FieldOperator> fieldOperatorResult = _fieldOperatorService.GetFieldOperatorByUserId(user.Id);

            return fieldOperatorResult.Match(
                fieldOperator => {
                    var userToken = TokenService.GenerateToken(user.Id, user.Email, user.Roles);
                    return Ok(MapFieldOperatorToResponse(user, fieldOperator));
                },
                errors => Problem(errors)
            );
        }
        else 
        {
            var userToken = TokenService.GenerateToken(user.Id, user.Email, user.Roles);
            return Ok(MapUserToResponse(user));
        }
    }


    [Authorize]
    [RequiresClaim(ClaimTypes.Role, IdentityData.AdminUserClaimId)]
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteUser(Guid id) 
    {
         ErrorOr<Deleted> deleteUserResult =  _userService.Delete(id);

         if(deleteUserResult.IsError)
         {
            return Problem(deleteUserResult.Errors);
         }

         ErrorOr<FieldOperator> fieldOperatorResult = _fieldOperatorService.GetFieldOperatorByUserId(id);

         if(!fieldOperatorResult.IsError){
            _fieldOperatorService.Delete(fieldOperatorResult.Value.Id);
         }

         return deleteUserResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }

    private static UserResponse MapUserToResponse(User user)
    {
        var response = new UserResponse(
            user.Id,
            user.CreatorId,
            user.CreateTime,
            user.ModifierId,
            user.ModifyTime,
            user.Email,
            user.IsEmailVerified,
            user.Phone,
            user.IsPhoneVerified,
            user.Name,
            user.BirthDate,
            user.Roles
        );

        return response;
    }

    private static LoginUserResponse MapUserToLoginResponse(User user, string token)
    {
        var response = new LoginUserResponse(
            user.Id,
            user.CreatorId,
            user.CreateTime,
            user.ModifierId,
            user.ModifyTime,
            user.Email,
            user.IsEmailVerified,
            user.Phone,
            user.IsPhoneVerified,
            user.Name,
            user.BirthDate,
            user.Roles,
            token
        );

        return response;
    }

    private static FieldOperatorResponse MapFieldOperatorToResponse(User user, FieldOperator fieldOperator)
    {
        var response = new FieldOperatorResponse(
            user.Id,
            user.CreatorId,
            user.CreateTime,
            user.ModifierId,
            user.ModifyTime,
            user.Email,
            user.IsEmailVerified,
            user.Phone,
            user.IsPhoneVerified,
            user.Name,
            user.BirthDate,
            user.Roles,
            new Contracts.HelperClasses.Coordinate(fieldOperator.Location.Latitude, fieldOperator.Location.Longitude),
            fieldOperator.LocationNote,
            fieldOperator.AssignedEvacPersons,
            fieldOperator.ActiveEvacPerson,
            fieldOperator.Status
        );

        return response;
    }

    private static LoginFieldOperatorResponse MapFieldOperatorToLoginResponse(User user, FieldOperator fieldOperator, string token)
    {
        var response = new LoginFieldOperatorResponse(
            user.Id,
            user.CreatorId,
            user.CreateTime,
            user.ModifierId,
            user.ModifyTime,
            user.Email,
            user.IsEmailVerified,
            user.Phone,
            user.IsPhoneVerified,
            user.Name,
            user.BirthDate,
            user.Roles,
            new Contracts.HelperClasses.Coordinate(fieldOperator.Location.Latitude, fieldOperator.Location.Longitude),
            fieldOperator.LocationNote,
            fieldOperator.AssignedEvacPersons,
            fieldOperator.ActiveEvacPerson,
            fieldOperator.Status,
            token
        );

        return response;
    }

    private CreatedAtActionResult CreatedAtGetUser (User user, FieldOperator? fieldOperator, string userToken) {
        return CreatedAtAction(actionName: nameof(GetUser),
                               routeValues: new { id = user.Id },
                               value: fieldOperator == null ? MapUserToLoginResponse(user, userToken) : MapFieldOperatorToLoginResponse(user, fieldOperator, userToken));
    }
}