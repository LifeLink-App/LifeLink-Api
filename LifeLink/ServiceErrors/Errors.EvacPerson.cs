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

        public static Error InvalidName => Error.Validation(
            code: "EvacPerson.InvalidName",
            description: $"Evac Person name must be at least {Models.EvacPerson.MinNameLength} characters long and at most {Models.EvacPerson.MaxNameLength} characters long"
        );
        public static Error InvalidDescription => Error.Validation(
            code: "EvacPerson.InvalidDescription",
            description: $"Evac Person description must be at least {Models.EvacPerson.MinDescriptionLength} characters long and at most {Models.EvacPerson.MaxDescriptionLength} characters long"
        );
    }
}