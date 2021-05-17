using System.Text;

namespace QRCodesGenerator
{
    public static class ExtensionDataComplement
    {
        public static string SupplementToMultiple(this string str, int multiple)
        {
            var modulo = str.Length % multiple;
            var s = new StringBuilder(multiple - modulo);
            for (var i = 0; i < multiple - modulo; i++)
                s.Append('0');
            return str + s;
        }
    }
}