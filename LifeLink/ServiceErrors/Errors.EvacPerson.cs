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
            description: $"Evac Person name must be at least {Models.EvacPerson.MinNameLength} characters ling and at most {Models.EvacPerson.MaxNameLength} characters long"
        );
    }
}