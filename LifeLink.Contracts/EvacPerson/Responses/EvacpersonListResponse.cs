namespace LifeLink.Contracts.EvacPerson;

public record EvacPersonListResponse (
    int Count,
    List<EvacPersonResponse> Items
);