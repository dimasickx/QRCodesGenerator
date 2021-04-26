using System;

namespace QRCodesGenerator
{
    public class Data
    {
        public string DataBit;
        public readonly CorrectionLevel Level;
        public readonly string CodingType;
        public int Version => GetVersion(Level, DataBit.Length); 

        public Data(string data, CorrectionLevel level, Encode encode, string codingType)
        {
            DataBit = encode(data);
            Level = level;
            CodingType = codingType;
        }
        private static int GetVersion(CorrectionLevel level, int dataLenght)
        {
            foreach (var l in TableOfVersions.VersionMap.Keys)
            {
                if (level != l) continue;
                for (var i = 0; i < TableOfVersions.VersionMap[l].Length; i++)
                {
                    if (dataLenght < TableOfVersions.VersionMap[l][i])
                        return i;
                }
            }

            throw new NullReferenceException("level not exist");
        }
    }
}