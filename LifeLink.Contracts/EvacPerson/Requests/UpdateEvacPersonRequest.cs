using LifeLink.Contracts.HelperClasses;

namespace LifeLink.Contracts.EvacPerson.Requests;

public record UpdateEvacPersonRequest (
    string? Name,
    DateTime? BirthDate,
    List<Guid>? Medications,
    List<Guid>? Illnesses,
    string? Description,
    Coordinate? Location,
    string? LocationNote
);