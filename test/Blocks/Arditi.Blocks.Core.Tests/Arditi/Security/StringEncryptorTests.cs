using Shouldly;

namespace Arditi.Security;

public class StringEncryptorTests
{
    [Fact]
    public void Md5Test()
    {
        StringEncryptor.Md5("dokey").ShouldBe("8a52441135ffaf418076ce92dc5d6640");
    }

    [Fact]
    public void Sha1Test()
    {
        StringEncryptor.Sha1("dokey").ShouldBe("d6cf8f97dedc91f7f2c7a5b560c63b799a6ca9bf");
    }

    [Fact]
    public void Sha256Test()
    {
        StringEncryptor.Sha256("dokey").ShouldBe("d3ec51d2af42c4922afd75ac84b03460b8d37e3e391dc0cec13192e6cf547c02");
    }

    [Fact]
    public void Sha384Test()
    {
        StringEncryptor.Sha384("dokey")
            .ShouldBe(
                "65423cf36dd0cdf1bfd756f889f6404d9e42fd51a52e78fe8c7ab9fb1fc70bf3d2ea252c26642196b0bc67bc8f911ff9");
    }

    [Fact]
    public void Sha512Test()
    {
        StringEncryptor.Sha512("dokey")
            .ShouldBe(
                "9fa4afe302769c6d529af334eddaf02c9579174e185c663440a708a1be17538166c78a106ab31f8e29d67a5483d0935bf3010a1fecea6e2ae0c74b42484cd1af");
    }
}
