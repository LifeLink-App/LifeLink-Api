using ErrorOr;
using LifeLink.Models;
using LifeLink.Repositories.BaseRepository;

namespace LifeLink.Repositories.Parameters;

public interface IParameterRepository : IBaseRepository<Parameter>
{
    ErrorOr<List<string>> GetAllGK();
    ErrorOr<List<string>> GetAllPK();
    ErrorOr<List<Parameter>> GetParameterByGK (string GK);
    ErrorOr<List<Parameter>> GetParameterByPK (string PK);
}