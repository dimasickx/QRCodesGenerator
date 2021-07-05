using System.Collections.Generic;
using NUnit.Framework;
using QRCodesGenerator;

namespace MinimalTests
{
    public class Tests
    {
        private Data _someData;
        [SetUp]
        public void Setup()
        {
            const string someStr = "testing string for version of data in bit view";
            _someData = new Data(someStr, CorrectionLevel.L, TypeEncoding.ByteEncode, "0100");
        }

        [Test]
        public void Test1()
        {
            var expect = new List<int>
            {
                16, 85, 12, 231, 54, 54, 140, 70, 118, 84, 10, 174, 235, 197, 99, 218, 12, 254, 246, 4, 190, 56, 39,
                217, 115, 189, 193, 24
            };
            var listOfCorrection = new List<int>
            {
                64, 196, 132, 84, 196, 196, 242, 194, 4, 132, 20, 37, 34, 16, 236, 17, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0
            };
            var block = BlocksCorrectionBytes.SetByteCorrection(listOfCorrection, 28, 16);
            Assert.AreEqual(expect, block.Data);
        }

        [Test]
        public void TestGetVersionOfData()
        {
            var value = TableOfVersions.AmountInfoForVersion[CorrectionLevel.L][_someData.Version];
            Assert.IsTrue(_someData.DataBit.Length < value);
            Assert.AreEqual(2, _someData.Version);
        }

        [Test]
        public void TestAddingServiceInfo()
        {
            var someStr = "00000111111111111111111111100000";
            var countOfByte = someStr.Length / 8;
            var data = new Data(" ", CorrectionLevel.L, s => s, "0100");
            data.DataBit = someStr;
            var expected = ("0100" + countOfByte.ToString().DigitToBit(8) + someStr);  // .SupplementToMultiple() (не верно рабоатет) походу это не делаю в строке  13 а делаю в returne?
            
            Assert.AreEqual("0100" + countOfByte.ToString().DigitToBit(8) + someStr, DataServiceInfo.AddServiceInfo(data));
        }
    }
}