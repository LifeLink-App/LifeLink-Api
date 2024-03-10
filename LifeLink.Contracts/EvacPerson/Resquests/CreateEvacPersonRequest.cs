namespace LifeLink.Contracts.EvacPerson;

public record CreateEvacPersonRequest (
    string Name,
    DateTime BirthDay,
    string Description
);