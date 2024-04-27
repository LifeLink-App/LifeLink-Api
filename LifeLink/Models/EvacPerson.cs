using ErrorOr;
using LifeLink.Contracts.EvacPerson.Requests;
using LifeLink.Helpers;
using LifeLink.Models.BaseModels;
using LifeLink.ServiceErrors;

namespace LifeLink.Models;

public class EvacPerson (
        Guid creatorId,
        Guid id,
        string name,
        DateTime birthDate,
        List<Guid> medications,
        List<Guid> illnesses,
        string? description,
        Coordinate location,
        string? locationNote,
        List<Guid> assignedOperators,
        Guid status
    ) : BaseModel (id, creatorId)
{
    public string Name { get; set; } = name;
    public DateTime BirthDate { get; set; } = birthDate;
    public List<Guid> Medications { get; set; } = medications;
    public List<Guid> Illnesses { get; set; } = illnesses;
    public string? Description { get; set; } = description;
    public Coordinate Location { get; set; } = location;
    public string? LocationNote { get; set; } = locationNote;
    public List<Guid> AssignedOperators { get; set; } = assignedOperators;
    public Guid Status { get; set; } = status; 

    private static ErrorOr<EvacPerson> Create(        
        Guid creatorId,
        Guid id,
        string name,
        DateTime birthDate,
        List<Guid> medications,
        List<Guid> illnesses,
        Coordinate location,
        string? description = null,
        string? locationNote = null)
    {
        List<Error> errors = [];

        if(name.Length < Constants.MinNameLength || name.Length > Constants.MaxNameLength){
            errors.Add(Errors.EvacPerson.InvalidNameLength);
        }  
        
        if(!string.IsNullOrEmpty(description)){
            if(description.Length < Constants.MinDescriptionLength || description.Length > Constants.MaxDescriptionLength){
                errors.Add(Errors.EvacPerson.InvalidDescriptionLength);
            }  
        }

        if(!string.IsNullOrEmpty(locationNote)){
            if(locationNote.Length < Constants.MinDescriptionLength || locationNote.Length > Constants.MaxDescriptionLength){
                errors.Add(Errors.EvacPerson.InvalidLocationNoteLength);
            }  
        }

        if(errors.Count > 0){
            return errors;
        }

        return new EvacPerson (
            creatorId,
            id,
            name,
            birthDate,
            medications,
            illnesses,
            description,
            location,
            locationNote,
            [],
            EvacPersonStatuses.Neutral
        );
    }

    public static ErrorOr<EvacPerson> From(CreateEvacPersonRequest request, string creatorId)
    {
        return Create(
            new Guid(creatorId),
            Guid.NewGuid(),
            request.Name,
            request.BirthDate,
            request.Medications,
            request.Illnesses,
            new Coordinate(){
                Latitude = request.Location.Latitude, 
                Longitude =request.Location.Longitude
            },
            request.Description,
            request.LocationNote
        );
    }
}