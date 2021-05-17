using System.Collections.Generic;

namespace QRCodesGenerator
{
    public class DataBlock
    {
        public List<int> Data { get;}
        public int CountOfCorrectionBytes;

        public DataBlock(List<int> data, CorrectionLevel level, int version)
        {
            Data = data;
            CountOfCorrectionBytes = GetCount(level, version);
        }

        private static int GetCount(CorrectionLevel level, int version)
        {
            return TableCorrectionBytes.BytesMap[level][version];
        }
        
        
    }
}