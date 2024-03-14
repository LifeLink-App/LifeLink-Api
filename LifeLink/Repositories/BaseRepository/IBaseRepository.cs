using ErrorOr;

namespace LifeLink.Repositories.BaseRepository;

public interface IBaseRepository<TEntity> where TEntity : class
{
    ErrorOr<Created> Create(TEntity entity);
    ErrorOr<Deleted> Delete(Guid id);
    ErrorOr<TEntity> Get(Guid id);
    ErrorOr<List<TEntity>> GetAll();
    ErrorOr<UpsertedObject> Upsert(TEntity entity);
}
