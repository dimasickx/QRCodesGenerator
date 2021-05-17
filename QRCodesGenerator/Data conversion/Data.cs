using System;

namespace QRCodesGenerator
{
    public class Data
    {
        public string DataBit;
        public readonly CorrectionLevel Level;
        public readonly string CodingType;
        public int Version => GetVersion(Level, DataBit.Length); 

        public Data(string data, CorrectionLevel level, Func<string, string> encode, string codingType)
        {
            DataBit = encode(data);
            Level = level;
            CodingType = codingType;
        }
        private static int GetVersion(CorrectionLevel level, int dataLenght)
        {
            for (var i = 0; i < TableOfVersions.AmountInfoForVersion[level].Length; i++) // TODO тут нужно использовать сортировку
            {
                if (dataLenght < TableOfVersions.AmountInfoForVersion[level][i])
                    return i;
            }

            throw new NullReferenceException("level not exist");
        }
    }
}