namespace LifeLink.Contracts.EvacPerson;

public record UpsertEvacPersonRequest (
    string Name,
    DateTime BirthDay,
    string Description
);