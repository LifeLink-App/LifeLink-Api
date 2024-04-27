using LifeLink.Contracts.HelperClasses;

namespace LifeLink.Contracts.EvacPerson.Responses;

public record EvacPersonResponse (
    Guid Id,
    Guid CreatorId,
    DateTime CreateTime,
    Guid ModifierId, 
    DateTime ModifyTime,
    string Name,
    DateTime BirthDate,
    int Age,
    List<Guid> Medications,
    List<Guid> Illnesses,
    string? Description,
    Coordinate Location,
    string? LocationNote,
    List<Guid> AssignedOperators,
    Guid Status
);