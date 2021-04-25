using System;

namespace QRCodesGenerator
{
    public delegate string Encode(string data);
    class Program
    {
        static void Main()
        {
            const string example = "000111101101110010001001110";
            
            var encode = new Encode(TypeEncoding.DigitEncode);
            
            var qr = new QrCode(CorrectionLevel.M, encode);
            qr.Data = qr.Encode("12345678");

            var mLevel = MVersions.MLevel;
            var lLevel = LVersions.LLevel;
            
            Console.WriteLine(qr.Data);
            Console.WriteLine(example);
            Console.WriteLine(qr.Data == example);
            Console.WriteLine(qr.Version);
        }
        
    }
}