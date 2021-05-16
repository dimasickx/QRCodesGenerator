using System.Collections.Generic;
using NUnit.Framework;
using QRCodesGenerator;

namespace MinimalTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var list = new List<int>()
            {
                64, 196, 132, 84, 196, 196, 242, 194, 4, 132, 20, 37, 34, 16, 236, 17, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0
            };
            var a = BlocksCorrectionBytes.SetByteCorrection(list, 28, 16);
            var b = new List<int>()
            {
                16, 85, 12, 231, 54, 54, 140, 70, 118, 84, 10, 174, 235, 197, 99, 218, 12, 254, 246, 4, 190, 56, 39,
                217, 115, 189, 193, 24
            };
            Assert.AreEqual(a, b);
        }
    }
}