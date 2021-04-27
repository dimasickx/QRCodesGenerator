using System;
using System.Text;

namespace QRCodesGenerator
{
    public delegate string Encode(string data);

    class Program
    {
        static void Main()
        {
            var encode = new Encode(TypeEncoding.ByteEncode);
            
            var data = new Data("Хабрахабраледядя че то поменяется?", CorrectionLevel.M, encode, "0100");
            data.DataBit = QrCodeInfo
                .AddServiceInfo(data)                               // мб сделать Extension
                .ComplementUpToMultiple8()
                .ComplementUpToVersion(data);
            
            var listOfBlocks = DataBlocks.SplitData(data);
            foreach (var block in listOfBlocks)
            {
                Console.WriteLine(block.Data);
            }
        }
    }
}