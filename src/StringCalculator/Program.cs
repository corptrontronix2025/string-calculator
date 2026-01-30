using StringCalculator;

var calculator = new Calculator();

Console.WriteLine("String Calculator");
Console.WriteLine("Enter numbers separated by comma (or 'exit' to quit):");

while (true)
{
    Console.Write("> ");
    var input = Console.ReadLine();

    if (input?.ToLower() == "exit")
    {
        break;
    }

    try
    {
        var result = calculator.Add(input ?? string.Empty);
        Console.WriteLine($"Result: {result}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}
