namespace Task4Test;

public class StingMethodsTest
{
    [Theory]
    [InlineData("hello")]
    [InlineData("123abc")]
    [InlineData("another_non_empty_string")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("o")]
    public void TestStringReverse(string value)
    {
        var result = Task4.StingProblem.ReverseString(value);
        var targetResult = new string(value?.Reverse().ToArray() ?? Array.Empty<char>());
        Assert.Equal(result, targetResult);
    }

    [Theory]
    [InlineData("1001")]
    [InlineData("101")]
    [InlineData("aaaabbb")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("Able was I ere I saw Elba")]
    public void TestPalindrome(string value)
    {
        var reversedString = Task4.StingProblem.ReverseString(value);

        var isPalindrome = reversedString.Equals(value, StringComparison.InvariantCultureIgnoreCase);
        
        Assert.Equal(isPalindrome, Task4.StingProblem.IsPalindrome(value));
    }
}