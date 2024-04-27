using LifeLink.Contracts.HelperClasses;

namespace LifeLink.Contracts.User.Responses;

public record LoginFieldOperatorResponse (
    Guid Id,
    Guid CreatorId,
    DateTime CreateTime,
    Guid ModifierId, 
    DateTime ModifyTime,
    string Email,
    bool IsEmailVerified,
    string? Phone,
    bool IsPhoneVerified,
    string Name,
    DateTime? BirthDate,
    List<Guid> Roles,
    Coordinate Location,
    string? LocationNote,
    List<Guid> AssignedEvacPersons,
    Guid? ActiveEvacPerson,
    Guid Status,
    string Token
);