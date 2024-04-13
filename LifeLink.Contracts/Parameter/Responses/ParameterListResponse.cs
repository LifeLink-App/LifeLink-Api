namespace LifeLink.Contracts.Parameter.Responses;

public record ParameterListResponse (
    int Count,
    List<ParameterResponse> Items
);