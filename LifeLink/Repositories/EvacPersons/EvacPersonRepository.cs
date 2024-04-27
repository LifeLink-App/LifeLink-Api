using ErrorOr;
using LifeLink.Models;
using LifeLink.Models.Dtos;
using LifeLink.Persistence;
using LifeLink.Repositories.BaseRepository;
using LifeLink.ServiceErrors;

namespace LifeLink.Repositories.EvacPersons;

public class EvacPersonRepository(LifeLinkDbContext dbContext) : BaseRepository<EvacPerson, EvacPersonUpdateDto>(dbContext), IEvacPersonRepository
{
    public new ErrorOr<Deleted> Delete(Guid id)
    {
        ErrorOr<Deleted> result = base.Delete(id);

        if(result.Errors[0].Type == ErrorType.NotFound){
            return Errors.EvacPerson.NotFound;
        }

        return result;
    }

    public new ErrorOr<EvacPerson> Get(Guid id) 
    {
        ErrorOr<EvacPerson> result = base.Get(id);

        if(result.Errors[0].Type == ErrorType.NotFound){
            return Errors.EvacPerson.NotFound;
        }

        return result;
    }

    public new ErrorOr<List<EvacPerson>> GetAll() 
    {
        ErrorOr<List<EvacPerson>> result = base.GetAll();

        if(result.Errors[0].Type == ErrorType.NotFound){
            return Errors.EvacPerson.NotFound;
        }

        return result;
    }

    public new ErrorOr<Updated> Update(Guid id, EvacPersonUpdateDto updateEntity, string modifierId)
    {
        ErrorOr<Updated> result = base.Update(id, updateEntity, modifierId);

        if(result.Errors[0].Type == ErrorType.NotFound){
            return Errors.EvacPerson.NotFound;
        }

        return result;
    }
}