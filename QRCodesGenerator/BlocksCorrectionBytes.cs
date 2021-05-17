using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QRCodesGenerator
{
    public static class BlocksCorrectionBytes
    {
        public static List<CorrectionBlock> AddOffsetToBlocks(IEnumerable<DataBlock> blocks)
        {
            var correctionBlocks = new List<CorrectionBlock>(); // надо менять
            foreach (var block in blocks)
            {
                var listOfCorrection = MakeListOfCorrection(block.Data, block.CountOfCorrectionBytes);
                correctionBlocks.Add(SetByteCorrection(listOfCorrection, block.CountOfCorrectionBytes, block.Data.Count));
            }

            return correctionBlocks;
        }

        public static IEnumerable<int> MakeListOfCorrection(IEnumerable<int> block, int countOfCorrectionBytes)
        {
            var result = block.ToList();
            for (int i = 0; i < countOfCorrectionBytes - block.Count(); i++) result.Add(0);
            return result;
        }

        public static CorrectionBlock SetByteCorrection(IEnumerable<int> _list, int countOfCorrectionBytes, int countOfByteInBlock)
        {
            var listOfCorrection = _list.ToList();
            for (int i = 0; i < countOfByteInBlock; i++)
            {
                var index = listOfCorrection[0];
                if (index == 0) continue;
                listOfCorrection.RemoveAt(0);
                listOfCorrection.Add(0);
                var galoisCoefficient = TableGaloisField.inverseField[index];
                var polynomial = TableGeneratingPolynomials.Polynomials[countOfCorrectionBytes];
                var lastList = new List<int>();
                for (int j = 0; j < polynomial.Length; j++)
                {
                    var r = (polynomial[j] + galoisCoefficient) % 255;
                    lastList.Add(TableGaloisField.Field[r]);
                }

                for (int j = 0; j < listOfCorrection.Count; j++)
                {
                    listOfCorrection[j] = listOfCorrection[j] ^ lastList[j];
                }
            }

            return new CorrectionBlock(listOfCorrection);
        }
    }
}