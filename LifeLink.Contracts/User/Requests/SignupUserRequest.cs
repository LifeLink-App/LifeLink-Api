using LifeLink.Contracts.HelperClasses;

namespace LifeLink.Contracts.User.Requests;

public record SignupUserRequest (
    string Email,
    string? Phone,
    string Name,
    DateTime? BirthDate,
    List<Guid> Roles,
    string Password,
    Coordinate? Location,
    string? LocationNote
);