using ErrorOr;
using LifeLink.Models;
using LifeLink.Repositories.BaseRepository;
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

    public ErrorOr<List<EvacPerson>> GetAllEvacPersons() 
    {
        return _evacPersonRepository.GetAll();
    }

    public ErrorOr<UpsertedObject> UpsertEvacPerson(EvacPerson evacPerson)
    {
        return _evacPersonRepository.Upsert(evacPerson);
    }
}