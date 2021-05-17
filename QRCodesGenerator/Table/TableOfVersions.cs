using System.Collections.Generic;

namespace QRCodesGenerator
{
    public static class TableOfVersions
    {
        public static readonly Dictionary<CorrectionLevel, int[]> AmountInfoForVersion;

        static TableOfVersions()
        {
            var lLevel = new[]
            {
                152, 272, 440, 640, 864, 1088, 1248, 1552, 1856, 2192, 2592, 2960, 3424, 3688, 4184, 4712, 5176, 5768,
                6360, 6888, 7456, 8048, 8752, 9392, 10208, 10960, 11744, 12248, 13048, 13880, 14744, 15640, 16568,
                17528, 18448, 19472, 20528, 21616, 22496, 23648
            };
            var mLevel = new[]
            {
                128, 224, 352, 512, 688, 864, 992, 1232, 1456, 1728, 2032, 2320, 2672, 2920, 3320, 3624, 4056, 4504,
                5016, 5352, 5712, 6256, 6880, 7312, 8000, 8496, 9024, 9544, 10136, 10984, 11640, 12328, 13048, 13800,
                14496, 15312, 15936, 16816, 17728, 18672
            };
            AmountInfoForVersion = new Dictionary<CorrectionLevel, int[]>
            {
                {CorrectionLevel.L, lLevel},
                {CorrectionLevel.M, mLevel}
            };

        }
    }
}