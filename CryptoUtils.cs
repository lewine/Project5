using System.Security.Cryptography;
using System.Text;

namespace Assignment5_CSE445_Group_62
{
    public class CryptoUtils
    {
        public static string HashString(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); 
                }

                return sb.ToString();
            }
        }
    }
}
