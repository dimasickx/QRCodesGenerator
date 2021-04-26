using System.Dynamic;

namespace QRCodesGenerator
{
    public interface ICodingType
    {
        public string CodingType { get; set; }
        public string Encode(string data);
    }
}