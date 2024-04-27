using ErrorOr;
using LifeLink.Models;
using LifeLink.Models.Dtos;
using LifeLink.Services.BaseService;

namespace LifeLink.Services.EvacPersons;

public interface IEvacPersonService : IBaseService<EvacPerson, EvacPersonUpdateDto>
{
    public ErrorOr<Success> IsMedicationsValid(List<Guid> ids);
    public ErrorOr<Success> IsIllnessesValid(List<Guid> ids);
}