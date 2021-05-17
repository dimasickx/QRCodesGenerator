using System.Collections.Generic;

namespace QRCodesGenerator
{
    public class CorrectionBlock
    {
        public List<int> Data { get; }

        public CorrectionBlock(List<int> data)
        {
            Data = data;
        }
    }
}