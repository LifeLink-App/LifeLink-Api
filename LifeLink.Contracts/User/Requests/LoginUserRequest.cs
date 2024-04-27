namespace LifeLink.Contracts.User.Requests;

public record LoginUserRequest (
    string Email,
    string Password
);