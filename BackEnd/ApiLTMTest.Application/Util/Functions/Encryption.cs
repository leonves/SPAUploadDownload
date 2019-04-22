using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLTMTest.Application.Util
{
    public static class Encryption
    {
        public static string Encrypt(string text)
        {
            byte xorConstant = 0x13;
            byte[] data = Encoding.UTF8.GetBytes(text);
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)(data[i] ^ xorConstant);
            }
            string output = Convert.ToBase64String(data);

            return output;
        }

        public static string Decrypt(string input)
        {
            byte xorConstant = 0x13;
            byte[] data = Convert.FromBase64String(input);
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)(data[i] ^ xorConstant);
            }
            string output = Encoding.UTF8.GetString(data);

            return output;
        }
    }
}
