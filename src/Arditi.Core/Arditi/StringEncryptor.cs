using System.Security.Cryptography;
using System.Text;

namespace Arditi;

public static class StringEncryptor
{
    private static string ComputeHash(HashAlgorithm algorithm, string plainText)
    {
        using (algorithm)
            return string.Empty.Join(algorithm
                .ComputeHash(Encoding.UTF8.GetBytes(ExceptionHelper.NotEmpty(plainText, nameof(plainText))))
                .Select(item => item.ToString("x2")));
    }

    public static string Md5(string plainText) => ComputeHash(MD5.Create(), plainText);

    public static string Sha1(string plainText) => ComputeHash(SHA1.Create(), plainText);

    public static string Sha256(string plainText) => ComputeHash(SHA256.Create(), plainText);

    public static string Sha384(string plainText) => ComputeHash(SHA384.Create(), plainText);

    public static string Sha512(string plainText) => ComputeHash(SHA512.Create(), plainText);
}
