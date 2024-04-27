using ErrorOr;
using LifeLink.Helpers;
using LifeLink.Models;
using LifeLink.Models.Dtos;
using LifeLink.Repositories.EvacPersons;
using LifeLink.ServiceErrors;
using LifeLink.Services.BaseService;
using LifeLink.Services.Parameters;
using Microsoft.IdentityModel.Tokens;

namespace LifeLink.Services.EvacPersons;

public class EvacPersonService(IEvacPersonRepository evacPersonRepository) : BaseService<EvacPerson, EvacPersonUpdateDto>(evacPersonRepository), IEvacPersonService
{
    public new ErrorOr<Created> Create(EvacPerson evacPerson){
        IsMedicationsValid(evacPerson.Medications);
        IsIllnessesValid(evacPerson.Illnesses);

        return base.Create(evacPerson);
    }

    public new ErrorOr<Updated> Update(Guid id, EvacPersonUpdateDto updateEntity, string modifierId){
        if(updateEntity.Medications != null)
        {
            IsMedicationsValid(updateEntity.Medications);
        }
        if(updateEntity.Illnesses != null)
        {
            IsIllnessesValid(updateEntity.Illnesses);
        }

        return base.Update(id, updateEntity, modifierId);
    }

    public ErrorOr<Success> IsMedicationsValid(List<Guid> ids)
    {


        foreach(var medicationId in ids)
        {
            if(!Medications.IsValid(medicationId))
            {
                return Errors.EvacPerson.MedicationNotFound;
            }
        }

        return Result.Success;
    }

    public ErrorOr<Success> IsIllnessesValid(List<Guid> ids)
    {    
        foreach(var illnessId in ids)
        {
            if(!Illnesses.IsValid(illnessId))
            {
                return Errors.EvacPerson.IllnessNotFound;
            }
        }  

        return Result.Success;
    }
}