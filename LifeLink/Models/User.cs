using ErrorOr;
using LifeLink.Contracts.User.Requests;
using LifeLink.Models.BaseModels;
using LifeLink.ServiceErrors;

namespace LifeLink.Models;

public class User (
        Guid id,
        string username,
        string email,
        string? phone,
        string name,
        DateTime? birthDate,
        List<Guid> roles,
        string password) : BaseModel (id)
{
    public string Username { get; set; } = username;
    public string Email { get; set; } = email; 
    public string Name { get; set; } = name;
    public string? Phone { get; set; } = phone;
    public DateTime? BirthDate { get; set; } = birthDate;
    public List<Guid> Roles { get; set; } = roles;
    public string Password { get; set; } = password;

    private static ErrorOr<User> Create(        
        string username,
        string email,
        string? phone,
        string name,
        DateTime? birthDate,
        List<Guid> roles,
        string password,
        Guid? id = null)
    {
        List<Error> errors = [];

        if(!Helpers.IsEmailValid(email)){
            errors.Add(Errors.User.InvalidEmail);
        }    

        if(username.Length < Constants.MinNameLength || username.Length > Constants.MaxNameLength){
            errors.Add(Errors.User.InvalidUsernameLength);
        }       

        if(name.Length < Constants.MinNameLength || name.Length > Constants.MaxNameLength){
            errors.Add(Errors.User.InvalidNameLength);
        }  

        if(!string.IsNullOrEmpty(phone) && !Helpers.IsPhoneNumberValid(phone)){
            errors.Add(Errors.User.InvalidPhoneNumber);
        }

        if(password.Length < Constants.MinPasswordLength){
            errors.Add(Errors.User.InvalidPasswordLength);
        }

        if(errors.Count > 0){
            return errors;
        }

        return new User (
            id ?? Guid.NewGuid(),
            username,
            email,
            phone,
            name,
            birthDate,
            roles,
            password
        );
    }

    public static ErrorOr<User> From(CreateUserRequest request)
    {
        return Create(
            request.Username,
            request.Email,
            request.Phone,
            request.Name,
            request.BirthDate,
            request.Roles,
            request.Password
        );
    }
}