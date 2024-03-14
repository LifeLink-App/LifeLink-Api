using ErrorOr;
using LifeLink.Contracts.EvacPerson;
using LifeLink.ServiceErrors;

namespace LifeLink.Models;

public class EvacPerson : BaseModel
{
    public const int MinNameLength = 3;
    public const int MaxNameLength = 50;
    public const int MinDescriptionLength = 3;
    public const int MaxDescriptionLength = 200;

    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string Description { get; set; }
    public List<Guid> Medications { get; set; }

    private EvacPerson(
        Guid id,
        Guid creatorId,
        DateTime createTime,
        Guid modifierId,
        DateTime modifyTime,
        string name,
        DateTime birthDate,
        string description,
        List<Guid> medications) :  base(
            id, 
            creatorId, 
            createTime,
            modifierId, 
            modifyTime)
    {
        Name = name;
        BirthDate = birthDate;
        Description = description;
        Medications = medications;
    }

    public static ErrorOr<EvacPerson> Create(        
        string name,
        DateTime birthDate,
        string description,
        List<Guid> medications,
        Guid? id = null)
    {
        List<Error> errors = [];

        if(name.Length < MinNameLength || name.Length > MaxNameLength){
            errors.Add(Errors.EvacPerson.InvalidName);
        }        

        if(description.Length < MinDescriptionLength || description.Length > MaxDescriptionLength){
            errors.Add(Errors.EvacPerson.InvalidDescription);
        }  

        if(errors.Count > 0){
            return errors;
        }

        return new EvacPerson (
            id ?? Guid.NewGuid(),
            Guid.Empty,
            DateTime.UtcNow,
            Guid.Empty,
            DateTime.UtcNow,
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