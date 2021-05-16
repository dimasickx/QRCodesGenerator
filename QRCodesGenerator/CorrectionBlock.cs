namespace QRCodesGenerator
{
    public class CorrectionBlock : IHaveData
    {
        public string Data { get; }

        public CorrectionBlock(string data)
        {
            Data = data;
        }
    }
}