using ErrorOr;
using LifeLink.Models;
using LifeLink.Models.Dtos.UpdateDtos;
using LifeLink.Persistence;
using LifeLink.Repositories.BaseRepository;
using LifeLink.ServiceErrors;

namespace LifeLink.Repositories.FieldOperators;

public class FieldOperatorRepository(LifeLinkDbContext dbContext) : BaseRepository<FieldOperator, FieldOperatorUpdateDto>(dbContext), IFieldOperatorRepository
{
    public ErrorOr<FieldOperator> GetFieldOperatorByUserId(Guid id)
    {
        var fieldOperator = _dbContext.FieldOperator
            .Where(p => p.UserId == id)
            .ToList();

        if(fieldOperator.Count == 0) 
        {
            return Errors.FieldOperator.NotFound;
        }
        else if(fieldOperator.Count > 1)
        {
            return Errors.FieldOperator.FieldOperatorConnectionConflict;
        }

        return fieldOperator.First();
    }
}
