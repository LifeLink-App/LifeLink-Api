namespace LifeLink.Contracts.Parameter.Responses;

public record KeyResponse (
    int Count,
    List<string> Items
);