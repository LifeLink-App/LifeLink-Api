using ErrorOr;
using LifeLink.Models;
using LifeLink.Models.Dtos.UpdateDtos;
using LifeLink.Repositories.FieldOperators;
using LifeLink.Services.BaseService;

namespace LifeLink.Services.FieldOperators;

public class FieldOperatorService(IFieldOperatorRepository fieldOperatorRepository) : BaseService<FieldOperator, FieldOperatorUpdateDto>(fieldOperatorRepository), IFieldOperatorService
{
    private new readonly FieldOperatorRepository _repository = (FieldOperatorRepository)fieldOperatorRepository;
    public ErrorOr<FieldOperator> GetFieldOperatorByUserId(Guid id)
    {
        return _repository.GetFieldOperatorByUserId(id);
    }
}
