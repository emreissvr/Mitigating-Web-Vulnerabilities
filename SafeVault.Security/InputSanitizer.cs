using System.Text.RegularExpressions;

public static class InputSanitizer
{
    public static string SanitizeInput(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return string.Empty;

        input = System.Net.WebUtility.HtmlEncode(input);
        input = Regex.Replace(input, @"[<>""'%;()&+]", string.Empty);
        return input.Trim();
    }
}
