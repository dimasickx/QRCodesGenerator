using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace QRCodesGenerator
{
    public class AlphanumericCoding : ICodingType
    {
        private static readonly Dictionary<char, int> Symbols;

        static AlphanumericCoding()
        {
            Symbols = new Dictionary<char, int>
            {
                {' ', 36},
                {'$', 37},
                {'%', 38},
                {'*', 39},
                {'+', 40},
                {'-', 41},
                {'.', 42},
                {'/', 43},
                {':', 44}
            };
        }

        //  весь АЛФАВИТ засунуть в словарь
        // каждую вторую умножаем можно сдлеать как в задаче Модульность

        public string Encode(string data)
        {
            throw new NotImplementedException();
        }
    }
}