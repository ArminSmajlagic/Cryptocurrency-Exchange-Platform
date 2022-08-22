using System.Security.Cryptography;
using System.Text;

namespace servisi.trading.Configuration
{
    public static class Cryptography
    {

        public static string SH256_string(string val)
        {

            HashAlgorithm sha = SHA256.Create();

            byte[] bytes = Encoding.ASCII.GetBytes(val);

            byte[] result = sha.ComputeHash(bytes);

            string res = Encoding.ASCII.GetString(result);

            return res;
        }

        public static byte[] SH256_bytes(string val)
        {

            HashAlgorithm sha = SHA256.Create();

            byte[] bytes = Encoding.ASCII.GetBytes(val);

            byte[] result = sha.ComputeHash(bytes);

            string res = Encoding.ASCII.GetString(result);

            return result;
        }
    }
}
