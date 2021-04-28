using System;

namespace QRCodesGenerator
{
    public static class DataServiceInfo
    {
        public static string AddServiceInfo(Data data)
        {
            var codingType = data.CodingType;
            var lenOfCell = GetLenOfCellData(data, codingType);
            var amountOfData = GetAmountOfDataInBinaryView(data, codingType, lenOfCell);
            var str = codingType + amountOfData + data.DataBit;
            var result = CheckVersionIsCorrect(str, data);

            return result;
        } 

        private static string CheckVersionIsCorrect(string str, Data data)
        {
            if (str.Length <= TableOfVersions.VersionMap[data.Level][data.Version]) return str;
            data.DataBit = str;
            return AddServiceInfo(data);

        }

        private static int GetLenOfCellData(Data data, string codingType)
        {
            foreach (var v in TableServiceInfo.ServiceMap.Keys)
            {
                if (data.Version > v) continue;
                if (codingType == "0001")
                    return TableServiceInfo.ServiceMap[v][0];
                if (codingType == "0010")
                    return TableServiceInfo.ServiceMap[v][1];

                return TableServiceInfo.ServiceMap[v][2];
            }

            throw new NullReferenceException();
        }

        private static string GetAmountOfDataInBinaryView(Data data, string codingType, int lenOfCell)
        {
            if (codingType != "0100") return TypeEncoding.DigitToBit(data.DataBit.Length.ToString(), lenOfCell);
            var b = data.DataBit.Length / 8;
            return TypeEncoding.DigitToBit(b.ToString(), lenOfCell);
        }
    }
}