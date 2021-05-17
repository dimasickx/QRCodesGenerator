using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QRCodesGenerator
{
    public static class DataBlocksMaker
    {
        private static int GetCountOfBlocks(Data data)
        {
            return TableOfBlocks.BlockMap[data.Level][data.Version];
        }

        public static List<DataBlock> SplitData(Data data)
        {
            var list = new List<DataBlock>();
            var countOfBlocks = GetCountOfBlocks(data);
            var countByteOfData = data.DataBit.Length / 8;
            var dataInOneBlock = countByteOfData / countOfBlocks;
            var modulo = countByteOfData % countOfBlocks;
            if (modulo == 0)
                Split(data.DataBit, data.Level, data.Version, countOfBlocks, dataInOneBlock, list, 8);
            else
            {
                var temporalData = Split(data.DataBit, data.Level, data.Version, countOfBlocks - modulo,
                    dataInOneBlock, list, 8);
                dataInOneBlock = temporalData.Length / modulo;
                Split(temporalData, data.Level, data.Version, modulo, dataInOneBlock, list, 1);
            }

            return list;
        }

        private static string Split(string data, CorrectionLevel level, int version, int countOfBlock,
            int dataInOneBlock, ICollection<DataBlock> list, int k)
        {
            for (var i = 0; i < countOfBlock; i++)
            {
                list.Add(BlockMaker(data.Substring(0, dataInOneBlock * k), level, version));
                if (dataInOneBlock - 1 != data.Length - 1)
                    data = data.Substring(dataInOneBlock * k - 1, data.Length - dataInOneBlock * k);
                else
                    break;
            }

            return data;
        }

        public static DataBlock BlockMaker(string data, CorrectionLevel level, int version)
        {
            var d = new StringBuilder(data);
            var res = BlockStrToBlockInt(d);
            return new DataBlock(res.ToList(), level, version);
        }
        
        public static IEnumerable<int> BlockStrToBlockInt(StringBuilder data)
        {
            var block = new List<int>();
            for (int i = 0; i < data.Length / 8; i++)
            {
                var digitByte = data.ToString(0, 8);
                data.Remove(0, 8);
                var digit = Convert.ToInt32(digitByte, 2);
                block.Add(digit);
            }

            return block;
        }
    }
}