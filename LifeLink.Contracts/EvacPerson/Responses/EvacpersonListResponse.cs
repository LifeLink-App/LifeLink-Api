namespace LifeLink.Contracts.EvacPerson.Responses;

public record EvacPersonListResponse (
    int Count,
    List<EvacPersonResponse> Items
);