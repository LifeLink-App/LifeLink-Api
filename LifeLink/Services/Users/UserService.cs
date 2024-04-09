using LifeLink.Models;
using LifeLink.Repositories.Users;
using LifeLink.Services.BaseService;

namespace LifeLink.Services.Users;

public class UserService(IUserRepository userRepository) : BaseService<User>(userRepository), IUserService
{
}