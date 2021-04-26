using System.Dynamic;

namespace QRCodesGenerator
{
    public interface ICodingType
    {
        public string Encode(string data);
    }
}