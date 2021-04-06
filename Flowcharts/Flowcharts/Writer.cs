using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    public static class Writer
    {
        public static XmlWriter XmlWriter { get; private set; }

        public static XmlWriter CreateWriter(string FileName = null, string path = null)
        {
            XmlWriter = XmlWriter.Create(path + FileName + ".svg");
            return XmlWriter;            
        }

        public static XmlWriter CreateWriter(MemoryStream memoryStream)
        {
            XmlWriter = XmlWriter.Create(memoryStream);
            memoryStream.Position = 0;

            return XmlWriter;
        }
    }
}
