using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
