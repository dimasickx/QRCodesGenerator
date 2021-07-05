using System;
using System.ComponentModel.Design;
using System.Text;

namespace QRCodesGenerator
{
    public static class ExtensionDataComplement
    {
        public static string SupplementToMultiple(this string str, int multiple, bool inFront)
        {
            var modulo = str.Length % multiple;
            var s = new StringBuilder(multiple - modulo);
            for (var i = 0; i < multiple - modulo; i++)
                s.Append('0');
            if (inFront)
                return s + str;
            return str + s;
        }
        
        public static string DigitToBit(this string data, int bits)
        {
            var dataInBits = Convert.ToString(int.Parse(data), 2);
            var s = "";
            var complement = bits - dataInBits.Length;
            while (complement != 0)
            {
                s += '0';
                complement--;
            }

            return s + dataInBits;
        }
    }
}