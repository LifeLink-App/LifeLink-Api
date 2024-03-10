using ErrorOr;
using LifeLink.Models;
using LifeLink.Repositories.EvacPersons;

namespace LifeLink.Services.EvacPersons;

public class EvacPersonService(IEvacPersonRepository evacPersonRepository) : IEvacPersonService
{
    private readonly IEvacPersonRepository _evacPersonRepository = evacPersonRepository;

    public ErrorOr<Created> CreateEvacPerson(EvacPerson evacPerson)
    {
        return _evacPersonRepository.Create(evacPerson);
    }

    public ErrorOr<Deleted> DeleteEvacPerson(Guid id)
    {
        return _evacPersonRepository.Delete(id);
    }

    public ErrorOr<EvacPerson> GetEvacPerson(Guid id)
    {
        return  _evacPersonRepository.Get(id);
    }

    public ErrorOr<UpsertedEvacPerson> UpsertEvacPerson(EvacPerson evacPerson)
    {
        return _evacPersonRepository.Upsert(evacPerson);
    }
}