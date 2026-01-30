namespace StringCalculator.Tests;

public class CalculatorTests
{
    private readonly Calculator _calculator;

    public CalculatorTests()
    {
        _calculator = new Calculator();
    }

    [Fact]
    public void Add_EmptyString_ReturnsZero()
    {
        var result = _calculator.Add("");
        Assert.Equal(0, result);
    }

    [Fact]
    public void Add_SingleNumber_ReturnsThatNumber()
    {
        var result = _calculator.Add("20");
        Assert.Equal(20, result);
    }

    [Fact]
    public void Add_TwoNumbers_ReturnsSum()
    {
        var result = _calculator.Add("1,5000");
        Assert.Equal(5001, result);
    }

    [Fact]
    public void Add_TwoNumbersWithNegative_ReturnsSum()
    {
        var result = _calculator.Add("4,-3");
        Assert.Equal(1, result);
    }

    [Fact]
    public void Add_MissingNumber_TreatsAsZero()
    {
        var result = _calculator.Add("5,");
        Assert.Equal(5, result);
    }

    [Fact]
    public void Add_InvalidNumber_TreatsAsZero()
    {
        var result = _calculator.Add("5,tytyt");
        Assert.Equal(5, result);
    }

    [Fact]
    public void Add_MultipleNumbers_ReturnsSum()
    {
        var result = _calculator.Add("1,2,3,4,5,6,7,8,9,10,11,12");
        Assert.Equal(78, result);
    }

    [Fact]
    public void Add_NullInput_ReturnsZero()
    {
        var result = _calculator.Add(null);
        Assert.Equal(0, result);
    }
}
