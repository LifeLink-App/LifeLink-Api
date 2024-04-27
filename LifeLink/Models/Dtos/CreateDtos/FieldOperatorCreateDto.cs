using LifeLink.Models.BaseModels;

namespace LifeLink.Models.Dtos.CreateDtos;

public class FieldOperatorCreateDto (
    Coordinate? location,
    string? locationNote
)
{
    public Coordinate? Location { get; set; } = location;
    public string? LocationNote { get; set; } = locationNote;
}
