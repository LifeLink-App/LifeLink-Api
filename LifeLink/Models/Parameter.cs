using LifeLink.Models.BaseModels;

namespace LifeLink.Models;

public class Parameter (
        Guid id,
        string groupKey,
        string parameterKey,
        string value,
        string extraValue
    ) : BaseModel (id, Guid.Empty)
{
    public string GroupKey { get; set; } = groupKey;    
    public string ParameterKey { get; set; } = parameterKey;    
    public string Value { get; set; } = value;    
    public string ExtraValue { get; set; } = extraValue;
}