using ErrorOr;
using LifeLink.Contracts.User.Requests;
using LifeLink.Helpers;
using LifeLink.Models;
using LifeLink.Models.Dtos;
using LifeLink.Models.Dtos.CreateDtos;
using LifeLink.Repositories.Users;
using LifeLink.ServiceErrors;
using LifeLink.Services.BaseService;
using LifeLink.Services.FieldOperators;

namespace LifeLink.Services.Users;

public class UserService(IUserRepository userRepository, IFieldOperatorService fieldOperatorService) : BaseService<User, UserUpdateDto>(userRepository), IUserService

{
    private new readonly UserRepository _repository = (UserRepository)userRepository;
    private readonly FieldOperatorService _fieldOperatorService = (FieldOperatorService)fieldOperatorService;

    public new ErrorOr<Created> Create(User user){        
        foreach(var userRole in user.Roles)
        {            
            if(!UserRoles.IsValid(userRole))
            {
                return Errors.User.RoleNotFound;
            }
        }

        return base.Create(user);        
    }

    public ErrorOr<User> Login(LoginUserRequest request)
    {
        return _repository.Login(request);
    }
}