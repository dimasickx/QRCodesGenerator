using System;

namespace QRCodesGenerator
{
    class Program
    {
        static void Main()
        {
            // const string codingType = "0100"; // задать словарь чтоли
            // var data = new Data("testing string for version of data in bit view!", CorrectionLevel.M, TypeEncoding.ByteEncode,
            //     codingType);
            //
            // data.DataBit = DataServiceInfo
            // .AddServiceInfo(data);
            //
            // var listOfBlocks = DataBlocksMaker.SplitData(data);
            // var offset = BlocksCorrectionBytes.AddOffsetToBlocks(listOfBlocks);
            //
            // var resultForPrint = DataReadyToPrint.CombinationBlocks(listOfBlocks, offset);
            var s = "testing string for version of data in bit ";
            var v = TypeEncoding.ByteEncode(s);
            Console.WriteLine(v.Length);
        }
    }
}