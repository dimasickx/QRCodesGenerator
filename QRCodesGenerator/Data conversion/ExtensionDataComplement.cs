using System.Text;

namespace QRCodesGenerator
{
    public static class ExtensionDataComplement
    {
        public static string ComplementUpToMultiple8(this string str)
        {
            var modulo = str.Length % 8;
            var s = new StringBuilder(modulo);
            for (var i = 0; i < modulo; i++)
                s.Append('0');
            return str + s;
        }

        public static string ComplementUpToVersion(this string str, Data data)
        {
            const string first = "11101100";
            const string second = "00010001";
            var s = new StringBuilder();
            var fullBite = TableOfVersions.VersionMap[data.Level][data.Version];
            var needToComplement = fullBite - str.Length;
            for (var i = 0; i < needToComplement / 8; i++)
            {
                s.Append(i % 2 == 0 ? first : second);
            }

            return str + s;

        }
    }
}