namespace LifeLink.Helpers;

// Constants
public static class Constants
{
    
    public static readonly int MinNameLength = 3;
    public static readonly int MaxNameLength = 50;
    public static readonly int MinDescriptionLength = 3;
    public static readonly int MaxDescriptionLength = 200;
    public static readonly int MinPasswordLength = 8;
    public static readonly string EmailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
    public static readonly string PhoneNumberRegex = @"^\+\d{1,3}\s\d{10}$";
    public static readonly int KeyByteSize = 32;

    // Group Keys
    public static readonly string GK_USER = "USER";
    public static readonly string GK_EVAC_PERSON = "EVAC_PERSON";
    public static readonly string GK_FIELD_OPERATOR = "FIELD_OPERATOR";

    // Parameter Keys 
    public static readonly string PK_USER_ROLE = "USER_ROLE";   
    public static readonly string PK_EVAC_PERSON_STATUS = "EVAC_PERSON_STATUS";
    public static readonly string PK_EVAC_PERSON_MEDICATION = "EVAC_PERSON_MEDICATION";
    public static readonly string PK_EVAC_PERSON_ILLNESS = "EVAC_PERSON_ILLNESS";
    public static readonly string PK_FIELD_OPERATOR_STATUS = "FIELD_OPERATOR_STATUS";
}