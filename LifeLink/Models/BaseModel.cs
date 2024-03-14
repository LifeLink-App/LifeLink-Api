namespace LifeLink.Models;

public abstract class BaseModel : IBaseModel
{
    public Guid Id { get; set; }
    public Guid CreatorId { get; set; }
    public DateTime CreateTime { get; set; }
    public Guid ModifierId { get; set; }
    public DateTime ModifyTime { get; set; }

    protected BaseModel(Guid id, Guid creatorId, DateTime createTime, Guid modifierId, DateTime modifyTime)
    {
        Id = id;
        CreatorId = creatorId;
        CreateTime = createTime;
        ModifierId = modifierId;
        ModifyTime = modifyTime;
    }
}
