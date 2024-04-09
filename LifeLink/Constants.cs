namespace LifeLink;

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
}