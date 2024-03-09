namespace LifeLink.Models;

public class EvacPerson 
{
    public Guid Id { get; }
    public Guid CreatorId { get; }
    public DateTime CreateTime { get; }
    public Guid ModifierId { get; }
    public DateTime ModifyTime { get; }
    public string Name { get; }
    public string Surname { get; }
    public DateTime BirthDate { get; }
    public string Description { get; }

    public EvacPerson(
            Guid id,
            Guid creatorId,
            DateTime createTime,
            Guid modifierId,
            DateTime modifyTime,
            string name,
            string surname,
            DateTime birthDate,
            string description)
        {
            Id = id;
            CreatorId = creatorId;
            CreateTime = createTime;
            ModifierId = modifierId;
            ModifyTime = modifyTime;
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            Description = description;
        }
}