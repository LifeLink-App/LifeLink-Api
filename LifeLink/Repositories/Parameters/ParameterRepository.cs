using ErrorOr;
using LifeLink.Models;
using LifeLink.Models.Dtos;
using LifeLink.Persistence;
using LifeLink.Repositories.BaseRepository;
using LifeLink.ServiceErrors;

namespace LifeLink.Repositories.Parameters;

public class ParameterRepository(LifeLinkDbContext dbContext) : BaseRepository<Parameter, ParameterUpdateDto>(dbContext), IParameterRepository
{
    public ErrorOr<List<string>> GetAllGK()
    {
        var distinctGroupKeys = _dbContext.Parameter
            .Select(p => p.GroupKey)
            .Distinct()
            .ToList();

        return distinctGroupKeys;
    }

    public ErrorOr<List<string>> GetAllPK()
    {
        var distinctParameterKeys = _dbContext.Parameter
            .Select(p => p.ParameterKey)
            .Distinct()
            .ToList();

        return distinctParameterKeys;
    }

    public ErrorOr<List<Parameter>> GetParameterByGK(string GK)
    {
        var parameters = _dbContext.Parameter
            .Where(p => p.GroupKey == GK)
            .ToList();

        if(parameters.Count == 0)
        {
            return Errors.Parameter.NotFoundGK;
        }

        return parameters;
    }

    public ErrorOr<List<Parameter>> GetParameterByPK(string PK)
    {
        var parameters = _dbContext.Parameter
            .Where(p => p.ParameterKey == PK)
            .ToList();

        if(parameters.Count == 0)
        {
            return Errors.Parameter.NotFoundPK;
        }

        return parameters;
    }
}