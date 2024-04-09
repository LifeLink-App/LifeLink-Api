namespace LifeLink.Contracts.User.Requests;

public record LoginUserRequest (
    string? Username,
    string? Email,
    string Password
);