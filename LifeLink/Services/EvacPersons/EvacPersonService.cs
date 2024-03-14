using ErrorOr;
using LifeLink.Models;
using LifeLink.Repositories.EvacPersons;
using LifeLink.Services.BaseService;

namespace LifeLink.Services.EvacPersons;

public class EvacPersonService(IEvacPersonRepository evacPersonRepository) : BaseService<EvacPerson>(evacPersonRepository), IEvacPersonService
{
}