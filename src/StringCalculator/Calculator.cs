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

        int sum = 0;
        foreach (var part in parts)
        {
            sum += ParseNumber(part);
        }

        return sum;
    }

    private int ParseNumber(string input)
    {
        if (int.TryParse(input.Trim(), out int number))
        {
            return number;
        }
        return 0;
    }
}
