using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Toxic.Core
{
    /// <summary>
    /// 密码相关操作
    /// </summary>
    public static class Cryptography
    {
        public static string EncryptMd5(string source)
        {
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(Encoding.UTF8.GetBytes(source)).Select(item => item.ToString("x2")).StringJoin(string.Empty);
            }
        }
        
        public static string EncryptSha1(string source)
        {
            using (var sha1 = SHA1.Create())
            {
                return sha1.ComputeHash(Encoding.UTF8.GetBytes(source)).Select(item => item.ToString("x2")).StringJoin(string.Empty);
            }
        }
        
        public static string EncryptSha256(string source)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(source)).Select(item => item.ToString("x2")).StringJoin(string.Empty);
            }
        }

        public static string EncryptSha384(string source)
        {
            using (var sha384 = SHA384.Create())
            {
                return sha384.ComputeHash(Encoding.UTF8.GetBytes(source)).Select(item => item.ToString("x2")).StringJoin(string.Empty);
            }
        }

        public static string EncryptSha512(string source)
        {
            using (var sha512 = SHA512.Create())
            {
                return sha512.ComputeHash(Encoding.UTF8.GetBytes(source)).Select(item => item.ToString("x2")).StringJoin(string.Empty);
            }
        }
    }
}