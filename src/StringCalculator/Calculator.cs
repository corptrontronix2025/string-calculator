namespace StringCalculator;

public class Calculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
        {
            return 0;
        }

        var delimiters = new List<string> { ",", "\n" };
        var numberSection = numbers;

        if (numbers.StartsWith("//"))
        {
            var delimiterEndIndex = numbers.IndexOf('\n');
            var delimiter = numbers.Substring(2, delimiterEndIndex - 2);
            delimiters.Add(delimiter);
            numberSection = numbers.Substring(delimiterEndIndex + 1);
        }

        var parts = numberSection.Split(delimiters.ToArray(), StringSplitOptions.None);
        var parsedNumbers = parts.Select(ParseNumber).ToList();

        var negatives = parsedNumbers.Where(n => n < 0).ToList();
        if (negatives.Any())
        {
            throw new ArgumentException($"Negatives not allowed: {string.Join(", ", negatives)}");
        }

        return parsedNumbers.Sum();
    }

    private int ParseNumber(string input)
    {
        if (int.TryParse(input.Trim(), out int number))
        {
            return number > 1000 ? 0 : number;
        }
        return 0;
    }
}
