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
                (current, b) => current + Convert.ToString(b, 2)).SupplementToMultiple(8, true);
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
                result += r.DigitToBit(10);
                s.Remove(0, 3);
            }

            for (var i = 0; i < modulo - 1; i++)
            {
                if (modulo == 2)
                    result += (s[0] - '0' + (s[1] - '0').ToString()).DigitToBit(7);
                else
                    result += (s[0] - '0').ToString().DigitToBit(4);
            }

            return result;
        }
    }
}