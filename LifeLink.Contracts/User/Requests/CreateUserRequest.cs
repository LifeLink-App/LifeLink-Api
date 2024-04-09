namespace LifeLink.Contracts.User.Requests;

public record CreateUserRequest (
    string Username,
    string Email,
    string? Phone,
    string Name,
    DateTime? BirthDate,
    List<Guid> Roles,
    string Password
);