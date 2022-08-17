using System.Text;

namespace Arditi;

public static class StringBase64Encoder
{
    public static string Encode(string plainText) =>
        Convert.ToBase64String(Encoding.UTF8.GetBytes(Check.NotEmpty(plainText, nameof(plainText))));

    public static string Decode(string cipherText) =>
        Encoding.UTF8.GetString(Convert.FromBase64String(Check.NotEmpty(cipherText, nameof(cipherText))));
}
