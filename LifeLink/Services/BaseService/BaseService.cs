using ErrorOr;
using LifeLink.Repositories.BaseRepository;

namespace LifeLink.Services.BaseService
{
    public abstract class BaseService<TEntity>(IBaseRepository<TEntity> repository) : IBaseService<TEntity> where TEntity : class
    {
        protected readonly IBaseRepository<TEntity> _repository = repository;

        public virtual ErrorOr<Created> Create(TEntity entity)
        {
            return _repository.Create(entity);
        }

        public virtual ErrorOr<Deleted> Delete(Guid id)
        {
            return _repository.Delete(id);
        }

        public virtual ErrorOr<TEntity> Get(Guid id)
        {
            return _repository.Get(id);
        }

        public virtual ErrorOr<List<TEntity>> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual ErrorOr<UpsertedObject> Upsert(TEntity entity)
        {
            return _repository.Upsert(entity);
        }
    }
}
