using ErrorOr;
using LifeLink.Models;
using LifeLink.Models.Dtos.UpdateDtos;
using LifeLink.Repositories.BaseRepository;

namespace LifeLink.Repositories.FieldOperators;

public interface IFieldOperatorRepository : IBaseRepository<FieldOperator, FieldOperatorUpdateDto>
{
    ErrorOr<FieldOperator> GetFieldOperatorByUserId(Guid id);
}
