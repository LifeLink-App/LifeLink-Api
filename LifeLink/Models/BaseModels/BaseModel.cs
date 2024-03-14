namespace LifeLink.Models.BaseModels;

public abstract class BaseModel(Guid id) : IBaseModel
{
    // TODO : user id to the creator and modifier ids fetched from the token

    public Guid Id { get; set; } = id;
    public Guid CreatorId { get; set; } = Guid.Empty;
    public DateTime CreateTime { get; set; } = DateTime.UtcNow;
    public Guid ModifierId { get; set; } = Guid.Empty;
    public DateTime ModifyTime { get; set; } = DateTime.UtcNow;
}
