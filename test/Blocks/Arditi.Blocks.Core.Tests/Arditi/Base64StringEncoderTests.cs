using Shouldly;

namespace Arditi;

public class Base64StringEncoderTests
{
    [Fact]
    public void Base64StringEncoderTest()
    {
        StringBase64Encoder.Decode(StringBase64Encoder.Encode("dokey")).ShouldBe("dokey");
    }
}
