using LifeLink.Contracts.HelperClasses;

namespace LifeLink.Contracts.EvacPerson.Requests;

public record CreateEvacPersonRequest(
    string Name,
    DateTime BirthDate,
    List<Guid> Medications,
    List<Guid> Illnesses,
    string? Description,
    Coordinate Location,
    string? LocationNote
);