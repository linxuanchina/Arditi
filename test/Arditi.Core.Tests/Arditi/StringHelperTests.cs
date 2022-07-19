using Shouldly;

namespace Arditi;

public class StringHelperTests
{
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "", false)]
    [InlineData("dokey", "dokey", true)]
    [InlineData("dokey", "dokey", false)]
    [InlineData("dokey", "DOKEY", true)]
    [InlineData("dokey", "doKey", true)]
    public void CompareTest(string left, string right, bool ignoreCase)
    {
        StringHelper.Compare(left, right, ignoreCase).ShouldBeTrue();
    }
}
