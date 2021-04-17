using System.IO;

namespace Flowcharts
{
    public static class Memory
    {
        public static MemoryStream MemoryStream;

        public static MemoryStream SetMemoryStream(MemoryStream memoryStream)
        {
            MemoryStream = memoryStream;
            return memoryStream;
        }
    }
}
