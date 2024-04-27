using ErrorOr;
using LifeLink.Contracts.User.Requests;
using LifeLink.Models;
using LifeLink.Models.Dtos;
using LifeLink.Repositories.BaseRepository;

namespace LifeLink.Repositories.Users;

public interface IUserRepository : IBaseRepository<User, UserUpdateDto>
{
    ErrorOr<User> Login(LoginUserRequest request);
}