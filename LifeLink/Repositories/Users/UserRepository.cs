using ErrorOr;
using LifeLink.Contracts.User.Requests;
using LifeLink.Models;
using LifeLink.Persistence;
using LifeLink.Repositories.BaseRepository;
using LifeLink.ServiceErrors;

namespace LifeLink.Repositories.Users;

public class UserRepository(LifeLinkDbContext dbContext) : BaseRepository<User>(dbContext), IUserRepository
{
    public new ErrorOr<Created> Create(User user)
    {
        var existingUserByEmailOrUsername = _dbContext.User.FirstOrDefault(u => u.Email == user.Email || u.Username == user.Username);
        
        if(existingUserByEmailOrUsername != null){
            List<Error> errors = [];

            if(existingUserByEmailOrUsername.Email == user.Email){
                errors.Add(Errors.User.ExistingEmail);
            }

            if(existingUserByEmailOrUsername.Username == user.Username){
                errors.Add(Errors.User.ExistingUsername);
            }

            return errors;
        }

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
        user.Password = hashedPassword;     

        return base.Create(user);
    }

    public ErrorOr<User> Login(LoginUserRequest request)
    {
        var loginUser = _dbContext.User.FirstOrDefault(u => 
            (!string.IsNullOrEmpty(request.Email) && u.Email == request.Email) || 
            (!string.IsNullOrEmpty(request.Username) && u.Username == request.Username));

        if (loginUser == null)
        {
            return Errors.User.LoginErrorNotFound;
        }

        string hashedPasswordFromDatabase = loginUser.Password;

        if (!BCrypt.Net.BCrypt.Verify(request.Password, hashedPasswordFromDatabase))
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