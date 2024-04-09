using ErrorOr;
using LifeLink.Contracts.User.Requests;
using LifeLink.Contracts.User.Responses;
using LifeLink.Models;
using LifeLink.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace LifeLink.Controllers;

[Route("user")]
public class UserController(IUserService userService) : ApiController 
{
    private readonly IUserService _userService = userService;

    [HttpPost()]
    public IActionResult CreateUser(CreateUserRequest request) 
    {
        ErrorOr<User> requestToUserResult = Models.User.From(request);

        if(requestToUserResult.IsError) {
            return Problem(requestToUserResult.Errors);
        }

        var user = requestToUserResult.Value;
        ErrorOr<Created> createUserResult = _userService.Create(user);

        return createUserResult.Match(
            created => CreatedAtGetUser(user),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetUser(Guid id) 
    {
        ErrorOr<User> getUserResult = _userService.Get(id);

        return getUserResult.Match(
            user => Ok(MapUserToResponse(user)),
            errors => Problem(errors));      
    }

    private static UserResponse MapUserToResponse(User user)
    {
        var response = new UserResponse(
            user.Id,
            user.CreatorId,
            user.CreateTime,
            user.ModifierId,
            user.ModifyTime,
            user.Username,
            user.Email,
            user.Phone,
            user.Name,
            user.BirthDate,
            user.Roles
        );

        return response;
    }

    private CreatedAtActionResult CreatedAtGetUser (User user) {
        return CreatedAtAction(actionName: nameof(GetUser),
                               routeValues: new { id = user.Id },
                               value: MapUserToResponse(user));
    }
}