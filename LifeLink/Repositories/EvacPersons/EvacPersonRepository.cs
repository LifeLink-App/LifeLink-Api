using ErrorOr;
using LifeLink.Models;
using LifeLink.Persistence;
using LifeLink.ServiceErrors;

namespace LifeLink.Repositories.EvacPersons;

public class EvacPersonRepository(LifeLinkDbContext dbContext) : IEvacPersonRepository
{
    private readonly LifeLinkDbContext _dbContext = dbContext;

    public ErrorOr<Created> Create(EvacPerson evacPerson)
    {
        _dbContext.Add(evacPerson);
        _dbContext.SaveChanges();

        return Result.Created;
    }

    public ErrorOr<Deleted> Delete(Guid id)
    {
        var evacPerson = _dbContext.EvacPersons.Find(id);
        if(evacPerson == null){
            return Errors.EvacPerson.NotFound;
        }

        _dbContext.Remove(evacPerson);
        _dbContext.SaveChanges();

        return Result.Deleted;
    }

    public ErrorOr<EvacPerson> Get(Guid id)
    {
        if(_dbContext.EvacPersons.Find(id) is EvacPerson evacPerson){
            return evacPerson;
        }
        
        return Errors.EvacPerson.NotFound;
            
    }

    public ErrorOr<UpsertedEvacPerson> Upsert(EvacPerson evacPerson)
    {
        var isNewlyCreated = !_dbContext.EvacPersons.Any(e => e.Id == evacPerson.Id);

        if(isNewlyCreated)
        {
            _dbContext.EvacPersons.Add(evacPerson);
        }
        else 
        {
            _dbContext.EvacPersons.Update(evacPerson);
        }

        _dbContext.SaveChanges();

        return new UpsertedEvacPerson(isNewlyCreated);
    }
}