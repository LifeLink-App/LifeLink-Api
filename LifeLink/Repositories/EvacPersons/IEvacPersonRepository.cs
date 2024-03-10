using ErrorOr;
using LifeLink.Models;

namespace LifeLink.Repositories.EvacPersons;

public interface IEvacPersonRepository
{
    ErrorOr<Created> Create(EvacPerson evacPerson);
    ErrorOr<Deleted> Delete(Guid id);
    ErrorOr<EvacPerson> Get(Guid id);
    ErrorOr<UpsertedEvacPerson> Upsert(EvacPerson evacPerson);
}