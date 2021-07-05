using System;
using System.Text;

namespace QRCodesGenerator
{
    public static class DataServiceInfo
    {
        public static string AddServiceInfo(Data data)
        {
            var codingType = data.CodingType;
            var lenOfCell = GetLenOfServiceCell(data, codingType);
            var amountOfData = GetAmountOfDataInBinaryView(data, codingType, lenOfCell);
            var str = codingType + amountOfData + data.DataBit;
            var result = CheckVersionIsCorrect(str, data);

            return ComplementUpToVersion(result.SupplementToMultiple(8, false), data.Level, data.Version);
        } 

        private static string CheckVersionIsCorrect(string str, Data data)
        {
            if (str.Length <= TableOfVersions.AmountInfoForVersion[data.Level][data.Version]) return str;
            data.DataBit = str;
            return AddServiceInfo(data);

        }

        private static int GetLenOfServiceCell(Data data, string codingType)
        {
            foreach (var version in TableServiceInfo.LenOfServiceCell.Keys)
            {
                if (data.Version > version) continue;
                if (codingType == "0001")
                    return TableServiceInfo.LenOfServiceCell[version][0];
                if (codingType == "0010")
                    return TableServiceInfo.LenOfServiceCell[version][1];

                return TableServiceInfo.LenOfServiceCell[version][2];
            }

            throw new NullReferenceException();
        }

        private static string GetAmountOfDataInBinaryView(Data data, string codingType, int lenOfCell)
        {
            if (codingType != "0100") return data.DataBit.Length.ToString().DigitToBit(lenOfCell);
            var b = data.DataBit.Length / 8;
            return b.ToString().DigitToBit(lenOfCell);
        }
        
        private static string ComplementUpToVersion(string str, CorrectionLevel level, int version)
        {
            const string first = "11101100";
            const string second = "00010001";
            var s = new StringBuilder();
            var fullBite = TableOfVersions.AmountInfoForVersion[level][version];
            var needToComplement = fullBite - str.Length;
            for (var i = 0; i < needToComplement / 8; i++)
            {
                s.Append(i % 2 == 0 ? first : second);
            }

            return str + s;

        }
    }
}