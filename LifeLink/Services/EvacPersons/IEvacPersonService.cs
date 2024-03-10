using ErrorOr;
using LifeLink.Models;
using LifeLink.Repositories.EvacPersons;

namespace LifeLink.Services.EvacPersons;

public interface IEvacPersonService 
{
    ErrorOr<Created> CreateEvacPerson(EvacPerson evacPerson);
    ErrorOr<Deleted> DeleteEvacPerson(Guid id);
    ErrorOr<EvacPerson> GetEvacPerson(Guid id);
    ErrorOr<UpsertedEvacPerson> UpsertEvacPerson(EvacPerson evacPerson);
}