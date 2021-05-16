using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QRCodesGenerator
{
    public static class BlocksCorrectionBytes
    {
        public static IEnumerable<IEnumerable<string>> AddOffsetToBlocks(IEnumerable<DataBlock> blocks)
        {
            var k = new List<IEnumerable<string>>(); // надо менять
            foreach (var block in blocks)
            {
                var b = new StringBuilder(block.Data);
                var blockBytesInInt = BlockStrToBlockInt(b);
                var listOfCorrection = MakeListOfCorrection(blockBytesInInt, block.CountOfCorrectionBytes);
                k.Add(SetByteCorrection(listOfCorrection, block.CountOfCorrectionBytes, blockBytesInInt.Count()));
                // сетЬайт возвр лист байтов который является блоком коррекции
                // задумался над тем что будет лист байтов типа стринг на одной иттерации в этом цикле
                // что делать с этим листом и как складывать блоки в поток
            }

            return k;
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

        public static IEnumerable<int> MakeListOfCorrection(IEnumerable<int> block, int countOfCorrectionBytes)
        {
            var result = block.ToList();
            for (int i = 0; i < countOfCorrectionBytes - block.Count(); i++) result.Add(0);
            return result;
        }

        public static IEnumerable<string> SetByteCorrection(IEnumerable<int> _list, int countOfCorrectionBytes, int d)
        {
            var list = _list.ToList();
            var block = new List<string>();
            for (int i = 0; i < d; i++)
            {
                var a = list[0];
                if (a == 0) continue;
                list.RemoveAt(0);
                list.Add(0);
                var b = TableGaloisField.inverseField[a];
                var polynomials = TableGeneratingPolynomials.Polynomials[countOfCorrectionBytes];
                var lastList = new List<int>();
                for (int j = 0; j < polynomials.Length; j++)
                {
                    var r = (polynomials[j] + b) % 255;
                    lastList.Add(TableGaloisField.Field[r]);
                }

                for (int j = 0; j < list.Count; j++)
                {
                    block.Add(DigitalCoding.ToBit((list[j] ^ lastList[j]).ToString(), 8));
                }
            }

            return block;
        }

        public static IHaveData BlockMaker(string data, CorrectionLevel? level = null, int? version = null)
        {
            if (level != null && version != null)
                return new DataBlock(data, level.Value, version.Value);
            return new CorrectionBlock(data);;
        }
    }
}