using ErrorOr;
using LifeLink.Contracts.User.Requests;
using LifeLink.Models;
using LifeLink.Repositories.BaseRepository;

namespace LifeLink.Repositories.Users;

public interface IUserRepository : IBaseRepository<User>
{
    ErrorOr<User> Login(LoginUserRequest request);
}