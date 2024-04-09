namespace LifeLink.Contracts.EvacPerson.Requests;

public record UpsertEvacPersonRequest (
    string Name,
    DateTime BirthDay,
    string Description,
    List<Guid> Medications
);