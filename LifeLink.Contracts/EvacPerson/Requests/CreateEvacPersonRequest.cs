namespace LifeLink.Contracts.EvacPerson.Requests;

public record CreateEvacPersonRequest (
    string Name,
    DateTime BirthDay,
    string Description,
    List<Guid> Medications
);