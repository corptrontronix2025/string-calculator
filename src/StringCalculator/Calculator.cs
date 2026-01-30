namespace StringCalculator;

public class Calculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
        {
            return 0;
        }

        var parts = numbers.Split(new[] { ',', '\n' });
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
