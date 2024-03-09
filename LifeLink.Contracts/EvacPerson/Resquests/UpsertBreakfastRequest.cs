namespace LifeLink.Contracts.EvacPerson;

public record UpsertEvacPersonRequest (
    string Name,
    string Surname,
    DateTime BirthDay,
    string Description
);