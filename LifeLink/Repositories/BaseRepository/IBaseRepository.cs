using ErrorOr;

namespace LifeLink.Repositories.BaseRepository;

public interface IBaseRepository<TEntity, TUpdateEntity> where TEntity : class
{
    ErrorOr<Created> Create(TEntity entity);
    ErrorOr<Deleted> Delete(Guid id);
    ErrorOr<TEntity> Get(Guid id);
    ErrorOr<List<TEntity>> GetAll();
    ErrorOr<Updated> Update(Guid id, TUpdateEntity updateEntity, string modifierId);
}
