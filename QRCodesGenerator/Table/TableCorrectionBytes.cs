using System.Collections.Generic;

namespace QRCodesGenerator
{
    public static class TableCorrectionBytes
    {
        public static readonly Dictionary<CorrectionLevel, int[]> BytesMap;
        static TableCorrectionBytes()
        {
            var mBytes = new[]
            {
                10, 16, 26, 18, 24, 16, 18, 22, 22, 26, 30, 22, 22, 24, 24, 28, 28, 26, 26, 26, 26, 28, 28, 28, 28, 28,
                28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28
            };
            BytesMap = new Dictionary<CorrectionLevel, int[]>
            {
                {CorrectionLevel.M, mBytes}
            };
        }
    }
}