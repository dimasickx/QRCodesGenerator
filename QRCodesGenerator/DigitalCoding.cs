using System;
using System.Text;

namespace QRCodesGenerator
{
    public struct DigitalCoding : ICodingType
    {
        public string Encode(string data)
        {
            var s = new StringBuilder(data);
            var modulo = data.Length % 3;
            var result = "";
            for (var i = 0; i < data.Length / 3; i++)
            {
                var r = s[0] - '0' + (s[1] - '0').ToString() + (s[2] - '0');
                result += ToBit(r, 10);
                s.Remove(0, 3);
            }

            for (var i = 0; i < modulo - 1; i++)
            {
                if (modulo == 2)
                    result += ToBit(s[0] - '0' + (s[1] - '0').ToString(), 7);
                else
                    result += ToBit((s[0] - '0').ToString(), 4);
            }

            return result;
        }

        private static string ToBit(string data, int b)
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