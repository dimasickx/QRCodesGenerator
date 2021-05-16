namespace QRCodesGenerator
{
    public class DataBlock : IHaveData
    {
        public string Data { get;}
        public int CountOfCorrectionBytes;

        public DataBlock(string data, CorrectionLevel level, int version)
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