using System;
using System.Linq;
using System.Text;

namespace QRCodesGenerator
{
    public static class TypeEncoding
    {
        public static string ByteEncode(string data)
        {
            var encodeData = Encoding.UTF8.GetBytes(data);
            var result = encodeData.Aggregate("",
                (current, b) => current + Convert.ToString(b, 2));
            return result;
        }

        public static string DigitEncode(string data)
        {
            var s = new StringBuilder(data);
            var modulo = data.Length % 3;
            var result = "";
            for (var i = 0; i < data.Length / 3; i++)
            {
                var r = s[0] - '0' + (s[1] - '0').ToString() + (s[2] - '0');
                result += DigitToBit(r, 10);
                s.Remove(0, 3);
            }

            for (var i = 0; i < modulo - 1; i++)
            {
                if (modulo == 2)
                    result += DigitToBit(s[0] - '0' + (s[1] - '0').ToString(), 7);
                else
                    result += DigitToBit((s[0] - '0').ToString(), 4);
            }

            return result;
        }

        public static string DigitToBit(string data, int b)
        {
            var bit = Convert.ToString(int.Parse(data), 2);
            var s = "";
            var complement = b - bit.Length;
            while (complement != 0)
            {
                s += '0';
                complement--;
            }

            return s + bit;
        }
    }
}