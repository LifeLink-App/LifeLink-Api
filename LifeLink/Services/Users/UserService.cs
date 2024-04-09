using ErrorOr;
using LifeLink.Contracts.User.Requests;
using LifeLink.Models;
using LifeLink.Repositories.Users;
using LifeLink.Services.BaseService;

namespace LifeLink.Services.Users;

public class UserService(IUserRepository userRepository) : BaseService<User>(userRepository), IUserService
{
    private new readonly UserRepository _repository = (UserRepository)userRepository;

    public ErrorOr<User> Login(LoginUserRequest request)
    {
        return _repository.Login(request);
    }
}