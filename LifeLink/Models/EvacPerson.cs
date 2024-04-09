using ErrorOr;
using LifeLink.Contracts.EvacPerson.Requests;
using LifeLink.Models.BaseModels;
using LifeLink.ServiceErrors;

namespace LifeLink.Models;

public class EvacPerson (
        Guid id,
        string name,
        DateTime birthDate,
        string description,
        List<Guid> medications) : BaseModel (id)
{
    public string Name { get; set; } = name;
    public DateTime BirthDate { get; set; } = birthDate;
    public string Description { get; set; } = description;
    public List<Guid> Medications { get; set; } = medications;

    private static ErrorOr<EvacPerson> Create(        
        string name,
        DateTime birthDate,
        string description,
        List<Guid> medications,
        Guid? id = null)
    {
        List<Error> errors = [];

        if(name.Length < Constants.MinNameLength || name.Length > Constants.MaxNameLength){
            errors.Add(Errors.EvacPerson.InvalidNameLength);
        }        

        if(description.Length < Constants.MinDescriptionLength || description.Length > Constants.MaxDescriptionLength){
            errors.Add(Errors.EvacPerson.InvalidDescriptionLength);
        }  

        if(errors.Count > 0){
            return errors;
        }

        return new EvacPerson (
            id ?? Guid.NewGuid(),
            name,
            birthDate,
            description,
            medications
        );
    }

    public static ErrorOr<EvacPerson> From(CreateEvacPersonRequest request)
    {
        return Create(
            request.Name,
            request.BirthDay,
            request.Description,
            request.Medications
        );
    }
    
    public static ErrorOr<EvacPerson> From(Guid id, UpsertEvacPersonRequest request)
    {
        return Create(
            request.Name,
            request.BirthDay,
            request.Description,
            request.Medications,
            id
        );
    }
}