using ErrorOr;
using LifeLink.Contracts.EvacPerson.Requests;
using LifeLink.Helpers;
using LifeLink.Models.BaseModels;
using LifeLink.ServiceErrors;

namespace LifeLink.Models.Dtos;

public class EvacPersonUpdateDto(
        string? name,
        DateTime? birthDate,
        List<Guid>? medications,
        List<Guid>? illnesses,
        string? description,
        Coordinate? location,
        string? locationNote)
{
    public string? Name { get; set; } = name;
    public DateTime? BirthDate { get; set; } = birthDate;
    public List<Guid>? Medications { get; set; } = medications;
    public List<Guid>? Illnesses { get; set; } = illnesses;
    public string? Description { get; set; } = description;
    public Coordinate? Location { get; set; } = location;
    public string? LocationNote { get; set; } = locationNote;

    private static ErrorOr<EvacPersonUpdateDto> Create(        
        string? name,
        DateTime? birthDate,
        List<Guid>? medications,
        List<Guid>? illnesses,
        string? description,
        Coordinate? location,
        string? locationNote)
    {
        List<Error> errors = [];

        if(!string.IsNullOrEmpty(name)){
            if(name.Length < Constants.MinNameLength || name.Length > Constants.MaxNameLength){
                errors.Add(Errors.EvacPerson.InvalidNameLength);
            }  
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

        return new EvacPersonUpdateDto (
            name,
            birthDate,
            medications,
            illnesses,
            description,
            location,
            locationNote
        );
    }

    public static ErrorOr<EvacPersonUpdateDto> From(UpdateEvacPersonRequest request)
    {
        return Create(
            request.Name,
            request.BirthDate,
            request.Medications,
            request.Illnesses,
            request.Description,
            request.Location != null ? new Coordinate(){
                Latitude = request.Location.Latitude, 
                Longitude = request.Location.Longitude
            } : null,            
            request.LocationNote
        );
    }
}
