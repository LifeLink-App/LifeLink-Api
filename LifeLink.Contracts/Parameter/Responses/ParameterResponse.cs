namespace LifeLink.Contracts.Parameter.Responses;

public record ParameterResponse (
    Guid Id,
    Guid CreatorId,
    DateTime CreateTime,
    Guid ModifierId, 
    DateTime ModifyTime,
    string GroupKey,
    string ParameterKey,
    string Value,
    string ExtraValue
);    
    