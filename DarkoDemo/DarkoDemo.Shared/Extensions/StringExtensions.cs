namespace DarkoDemo.Shared.Extensions;

public static class StringExtensions
{
    public static char? FirstLetterOfWord(this string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return null;

        return input[0];
    }
}
