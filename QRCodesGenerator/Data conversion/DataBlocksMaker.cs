using System;
using System.Collections.Generic;

namespace QRCodesGenerator
{
    public static class DataBlocksMaker
    {
        private static int GetCountOfBlocks(Data data)
        {
            return TableOfBlocks.BlockMap[data.Level][data.Version];
        }

        public static IEnumerable<DataBlock> SplitData(Data data)
        {
            var list = new List<DataBlock>();
            var countOfBlocks = GetCountOfBlocks(data);
            var dataByte = data.DataBit.Length / 8;
            var dataInOneBlock = dataByte / countOfBlocks;
            var modulo = dataByte % countOfBlocks;
            if (modulo == 0)
                Split(data.DataBit, countOfBlocks, dataInOneBlock, list, 8, data.Level, data.Version);
            else
            {
                var temporalData = Split(data.DataBit, countOfBlocks - modulo,
                    dataInOneBlock, list, 8, data.Level, data.Version);
                dataInOneBlock = temporalData.Length / modulo;
                Split(temporalData, modulo, dataInOneBlock, list, 1, data.Level, data.Version);
            }

            return list;
        }

        private static string Split(string data, int countOfBlock, int dataInOneBlock, ICollection<DataBlock> list, int k,
            CorrectionLevel level, int version)
        {
            for (var i = 0; i < countOfBlock; i++)
            {
                list.Add(new DataBlock(data.Substring(0, dataInOneBlock * k), level, version));
                if (dataInOneBlock - 1 != data.Length - 1)
                    data = data.Substring(dataInOneBlock * k - 1, data.Length - dataInOneBlock * k);
                else
                    break;
            }

            return data;
        }
    }
}