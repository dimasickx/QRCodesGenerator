namespace QRCodesGenerator
{
    public delegate string Encode(string data);

    class Program
    {
        static void Main()
        {
            var encode = new Encode(TypeEncoding.ByteEncode);
            
            var data = new Data("Хабрахабраледядя че то поменяется?", CorrectionLevel.M, encode, "0100");
            data.DataBit = DataServiceInfo
                .AddServiceInfo(data)                               
                .ComplementUpToMultiple8()
                .ComplementUpToVersion(data);
            
            var listOfBlocks = DataBlocksMaker.SplitData(data);
            
        }
    }
}