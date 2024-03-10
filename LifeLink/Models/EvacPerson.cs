using ErrorOr;
using LifeLink.Contracts.EvacPerson;
using LifeLink.ServiceErrors;

namespace LifeLink.Models;

public class EvacPerson 
{
    public const int MinNameLength = 3;
    public const int MaxNameLength = 50;

    public Guid Id { get; }
    public Guid CreatorId { get; }
    public DateTime CreateTime { get; }
    public Guid ModifierId { get; }
    public DateTime ModifyTime { get; }
    public string Name { get; }
    public DateTime BirthDate { get; }
    public string Description { get; }

    private EvacPerson(
        Guid id,
        Guid creatorId,
        DateTime createTime,
        Guid modifierId,
        DateTime modifyTime,
        string name,
        DateTime birthDate,
        string description)
    {
        Id = id;
        CreatorId = creatorId;
        CreateTime = createTime;
        ModifierId = modifierId;
        ModifyTime = modifyTime;
        Name = name;
        BirthDate = birthDate;
        Description = description;
    }

    public static ErrorOr<EvacPerson> Create(        
        string name,
        DateTime birthDate,
        string description,
        Guid? id = null)
    {
        List<Error> errors = [];

        if(name.Length < MinNameLength || name.Length > MaxNameLength){
            errors.Add(Errors.EvacPerson.InvalidName);
        }        

        if(errors.Count > 0){
            return errors;
        }

        return new EvacPerson (
            id ?? Guid.NewGuid(),
            Guid.Empty,
            DateTime.Now,
            Guid.Empty,
            DateTime.Now,
            name,
            birthDate,
            description
        );

    }

    public static ErrorOr<EvacPerson> From(CreateEvacPersonRequest request)
    {
        return Create(
            request.Name,
            request.BirthDay,
            request.Description
        );
    }
    
    public static ErrorOr<EvacPerson> From(Guid id, UpsertEvacPersonRequest request)
    {
        return Create(
            request.Name,
            request.BirthDay,
            request.Description,
            id
        );
    }
}