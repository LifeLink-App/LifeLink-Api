using LifeLink.Models;
using LifeLink.Models.Dtos;
using LifeLink.Repositories.BaseRepository;

namespace LifeLink.Repositories.EvacPersons;

public interface IEvacPersonRepository : IBaseRepository<EvacPerson, EvacPersonUpdateDto>
{
}