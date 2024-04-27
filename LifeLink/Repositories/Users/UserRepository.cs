using ErrorOr;
using Isopoh.Cryptography.Argon2;
using LifeLink.Contracts.User.Requests;
using LifeLink.Models;
using LifeLink.Models.Dtos;
using LifeLink.Persistence;
using LifeLink.Repositories.BaseRepository;
using LifeLink.ServiceErrors;

namespace LifeLink.Repositories.Users;

public class UserRepository(LifeLinkDbContext dbContext) : BaseRepository<User, UserUpdateDto>(dbContext), IUserRepository
{
    public new ErrorOr<Created> Create(User user)
    {
        var existingUserByEmail = _dbContext.User.FirstOrDefault(u => u.Email == user.Email);
        
        if(existingUserByEmail != null){
            return Errors.User.ExistingEmail;
        }
        
        user.Password = Argon2.Hash(user.Password);     

        return base.Create(user);
    }

    public ErrorOr<User> Login(LoginUserRequest request)
    {
        var loginUser = _dbContext.User.FirstOrDefault(u => u.Email == request.Email);

        if (loginUser == null)
        {
            return Errors.User.LoginErrorNotFound;
        }

        if (!Argon2.Verify(loginUser.Password, request.Password))
        {
            return Errors.User.LoginError;
        }

        return loginUser;
    }

    public new ErrorOr<Deleted> Delete(Guid id)
    {
        ErrorOr<Deleted> result = base.Delete(id);

        if(result.Errors[0].Type == ErrorType.NotFound){
            return Errors.User.NotFound;
        }

        return result;
    }

    public new ErrorOr<User> Get(Guid id) 
    {
        ErrorOr<User> result = base.Get(id);

        if(result.Errors[0].Type == ErrorType.NotFound){
            return Errors.User.NotFound;
        }

        return result;
    }
}