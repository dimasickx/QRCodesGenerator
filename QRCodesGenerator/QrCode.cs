namespace QRCodesGenerator
{
    public class QrCode
    {
        public string Data { get; set; }
        public readonly CorrectionLevel Level;
        public readonly Encode Encode;
        public int Version => Data.Length;

        public QrCode(CorrectionLevel level, Encode encode)
        {
            Level = level;
            Encode = encode;
        }
    }
}