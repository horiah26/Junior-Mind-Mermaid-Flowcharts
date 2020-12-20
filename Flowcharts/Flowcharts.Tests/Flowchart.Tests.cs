using System.IO;
using System.Xml;
using Xunit;

namespace Flowcharts.Tests
{
    public class UnitTest1
    {        
        [Fact]
        public void CanAddAPair()
        {
            MemoryStream stream = new MemoryStream();

            var flowchart = new Flowchart(stream);
            flowchart.AddPair( "A",  "B");
            flowchart.Draw();

            XmlReader reader = XmlReader.Create(stream);

            reader.ReadStartElement("svg");
            Assert.Equal("rect", reader.Name);

            Assert.Equal("52",reader.GetAttribute("x"));
            Assert.Equal("33",reader.GetAttribute("y"));

            reader.Read();
            Assert.Equal("text",reader.Name);
            reader.Read();
            Assert.Equal("A",reader.Value);

            reader.Read();
            Assert.Equal("text",reader.Name);

            reader.Read();
            Assert.Equal("rect",reader.Name);

            Assert.Equal("352", reader.GetAttribute("x"));
            Assert.Equal("33", reader.GetAttribute("y"));

            reader.Read();
            Assert.Equal("text", reader.Name);
            Assert.Equal("360",reader.GetAttribute("x"));
            Assert.Equal("57",reader.GetAttribute("y"));

            reader.Read();
            Assert.Equal("B", reader.Value);

            reader.ReadToFollowing("line");
            Assert.Equal("82", reader.GetAttribute("x1"));
            Assert.Equal("53", reader.GetAttribute("y1"));

            Assert.Equal("347", reader.GetAttribute("x2"));
            Assert.Equal("53", reader.GetAttribute("y2"));
        }

        [Fact]
        public void TextBoxResizesIfTextTooLong()
        {
            MemoryStream stream = new MemoryStream();

            var flowchart = new Flowchart(stream);

            flowchart.AddPair( "Lorem ipsum dolor sit amet, consectetur",  "B");

            flowchart.Draw();

            XmlReader reader = XmlReader.Create(stream);

            reader.ReadStartElement("svg");
            Assert.Equal("rect", reader.Name);

            Assert.Equal("52", reader.GetAttribute("x"));
            Assert.Equal("33", reader.GetAttribute("y"));

            reader.Read();
            Assert.Equal("text", reader.Name);
            reader.Read();
            Assert.Equal("Lorem ipsum dolor sit", reader.Value);

            reader.Read();
            Assert.Equal("tspan", reader.Name);
            Assert.Equal("60", reader.GetAttribute("x"));
            Assert.Equal("74", reader.GetAttribute("y"));

            reader.Read();
            Assert.Equal("amet, consectetur", reader.Value);

            reader.Read();
            reader.Read();

            Assert.Equal("text", reader.Name);

            reader.Read();
            Assert.Equal("rect", reader.Name);

            Assert.Equal("352", reader.GetAttribute("x"));
            Assert.Equal("33", reader.GetAttribute("y"));

            reader.Read();
            Assert.Equal("text", reader.Name);
            Assert.Equal("360", reader.GetAttribute("x"));
            Assert.Equal("57", reader.GetAttribute("y"));

            reader.Read();
            Assert.Equal("B", reader.Value);

            reader.ReadToFollowing("line");
            Assert.Equal("252", reader.GetAttribute("x1"));
            Assert.Equal("53", reader.GetAttribute("y1"));

            Assert.Equal("347", reader.GetAttribute("x2"));
            Assert.Equal("53", reader.GetAttribute("y2"));
        }
    }
}
