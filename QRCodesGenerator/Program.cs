using System;
using System.Text;

namespace QRCodesGenerator
{
    public delegate string Encode(string data);
    class Program
    {
        static void Main()
        {
            const string example = "1101000010100101110100001011000011010000101100011101000110000000";
            Console.WriteLine(example.Length);
            var encode = new Encode(TypeEncoding.ByteEncode);
            var data = new Data("Хабр", CorrectionLevel.M, encode, "0100");
            var resultData = QrCodeInfo.AddServiceInfo(data);
            var result = resultData.ComplementUpToMultiple8();
            var fullResult = result.ComplementUpToVersion(data);
            data.DataBit = fullResult;
            Console.WriteLine(resultData);
            Console.WriteLine(result);
            Console.WriteLine(fullResult);
        }
    }
}