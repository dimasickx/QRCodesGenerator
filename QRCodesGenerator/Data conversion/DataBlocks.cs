using System;
using System.Collections.Generic;

namespace QRCodesGenerator
{
    public static class DataBlocks
    {
        private static int GetCountOfBlocks(Data data)
        {
            return TableOfBlocks.BlockMap[data.Level][data.Version];
        }

        public static IEnumerable<Block> SplitData(Data data)
        {
            var list = new List<Block>();
            var countOfBlocks = GetCountOfBlocks(data);
            var dataByte = data.DataBit.Length / 8;
            var dataInOneBlock = dataByte / countOfBlocks;
            var modulo = dataByte % countOfBlocks;
            if (modulo == 0)
                Split(data.DataBit, countOfBlocks, dataInOneBlock, list, 8);
            else
            {
                var temporalData = Split(data.DataBit, countOfBlocks - modulo, dataInOneBlock, list, 8);
                dataInOneBlock = temporalData.Length / modulo;
                Split(temporalData, modulo, dataInOneBlock, list, 1);
            }

            return list;
        }

        private static string Split(string data, int block, int dataInOneBlock, List<Block> list, int k)
        {
            for (var i = 0; i < block; i++)
            {
                list.Add(new Block(data.Substring(0, dataInOneBlock * k)));
                if (dataInOneBlock - 1 != data.Length - 1)
                    data = data.Substring(dataInOneBlock * k - 1, data.Length - dataInOneBlock * k);
                else
                    break;
            }

            return data;
        }
    }
}