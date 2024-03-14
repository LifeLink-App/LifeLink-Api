using ErrorOr;
using LifeLink.Models;
using LifeLink.Repositories.BaseRepository;
using LifeLink.Repositories.EvacPersons;

namespace LifeLink.Services.EvacPersons;

public interface IEvacPersonService 
{
    ErrorOr<Created> CreateEvacPerson(EvacPerson evacPerson);
    ErrorOr<Deleted> DeleteEvacPerson(Guid id);
    ErrorOr<EvacPerson> GetEvacPerson(Guid id);
    ErrorOr<List<EvacPerson>> GetAllEvacPersons(); 
    ErrorOr<UpsertedObject> UpsertEvacPerson(EvacPerson evacPerson);
}