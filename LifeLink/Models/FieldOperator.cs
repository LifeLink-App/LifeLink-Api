using ErrorOr;
using LifeLink.Helpers;
using LifeLink.Models.BaseModels;
using LifeLink.Models.Dtos.CreateDtos;
using LifeLink.ServiceErrors;

namespace LifeLink.Models;

public class FieldOperator : BaseModel
{
    public FieldOperator(Guid id, Guid userId, Coordinate location, string? locationNote, List<Guid> assignedEvacPersons, Guid? activeEvacPerson, Guid status) 
        : base(id, Guid.Empty)
    {
        Id = id;
        UserId = userId;
        Location = location;
        LocationNote = locationNote;
        AssignedEvacPersons = assignedEvacPersons;
        ActiveEvacPerson = activeEvacPerson;
        Status = status;
    }

    public Guid UserId { get; init; }
    public Coordinate Location { get; init; }
    public string? LocationNote { get; init; }
    public List<Guid> AssignedEvacPersons { get; init; }
    public Guid? ActiveEvacPerson { get; init; }
    public Guid Status { get; init; }

    private static ErrorOr<FieldOperator> Create(        
        Guid id,
        Guid userId,
        Coordinate? location,
        string? locationNote)
    {
        List<Error> errors = [];

        if(location == null){
            errors.Add(Errors.FieldOperator.NoLocationValue);
        }  

        if(!string.IsNullOrEmpty(locationNote)){
            if(locationNote.Length < Constants.MinDescriptionLength || locationNote.Length > Constants.MaxDescriptionLength){
                errors.Add(Errors.FieldOperator.InvalidLocationNoteLength);
            }  
        }   

        if(errors.Count > 0){
            return errors;
        }

        return new FieldOperator (
            id,
            userId,
            location ?? new Coordinate(),
            locationNote,
            [],
            null,
            FieldOperatorStatuses.Neutral
        );
    }

    public static ErrorOr<FieldOperator> From(FieldOperatorCreateDto request, Guid userId)
    {
        return Create(
            Guid.NewGuid(),
            userId,
            request.Location,
            request.LocationNote
        );
    }
}