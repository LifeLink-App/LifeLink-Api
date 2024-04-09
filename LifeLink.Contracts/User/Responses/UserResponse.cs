namespace LifeLink.Contracts.User.Responses;

public record UserResponse (
    Guid Id,
    Guid CreatorId,
    DateTime CreateTime,
    Guid ModifierId, 
    DateTime ModifyTime,
    string Username,
    string Email,
    string? Phone,
    string Name,
    DateTime? BirthDate,
    List<Guid> Roles
);