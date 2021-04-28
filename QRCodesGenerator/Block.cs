namespace QRCodesGenerator
{
    public class Block
    {
        public string Data;
        public int CountOfCorrectionBytes;

        public Block(string data, CorrectionLevel level, int version)
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