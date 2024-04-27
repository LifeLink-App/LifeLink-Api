using System.Reflection;
using ErrorOr;
using LifeLink.Models.BaseModels;
using LifeLink.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LifeLink.Repositories.BaseRepository;

public abstract class BaseRepository<TEntity, TUpdateEntity>(LifeLinkDbContext dbContext) : IBaseRepository<TEntity, TUpdateEntity> where TEntity : class, IBaseModel
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

    public ErrorOr<Updated> Update(Guid id, TUpdateEntity updateEntity, string modifierId)
    {        
        var entity = _dbContext.Set<TEntity>().Find(id);
        if (entity == null)
        {
            return Error.NotFound();
        }

        var entityType = typeof(TEntity);
        var updateEntityType = typeof(TUpdateEntity);

        foreach (var field in updateEntityType.GetProperties())
        {
            var propertyName = field.Name;
            var propertyValue = field.GetValue(updateEntity);

            if(propertyValue != null)
            {
                var entityProperty = entityType.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (entityProperty != null && entityProperty.CanWrite)
                {
                    entityProperty.SetValue(entity, propertyValue);
                }                
            }
        }

        var modifierIdProperty = entityType.GetProperty("ModifierId", BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        var modifyTimeProperty = entityType.GetProperty("ModifyTime", BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        
        if (modifierIdProperty != null && modifierIdProperty.CanWrite && modifyTimeProperty != null && modifyTimeProperty.CanWrite)
        {
            modifierIdProperty.SetValue(entity, new Guid(modifierId));
            modifyTimeProperty.SetValue(entity, DateTime.UtcNow);
        } 

        _dbContext.SaveChanges();

        return Result.Updated;
    }
}