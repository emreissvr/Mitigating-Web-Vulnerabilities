using System.Text.RegularExpressions;

public static class InputSanitizer
{
    public static string SanitizeInput(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return string.Empty;

        // Basic HTML encoding
        input = System.Net.WebUtility.HtmlEncode(input);

        // Remove potentially dangerous characters
        input = Regex.Replace(input, @"[<>""'%;()&+]", string.Empty);

        return input.Trim();
    }

    public static string SanitizeForDisplay(string input)
    {
        // Apply output encoding again when rendering to HTML page
        return System.Net.WebUtility.HtmlEncode(input);
    }
}
