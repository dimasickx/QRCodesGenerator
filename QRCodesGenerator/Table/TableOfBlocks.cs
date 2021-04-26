using System.Collections.Generic;

namespace QRCodesGenerator
{
    public static class TableOfBlocks
    {
        public static readonly Dictionary<CorrectionLevel, int[]> BlockMap;

        static TableOfBlocks()
        {
            var lBlocks = new[]
            {
                1, 1, 1, 1, 1, 2, 2, 2, 2, 4, 4, 4, 4, 4, 6, 6, 6, 6, 7, 8, 8, 9, 9, 10, 12, 12, 12, 13, 14, 15, 16, 17,
                18, 19, 19, 20, 21, 22, 24, 25
            };
            var mBlocks = new[]
            {
                1, 1, 1, 2, 2, 4, 4, 4, 5, 5, 5, 8, 9, 9, 10, 10, 11, 13, 14, 16, 17, 17, 18, 20, 21, 23, 25, 26, 28,
                29, 31, 33, 35, 37, 38, 40, 43, 45, 47, 49
            };
            BlockMap = new Dictionary<CorrectionLevel, int[]>
            {
                {CorrectionLevel.L, lBlocks},
                {CorrectionLevel.M, mBlocks}
            };
        }
    }
}