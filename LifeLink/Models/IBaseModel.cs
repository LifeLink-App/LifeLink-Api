namespace LifeLink.Models;
public interface IBaseModel
{
    public Guid Id { get; set; }
    public Guid CreatorId { get; set; } 
    public DateTime CreateTime { get; set; }
    public Guid ModifierId { get; set; } 
    public DateTime ModifyTime { get; set; }
}