using System.Collections.Generic;

namespace QRCodesGenerator
{
    public struct TableServiceInfo
    {
        public static Dictionary<int, int[]> LenOfServiceCell;

        static TableServiceInfo()
        {
            LenOfServiceCell = new Dictionary<int, int[]>
            {
                {9, new[] {10, 9, 8}},
                {26, new[] {12, 11, 16}},
                {40, new[] {14, 13, 16}}
            };
        }
    }
}