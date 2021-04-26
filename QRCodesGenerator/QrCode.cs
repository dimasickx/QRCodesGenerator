﻿using System;

namespace QRCodesGenerator
{
    public class QrCode
    {
        public string Data { get; set; }
        public readonly CorrectionLevel Level;
        public readonly Encode Encode;
        public readonly string CodingType;
        public int Version => GetVersion(Level, Data.Length);

        public QrCode(CorrectionLevel level, Encode encode, string type)
        {
            Level = level;
            Encode = encode;
            CodingType = type;
        }

        private static int GetVersion(CorrectionLevel level, int dataLenght)
        {
            foreach (var l in TableOfVersions.VersionMap.Keys)
            {
                if (level != l) continue;
                for (var i = 0; i < TableOfVersions.VersionMap[l].Length; i++)
                {
                    if (dataLenght < TableOfVersions.VersionMap[l][i])
                        return i + 1;
                }
            }

            throw new NullReferenceException("level not exist");
        }
    }
}