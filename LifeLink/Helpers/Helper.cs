using System.Text.RegularExpressions;

namespace LifeLink.Helpers;

public static class Helper
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