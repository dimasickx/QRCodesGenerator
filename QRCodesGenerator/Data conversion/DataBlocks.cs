namespace QRCodesGenerator
{
    public static class DataBlocks
    {
        public static int GetCountOfBlocks(Data data)
        {
            return TableOfBlocks.BlockMap[data.Level][data.Version];
        }

        public static void IDK(Data data)
        {
            var countOfBlocks = GetCountOfBlocks(data);
            var dataByte = data.DataBit.Length / 8;
            int dataInOneBlock;
            if (data.DataBit.Length % 8 == 0)
                dataInOneBlock = dataByte / countOfBlocks;
            else
            {
                // создать блоки походу и в qrCode сдлеать массив блоков    
            }
        }
    }
}