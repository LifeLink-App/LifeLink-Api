using ErrorOr;
using LifeLink.Contracts.User.Requests;
using LifeLink.Models;
using LifeLink.Models.Dtos;
using LifeLink.Models.Dtos.CreateDtos;
using LifeLink.Services.BaseService;

namespace LifeLink.Services.Users;

public interface IUserService : IBaseService<User, UserUpdateDto>
{
    ErrorOr<User> Login(LoginUserRequest request);
}