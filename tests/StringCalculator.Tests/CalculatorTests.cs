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
        var result = _calculator.Add("1,500");
        Assert.Equal(501, result);
    }

    [Fact]
    public void Add_NumberGreaterThan1000_IsIgnored()
    {
        var result = _calculator.Add("2,1001,6");
        Assert.Equal(8, result);
    }

    [Fact]
    public void Add_NumberEqualTo1000_IsIncluded()
    {
        var result = _calculator.Add("2,1000,6");
        Assert.Equal(1008, result);
    }

    [Fact]
    public void Add_SingleNegative_ThrowsException()
    {
        var exception = Assert.Throws<ArgumentException>(() => _calculator.Add("4,-3"));
        Assert.Contains("-3", exception.Message);
    }

    [Fact]
    public void Add_MultipleNegatives_ThrowsExceptionWithAllNegatives()
    {
        var exception = Assert.Throws<ArgumentException>(() => _calculator.Add("-1,2,-3,4,-5"));
        Assert.Contains("-1", exception.Message);
        Assert.Contains("-3", exception.Message);
        Assert.Contains("-5", exception.Message);
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

    [Fact]
    public void Add_NewlineDelimiter_ReturnsSum()
    {
        var result = _calculator.Add("1\n2,3");
        Assert.Equal(6, result);
    }

    [Fact]
    public void Add_OnlyNewlineDelimiters_ReturnsSum()
    {
        var result = _calculator.Add("1\n2\n3");
        Assert.Equal(6, result);
    }

    [Fact]
    public void Add_CustomSingleCharDelimiter_ReturnsSum()
    {
        var result = _calculator.Add("//#\n2#5");
        Assert.Equal(7, result);
    }

    [Fact]
    public void Add_CustomDelimiterWithInvalidNumber_ReturnsSum()
    {
        var result = _calculator.Add("//,\n2,ff,100");
        Assert.Equal(102, result);
    }

    [Fact]
    public void Add_CustomDelimiterStillSupportsCommaAndNewline_ReturnsSum()
    {
        var result = _calculator.Add("//#\n1#2,3\n4");
        Assert.Equal(10, result);
    }
}
