﻿namespace QRCodesGenerator
{
    public static class MVersions
    {
        public static readonly int[] MLevel;
        // походу надо через инетефес переделать в класс с методом который возвращает версию

        static MVersions()
        {
            MLevel = new[]
            {
                128, 224, 352, 512, 688, 864, 992, 1232, 1456, 1728, 2032, 2320, 2672, 2920, 3320, 3624, 4056, 4504,
                5016, 5352, 5712, 6256, 6880, 7312, 8000, 8496, 9024, 9544, 10136, 10984, 11640, 12328, 13048, 13800,
                14496, 15312, 15936, 16816, 17728, 18672
            };
        }
    }
}