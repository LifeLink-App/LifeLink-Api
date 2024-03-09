namespace LifeLink.Contracts.EvacPerson;

public record EvacPersonResponse (
    Guid Id,
    Guid CreatorId,
    DateTime CreateTime,
    Guid ModifierId, 
    DateTime ModifyTime,
    string Name,
    string Surname,
    DateTime BirthDate,
    string Description
);