namespace LifeLink.Models.BaseModels;

public abstract class BaseModel(Guid id, Guid creatorId) : IBaseModel
{
    public Guid Id { get; set; } = id;
    public Guid CreatorId { get; set; } = creatorId;
    public DateTime CreateTime { get; set; } = DateTime.UtcNow;
    public Guid ModifierId { get; set; } = creatorId;
    public DateTime ModifyTime { get; set; } = DateTime.UtcNow;
}
