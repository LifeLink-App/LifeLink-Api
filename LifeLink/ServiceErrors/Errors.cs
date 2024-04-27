using ErrorOr;
using LifeLink.Helpers;

namespace LifeLink.ServiceErrors;

public static class Errors
{
    public static class Identity 
    {
        public static Error ClaimNotFound => Error.NotFound(
            code: "Identity.NotFound.ClaimNotFound",
            description: "Needed claim not found in this token"
        );
    }

    public static class Parameter 
    {
        public static Error NotFoundGK => Error.NotFound(
            code: "Parameter.NotFound",
            description: "No GroupKey found"
        );
        public static Error NotFoundPK => Error.NotFound(
            code: "Parameter.NotFound",
            description: "No ParameterKey found"
        );
    }

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
        public static Error InvalidLocationNoteLength => Error.Validation(
            code: "EvacPerson.Validation.InvalidLocationNote",
            description: $"Evac Person location note must be at least {Constants.MinDescriptionLength} characters long and at most {Constants.MaxDescriptionLength} characters long"
        );
        public static Error MedicationNotFound => Error.NotFound(
            code: "EvacPerson.NotFound.MedicationNotFound",
            description: "Medication not found"
        );
        public static Error IllnessNotFound => Error.NotFound(
            code: "EvacPerson.NotFound.IllnessNotFound",
            description: "Illness not found"
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
        public static Error LoginErrorNotFound => Error.NotFound(
            code: "User.NotFound.LoginErrorNotFound",
            description: "User with this credentials not found"
        );
        public static Error LoginError => Error.Conflict(
            code: "User.Conflict.LoginError",
            description: "User credentials are wrong"
        );
        public static Error RoleNotFound => Error.NotFound(
            code: "User.NotFound.RoleNotFound",
            description: "Role not found"
        );
        public static Error RoleNotProvided => Error.Validation(
            code: "User.Validation.RoleNotProvided",
            description: "User must have at least one role"
        );
    }

    public static class FieldOperator 
    {       
        public static Error InvalidLocationNoteLength => Error.Validation(
            code: "FieldOperator.Validation.InvalidLocationNote",
            description: $"Field Operator location note must be at least {Constants.MinDescriptionLength} characters long and at most {Constants.MaxDescriptionLength} characters long"
        );
        public static Error NoLocationValue => Error.Validation(
            code: "FieldOperator.Validation.NoLocationValue",
            description: "Location must be provided when creating a Field Operator"
        );
        public static Error NotFound => Error.NotFound(
            code: "FieldOperator.NotFound",
            description: "Field Operator not found"
        );
        public static Error FieldOperatorConnectionConflict => Error.Conflict(
            code: "FieldOperator.Conflict.FieldOperatorConnectionConflict",
            description: "This user is connected with more than one Field Operators"
        );
    }
}