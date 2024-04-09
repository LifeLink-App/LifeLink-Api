using ErrorOr;
using LifeLink.Contracts.User.Requests;
using LifeLink.Models;
using LifeLink.Services.BaseService;

namespace LifeLink.Services.Users;

public interface IUserService : IBaseService<User>
{
    ErrorOr<User> Login(LoginUserRequest request);
}