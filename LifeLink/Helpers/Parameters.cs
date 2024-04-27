namespace LifeLink.Helpers;

// Parameters
public class UserRoles
{
    public static readonly Guid Admin = new("961a1ae7-6d3c-4e47-ace1-049cec49cce0");
    public static readonly Guid FieldOperator = new("961a1ae7-6d3c-4e47-ace1-049cec49cce1");

    public static bool IsValid(Guid id)
    {
        if( id == Admin ||
            id == FieldOperator)
            {
                return true;
            }

        return false;
    }
}   

public class EvacPersonStatuses 
{
    public static readonly Guid Safe = new("961a1ae7-6d3c-4e47-bce1-049cec49cce0");
    public static readonly Guid Unknown = new("961a1ae7-6d3c-4e47-bce1-049cec49cce1");
    public static readonly Guid NeedsAssistance = new("961a1ae7-6d3c-4e47-bce1-049cec49cce2");
    public static readonly Guid GettingTreatment = new("961a1ae7-6d3c-4e47-bce1-049cec49cce3");
    public static readonly Guid Deceased = new("961a1ae7-6d3c-4e47-bce1-049cec49cce4");
    public static readonly Guid Neutral = new("961a1ae7-6d3c-4e47-bce1-049cec49cce5");
}

public class Medications
{
    public static readonly Guid Ibuprofen = new ("961a1ae7-6d3c-4e47-cce1-049cec49cce0");
    public static readonly Guid Morphine = new ("961a1ae7-6d3c-4e47-cce1-049cec49cce1");
    public static readonly Guid Aspirin = new ("961a1ae7-6d3c-4e47-cce1-049cec49cce2");

    public static bool IsValid(Guid id)
    {
        if( id == Ibuprofen ||
            id == Morphine ||
            id == Aspirin)
            {
                return true;
            }

        return false;
    }
}

public class Illnesses
{
    public static readonly Guid TypeOneDiabetes = new ("961a1ae7-6d3c-4e47-dce1-049cec49cce0");
    public static readonly Guid TypeTwoDiabetes = new ("961a1ae7-6d3c-4e47-dce1-049cec49cce1");
    public static readonly Guid Diarrhea = new ("961a1ae7-6d3c-4e47-dce1-049cec49cce2");

    public static bool IsValid(Guid id)
    {
        if( id == TypeOneDiabetes ||
            id == TypeTwoDiabetes ||
            id == Diarrhea)
            {
                return true;
            }

        return false;
    }
}

public class FieldOperatorStatuses 
{    
    public static readonly Guid Neutral = new("961a1ae7-6d3c-4e47-ece1-049cec49cce0");
    public static readonly Guid ReadyForAssignment = new("961a1ae7-6d3c-4e47-ece1-049cec49cce1");
    public static readonly Guid Active = new("961a1ae7-6d3c-4e47-ece1-049cec49cce2");
    public static readonly Guid UnableToWork = new("961a1ae7-6d3c-4e47-ece1-049cec49cce3");
}
