using System.Text.RegularExpressions;

namespace LifeLink;

public static class Helpers
{
    private static bool RegexCheck(string template, string value)
    {
        Regex regex = new(template);
        return regex.IsMatch(value);
    }

    public static bool IsEmailValid(string email)
    {
        return RegexCheck(Constants.EmailRegex, email);
    }

    public static bool IsPhoneNumberValid(string phone)
    {
        return RegexCheck(Constants.PhoneNumberRegex, phone);
    }
}