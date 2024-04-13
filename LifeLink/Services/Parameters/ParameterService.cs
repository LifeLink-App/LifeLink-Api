using ErrorOr;
using LifeLink.Models;
using LifeLink.Repositories.Parameters;
using LifeLink.Services.BaseService;

namespace LifeLink.Services.Parameters;

public class ParameterService(IParameterRepository parameterRepository) : BaseService<Parameter>(parameterRepository), IParameterService
{
    private new readonly ParameterRepository _repository = (ParameterRepository)parameterRepository;

    public ErrorOr<List<string>> GetAllGroupKeys()
    {
        return _repository.GetAllGK();
    }

    public ErrorOr<List<string>> GetAllParameterKeys()
    {
        return _repository.GetAllPK();
    }

    public ErrorOr<List<Parameter>> GetParameterByGK(string GK)
    {
        return _repository.GetParameterByGK(GK);
    }

    public ErrorOr<List<Parameter>> GetParameterByPK(string PK)
    {
        return _repository.GetParameterByPK(PK);
    }
}