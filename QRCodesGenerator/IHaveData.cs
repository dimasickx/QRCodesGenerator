using System.Collections.Generic;

namespace QRCodesGenerator
{
    public interface IHaveData
    {
        List<int> Data { get; }
    }
}
// Заменить все дата блоки на IhaveData