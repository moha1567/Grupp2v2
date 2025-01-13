using Xunit;

public class PersonalNumberValidatorTest
{
    private readonly PersonalNumberValidator _validator;
    public PersonalNumberValidatorTest()
    {
        _validator = new PersonalNumberValidator();
    }
    [Fact]
    public void CleanPersNum_Empty()
    {
        string input = "";
        string cleanedPnr = _validator.CleanPersonalNumber(input);
        Assert.Equal("", cleanedPnr);
    }
    [Fact]
    public void CleanPersNum_Space()
    {
        string input = "   ";
        string cleanedPnr = _validator.CleanPersonalNumber(input);
        Assert.Equal("", cleanedPnr);
    }
    [Fact]
    public void CleanPersNum_MixedCharacters()
    {
        string input = "1234-56X78#90";
        string cleanedPnr = _validator.CleanPersonalNumber(input);
        Assert.Equal("1234567890", cleanedPnr);
    }
    [Fact]
    public void CleanPersNum_LongString() 
    {
        string input = "1234-56-78-90-abcdefg";
        string cleanedPnr = _validator.CleanPersonalNumber(input);
        Assert.Equal("1234567890", cleanedPnr);
    }
    [Fact]
    public void CleanPersNum_ShortString()
    {
        string input = "1234-abcd";
        string cleanedPnr = _validator.CleanPersonalNumber(input);
        Assert.Equal("1234567890", cleanedPnr);
    }
    [Fact]
    public void CleanPersNum_SingleCharacter()
    {
        string input = "A";
        string cleanedPnr = _validator.CleanPersonalNumber(input);
        Assert.Equal("", cleanedPnr);
    }
    [Fact]
    public void CleanPersNum_PunctuatedInput()
    {
        string input = "1234-56-78,90!";
        string cleanedPnr = _validator.CleanPersonalNumber(input);
        Assert.Equal("1234567890", cleanedPnr);
    }
    [Fact]
    public void CleanPersNum_SeveralLeadingAndSpaces()
    {
        string input = "   1234-56-78-90   ";
        string cleanedPnr = _validator.CleanPersonalNumber(input);
        Assert.Equal("1234567890", cleanedPnr);
    }
}
