using ErrorOr;
using LifeLink.Models;
using LifeLink.Persistence;
using LifeLink.Repositories.BaseRepository;
using LifeLink.ServiceErrors;

namespace LifeLink.Repositories.EvacPersons;

public class EvacPersonRepository(LifeLinkDbContext dbContext) : BaseRepository<EvacPerson>(dbContext), IEvacPersonRepository
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
}