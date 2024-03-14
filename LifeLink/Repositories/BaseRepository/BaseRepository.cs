using ErrorOr;
using LifeLink.Models.BaseModels;
using LifeLink.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LifeLink.Repositories.BaseRepository;

public abstract class BaseRepository<TEntity>(LifeLinkDbContext dbContext) : IBaseRepository<TEntity> where TEntity : class, IBaseModel
{
    protected readonly LifeLinkDbContext _dbContext = dbContext;

    public ErrorOr<Created> Create(TEntity entity)
    {
        _dbContext.Add(entity);
        _dbContext.SaveChanges();

        return Result.Created;
    }

    public ErrorOr<Deleted> Delete(Guid id)
    {
        var entity = _dbContext.Set<TEntity>().Find(id);
        if (entity == null)
        {
            return Error.NotFound();
        }

        _dbContext.Remove(entity);
        _dbContext.SaveChanges();

        return Result.Deleted;
    }

    public ErrorOr<TEntity> Get(Guid id)
    {
        var entity = _dbContext.Set<TEntity>().Find(id);
        if (entity == null)
        {
            return Error.NotFound();
        }

        return entity;
    }

    public ErrorOr<List<TEntity>> GetAll() 
    {
        var entities  = _dbContext.Set<TEntity>().ToList();
        if (entities  == null || entities.Count == 0)
        {
            return Error.NotFound();
        }

        return entities ;
    }

    public ErrorOr<UpsertedObject> Upsert(TEntity entity)
    {        
        var isNewlyCreated = !_dbContext.Set<TEntity>().Any(e => e.Id == entity.Id);

        if (isNewlyCreated)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }
        else{
            var existingEntity = _dbContext.Set<TEntity>().AsNoTracking().Single(e => e.Id == entity.Id);
            
            _dbContext.Attach(entity).State = EntityState.Modified;
            
            _dbContext.Entry(entity).Property("CreatorId").CurrentValue = existingEntity.CreatorId;
            _dbContext.Entry(entity).Property("CreateTime").CurrentValue = existingEntity.CreateTime;
        }
        _dbContext.SaveChanges();

        return new UpsertedObject(isNewlyCreated);
    }
}