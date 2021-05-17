using System;

namespace QRCodesGenerator
{
    class Program
    {
        static void Main()
        {
            const string codingType = "0100"; // задать словарь чтоли
            var data = new Data("Хабрахабр але дядя че то поменяется?", CorrectionLevel.M, TypeEncoding.ByteEncode,
                codingType);

            data.DataBit = DataServiceInfo
                .AddServiceInfo(data);
            
            var listOfBlocks = DataBlocksMaker.SplitData(data);
            var offset = BlocksCorrectionBytes.AddOffsetToBlocks(listOfBlocks);
            var resultForPrint = DataReadyToPrint.CombinationBlocks(listOfBlocks, offset);
        }
    }
}