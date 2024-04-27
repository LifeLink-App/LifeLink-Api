using ErrorOr;
using LifeLink.Models;
using LifeLink.Models.Dtos.UpdateDtos;
using LifeLink.Services.BaseService;

namespace LifeLink.Services.FieldOperators;

public interface IFieldOperatorService : IBaseService<FieldOperator, FieldOperatorUpdateDto>
{
    ErrorOr<FieldOperator> GetFieldOperatorByUserId(Guid id);
}
