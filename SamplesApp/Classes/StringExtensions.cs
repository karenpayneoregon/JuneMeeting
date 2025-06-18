using System.Text.RegularExpressions;

namespace SamplesApp.Classes;
/// <summary>
/// Example of optimizing string operations.
/// </summary>
public static partial class StringExtensions
{
    public static string SplitCase1(this string sender) =>
        string.Join(" ", CaseRegEx().Matches(sender)
            .Select(m => m.Value));

    public static string SplitCase2(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        Span<char> result = stackalloc char[input.Length * 2];
        var resultIndex = 0;

        for (var index = 0; index < input.Length; index++)
        {
            var currentChar = input[index];

            if (index > 0 && char.IsUpper(currentChar))
            {
                result[resultIndex++] = ' ';
            }

            result[resultIndex++] = currentChar;
        }

        return result[..resultIndex].ToString();

    }

    [GeneratedRegex(@"([A-Z][a-z]+)")]
    private static partial Regex CaseRegEx();
}
