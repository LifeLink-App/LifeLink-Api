namespace LifeLink.Contracts.EvacPerson;

public record CreateEvacPersonRequest (
    string Name,
    string Surname,
    DateTime BirthDay,
    string Description
);