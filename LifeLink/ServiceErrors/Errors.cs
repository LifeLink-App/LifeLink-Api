using ErrorOr;

namespace LifeLink.ServiceErrors;

public static class Errors
{
    public static class EvacPerson 
    {
        public static Error NotFound => Error.NotFound(
            code: "EvacPerson.NotFound",
            description: "Evac Person not found"
        );
        public static Error InvalidNameLength => Error.Validation(
            code: "EvacPerson.Validation.InvalidName",
            description: $"Evac Person name must be at least {Constants.MinNameLength} characters long and at most {Constants.MaxNameLength} characters long"
        );        
        public static Error InvalidDescriptionLength => Error.Validation(
            code: "EvacPerson.Validation.InvalidDescription",
            description: $"Evac Person description must be at least {Constants.MinDescriptionLength} characters long and at most {Constants.MaxDescriptionLength} characters long"
        );
    }

    public static class User 
    {
        public static Error NotFound => Error.NotFound(
            code: "User.NotFound",
            description: "User not found"
        );
        public static Error InvalidEmail => Error.Validation(
            code: "User.Validation.InvalidEmail",
            description: $"User Email is not in a valid format"
        );        
        public static Error InvalidUsernameLength => Error.Validation(
            code: "User.Validation.InvalidUsername",
            description: $"User username must be at least {Constants.MinNameLength} characters long and at most {Constants.MaxNameLength} characters long"
        );
        public static Error InvalidNameLength => Error.Validation(
            code: "User.Validation.InvalidName",
            description: $"User name must be at least {Constants.MinNameLength} characters long and at most {Constants.MaxNameLength} characters long"
        );
        public static Error InvalidPhoneNumber => Error.Validation(
            code: "User.Validation.InvalidPhoneNumber",
            description: $"User Phone Number is not in a valid format"
        );
        public static Error InvalidPasswordLength => Error.Validation(
            code: "User.Validation.InvalidPassword",
            description: $"User password must be at least {Constants.MinPasswordLength} characters long"
        );
        public static Error ExistingEmail => Error.Conflict(
            code: "User.Conflict.ExistingEmail",
            description: "User with this Email already exists"
        );
        public static Error ExistingUsername => Error.Conflict(
            code: "User.Conflict.ExistingUsername",
            description: "User with this Username already exists"
        );
    }
}