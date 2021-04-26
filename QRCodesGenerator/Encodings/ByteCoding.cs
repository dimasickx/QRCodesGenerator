using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace QRCodesGenerator
{
    public class ByteCoding : ICodingType
    {
        public string Encode(string data)
        {
            var encodeData = Encoding.UTF8.GetBytes(data);
            var result = encodeData.Aggregate("",
                (current, b) => current + Convert.ToString(b, 2));
            return result;
        }
    }
}