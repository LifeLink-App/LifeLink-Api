using ErrorOr;
using LifeLink.Models;
using LifeLink.Services.BaseService;

namespace LifeLink.Services.Parameters;

public interface IParameterService : IBaseService<Parameter>
{
    ErrorOr<List<string>> GetAllGroupKeys();
    ErrorOr<List<string>> GetAllParameterKeys();
    ErrorOr<List<Parameter>> GetParameterByGK (string GK);
    ErrorOr<List<Parameter>> GetParameterByPK (string PK);
}