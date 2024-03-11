namespace LifeLink.Contracts.EvacPerson;

public record EvacPersonResponse (
    Guid Id,
    Guid CreatorId,
    DateTime CreateTime,
    Guid ModifierId, 
    DateTime ModifyTime,
    string Name,
    DateTime BirthDate,
    string Description,
    List<Guid> Medications
);