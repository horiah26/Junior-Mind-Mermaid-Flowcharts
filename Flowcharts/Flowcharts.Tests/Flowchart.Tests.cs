using System.IO;
using System.Xml;
using Xunit;

namespace Flowcharts.Tests
{
    public class FlowchartTests
    {
        [Fact]
        public void CanAddAPair()
        {
            MemoryStream stream = new MemoryStream();

            var flowchart = new Flowchart(stream);
            flowchart.AddPair("A", "B");
            flowchart.Draw();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var rectangles = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='rect']");

            Assert.Equal("185", rectangles[0].Attributes[0].Value);
            Assert.Equal("33", rectangles[0].Attributes[1].Value);
            Assert.Equal("30", rectangles[0].Attributes[4].Value);
            Assert.Equal("40", rectangles[0].Attributes[5].Value);

            Assert.Equal("485", rectangles[1].Attributes[0].Value);
            Assert.Equal("33", rectangles[1].Attributes[1].Value);
            Assert.Equal("30", rectangles[1].Attributes[4].Value);
            Assert.Equal("40", rectangles[1].Attributes[5].Value);

            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");

            Assert.Equal("195", texts[0].Attributes[0].Value);
            Assert.Equal("57", texts[0].Attributes[1].Value);
            Assert.Equal("A", texts[0].InnerText);

            Assert.Equal("495", texts[1].Attributes[0].Value);
            Assert.Equal("57", texts[1].Attributes[1].Value);
            Assert.Equal("B", texts[1].InnerText);

            var lines = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='line']");
            Assert.Equal("215", lines[0].Attributes[0].Value);
            Assert.Equal("53", lines[0].Attributes[1].Value);
            Assert.Equal("480", lines[0].Attributes[2].Value);
            Assert.Equal("53", lines[0].Attributes[3].Value);
        }

        [Fact]
        public void TextBoxResizesIfTextTooLong()
        {
            MemoryStream stream = new MemoryStream();

            var flowchart = new Flowchart(stream);

            flowchart.AddPair("Lorem ipsum dolor sit amet, consectetur", "B");

            flowchart.Draw();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var rectangles = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='rect']");

            Assert.Equal("100", rectangles[0].Attributes[0].Value);
            Assert.Equal("33", rectangles[0].Attributes[1].Value);
            Assert.Equal("200", rectangles[0].Attributes[4].Value);
            Assert.Equal("57", rectangles[0].Attributes[5].Value);

            Assert.Equal("485", rectangles[1].Attributes[0].Value);
            Assert.Equal("33", rectangles[1].Attributes[1].Value);
            Assert.Equal("30", rectangles[1].Attributes[4].Value);
            Assert.Equal("40", rectangles[1].Attributes[5].Value);

            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");

            Assert.Equal("110", texts[0].Attributes[0].Value);
            Assert.Equal("57", texts[0].Attributes[1].Value);
            Assert.Equal("Lorem ipsum dolor sitamet, consectetur", texts[0].InnerText);

            Assert.Equal("495", texts[1].Attributes[0].Value);
            Assert.Equal("57", texts[1].Attributes[1].Value);
            Assert.Equal("B", texts[1].InnerText);

            var lines = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='line']");
            Assert.Equal("300", lines[0].Attributes[0].Value);
            Assert.Equal("53", lines[0].Attributes[1].Value);
            Assert.Equal("480", lines[0].Attributes[2].Value);
            Assert.Equal("53", lines[0].Attributes[3].Value);
        }

        [Fact]
        public void CanAddMultiple()
        {
            MemoryStream stream = new MemoryStream();

            var flowchart = new Flowchart(stream);
            flowchart.AddPair("A", "B");
            flowchart.AddPair("A", "C");
            flowchart.Draw();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var rectangles = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='rect']");
            Assert.Equal("185", rectangles[0].Attributes[0].Value);
            Assert.Equal("33", rectangles[0].Attributes[1].Value);
            Assert.Equal("30", rectangles[0].Attributes[4].Value);
            Assert.Equal("40", rectangles[0].Attributes[5].Value);

            Assert.Equal("485", rectangles[1].Attributes[0].Value);
            Assert.Equal("33", rectangles[1].Attributes[1].Value);
            Assert.Equal("30", rectangles[1].Attributes[4].Value);
            Assert.Equal("40", rectangles[1].Attributes[5].Value);

            Assert.Equal("485", rectangles[2].Attributes[0].Value);
            Assert.Equal("183", rectangles[2].Attributes[1].Value);
            Assert.Equal("30", rectangles[2].Attributes[4].Value);
            Assert.Equal("40", rectangles[2].Attributes[5].Value);

            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");
            Assert.Equal("195", texts[0].Attributes[0].Value);
            Assert.Equal("57", texts[0].Attributes[1].Value);
            Assert.Equal("A", texts[0].InnerText);

            Assert.Equal("495", texts[1].Attributes[0].Value);
            Assert.Equal("57", texts[1].Attributes[1].Value);
            Assert.Equal("B", texts[1].InnerText);

            Assert.Equal("495", texts[2].Attributes[0].Value);
            Assert.Equal("207", texts[2].Attributes[1].Value);
            Assert.Equal("C", texts[2].InnerText);

            var lines = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='line']");
            Assert.Equal("215", lines[0].Attributes[0].Value);
            Assert.Equal("53", lines[0].Attributes[1].Value);
            Assert.Equal("480", lines[0].Attributes[2].Value);
            Assert.Equal("53", lines[0].Attributes[3].Value);

            Assert.Equal("215", lines[1].Attributes[0].Value);
            Assert.Equal("53", lines[1].Attributes[1].Value);
            Assert.Equal("480", lines[1].Attributes[2].Value);
            Assert.Equal("203", lines[1].Attributes[3].Value);
        }

        [Fact]
        public void ParentRepositionsIfHas3Children()
        {
            MemoryStream stream = new MemoryStream();

            var flowchart = new Flowchart(stream);
            flowchart.AddPair("A", "B");
            flowchart.AddPair("A", "C");
            flowchart.AddPair("A", "D");
            flowchart.Draw();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var rectangles = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='rect']");
            Assert.Equal("185", rectangles[0].Attributes[0].Value);
            Assert.Equal("183", rectangles[0].Attributes[1].Value);
            Assert.Equal("30", rectangles[0].Attributes[4].Value);
            Assert.Equal("40", rectangles[0].Attributes[5].Value);

            Assert.Equal("485", rectangles[1].Attributes[0].Value);
            Assert.Equal("33", rectangles[1].Attributes[1].Value);
            Assert.Equal("30", rectangles[1].Attributes[4].Value);
            Assert.Equal("40", rectangles[1].Attributes[5].Value);

            Assert.Equal("485", rectangles[2].Attributes[0].Value);
            Assert.Equal("183", rectangles[2].Attributes[1].Value);
            Assert.Equal("30", rectangles[2].Attributes[4].Value);
            Assert.Equal("40", rectangles[2].Attributes[5].Value);

            Assert.Equal("485", rectangles[3].Attributes[0].Value);
            Assert.Equal("333", rectangles[3].Attributes[1].Value);
            Assert.Equal("30", rectangles[3].Attributes[4].Value);
            Assert.Equal("40", rectangles[3].Attributes[5].Value);

            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");
            Assert.Equal("195", texts[0].Attributes[0].Value);
            Assert.Equal("207", texts[0].Attributes[1].Value);
            Assert.Equal("A", texts[0].InnerText);

            Assert.Equal("495", texts[1].Attributes[0].Value);
            Assert.Equal("57", texts[1].Attributes[1].Value);
            Assert.Equal("B", texts[1].InnerText);

            Assert.Equal("495", texts[2].Attributes[0].Value);
            Assert.Equal("207", texts[2].Attributes[1].Value);
            Assert.Equal("C", texts[2].InnerText);

            Assert.Equal("495", texts[3].Attributes[0].Value);
            Assert.Equal("357", texts[3].Attributes[1].Value);
            Assert.Equal("D", texts[3].InnerText);

            var lines = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='line']");
            Assert.Equal("215", lines[0].Attributes[0].Value);
            Assert.Equal("203", lines[0].Attributes[1].Value);
            Assert.Equal("480", lines[0].Attributes[2].Value);
            Assert.Equal("53", lines[0].Attributes[3].Value);

            Assert.Equal("215", lines[1].Attributes[0].Value);
            Assert.Equal("203", lines[1].Attributes[1].Value);
            Assert.Equal("480", lines[1].Attributes[2].Value);
            Assert.Equal("203", lines[1].Attributes[3].Value);

            Assert.Equal("215", lines[2].Attributes[0].Value);
            Assert.Equal("203", lines[2].Attributes[1].Value);
            Assert.Equal("480", lines[2].Attributes[2].Value);
            Assert.Equal("353", lines[2].Attributes[3].Value);
        }

        [Fact]
        public void LastItemsInColumnAlignToTheirParents()
        {
            MemoryStream stream = new MemoryStream();

            var flowchart = new Flowchart(stream);
            flowchart.AddPair("A", "B");
            flowchart.AddPair("A", "C");
            flowchart.AddPair("A", "D");
            flowchart.AddPair("D", "E");
            flowchart.Draw();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var rectangles = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='rect']");
            Assert.Equal("185", rectangles[0].Attributes[0].Value);
            Assert.Equal("183", rectangles[0].Attributes[1].Value);
            Assert.Equal("30", rectangles[0].Attributes[4].Value);
            Assert.Equal("40", rectangles[0].Attributes[5].Value);

            Assert.Equal("485", rectangles[1].Attributes[0].Value);
            Assert.Equal("33", rectangles[1].Attributes[1].Value);
            Assert.Equal("30", rectangles[1].Attributes[4].Value);
            Assert.Equal("40", rectangles[1].Attributes[5].Value);

            Assert.Equal("485", rectangles[2].Attributes[0].Value);
            Assert.Equal("183", rectangles[2].Attributes[1].Value);
            Assert.Equal("30", rectangles[2].Attributes[4].Value);
            Assert.Equal("40", rectangles[2].Attributes[5].Value);

            Assert.Equal("485", rectangles[3].Attributes[0].Value);
            Assert.Equal("333", rectangles[3].Attributes[1].Value);
            Assert.Equal("30", rectangles[3].Attributes[4].Value);
            Assert.Equal("40", rectangles[3].Attributes[5].Value);

            Assert.Equal("785", rectangles[4].Attributes[0].Value);
            Assert.Equal("33", rectangles[4].Attributes[1].Value);
            Assert.Equal("30", rectangles[4].Attributes[4].Value);
            Assert.Equal("40", rectangles[4].Attributes[5].Value);

            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");
            Assert.Equal("195", texts[0].Attributes[0].Value);
            Assert.Equal("207", texts[0].Attributes[1].Value);
            Assert.Equal("A", texts[0].InnerText);

            Assert.Equal("495", texts[1].Attributes[0].Value);
            Assert.Equal("57", texts[1].Attributes[1].Value);
            Assert.Equal("B", texts[1].InnerText);

            Assert.Equal("495", texts[2].Attributes[0].Value);
            Assert.Equal("207", texts[2].Attributes[1].Value);
            Assert.Equal("C", texts[2].InnerText);

            Assert.Equal("495", texts[3].Attributes[0].Value);
            Assert.Equal("357", texts[3].Attributes[1].Value);
            Assert.Equal("D", texts[3].InnerText);

            Assert.Equal("795", texts[4].Attributes[0].Value);
            Assert.Equal("57", texts[4].Attributes[1].Value);
            Assert.Equal("E", texts[4].InnerText);

            var lines = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='line']");
            Assert.Equal("215", lines[0].Attributes[0].Value);
            Assert.Equal("203", lines[0].Attributes[1].Value);
            Assert.Equal("480", lines[0].Attributes[2].Value);
            Assert.Equal("53", lines[0].Attributes[3].Value);

            Assert.Equal("215", lines[1].Attributes[0].Value);
            Assert.Equal("203", lines[1].Attributes[1].Value);
            Assert.Equal("480", lines[1].Attributes[2].Value);
            Assert.Equal("203", lines[1].Attributes[3].Value);

            Assert.Equal("215", lines[2].Attributes[0].Value);
            Assert.Equal("203", lines[2].Attributes[1].Value);
            Assert.Equal("480", lines[2].Attributes[2].Value);
            Assert.Equal("353", lines[2].Attributes[3].Value);

            Assert.Equal("515", lines[3].Attributes[0].Value);
            Assert.Equal("353", lines[3].Attributes[1].Value);
            Assert.Equal("780", lines[3].Attributes[2].Value);
            Assert.Equal("53", lines[3].Attributes[3].Value);
        }

        [Fact]
        public void OrientationLRWorks()
        {
            MemoryStream stream = new MemoryStream();

            var flowchart = new Flowchart(stream);
            flowchart.Orientation("LR");

            flowchart.AddPair("A", "B");
            flowchart.AddPair("B", "C");
            flowchart.AddPair("B", "D");
            flowchart.Draw();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var rectangles = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='rect']");
            Assert.Equal("185", rectangles[0].Attributes[0].Value);
            Assert.Equal("33", rectangles[0].Attributes[1].Value);
            Assert.Equal("30", rectangles[0].Attributes[4].Value);
            Assert.Equal("40", rectangles[0].Attributes[5].Value);

            Assert.Equal("485", rectangles[1].Attributes[0].Value);
            Assert.Equal("33", rectangles[1].Attributes[1].Value);
            Assert.Equal("30", rectangles[1].Attributes[4].Value);
            Assert.Equal("40", rectangles[1].Attributes[5].Value);

            Assert.Equal("785", rectangles[2].Attributes[0].Value);
            Assert.Equal("33", rectangles[2].Attributes[1].Value);
            Assert.Equal("30", rectangles[2].Attributes[4].Value);
            Assert.Equal("40", rectangles[2].Attributes[5].Value);

            Assert.Equal("785", rectangles[3].Attributes[0].Value);
            Assert.Equal("183", rectangles[3].Attributes[1].Value);
            Assert.Equal("30", rectangles[3].Attributes[4].Value);
            Assert.Equal("40", rectangles[3].Attributes[5].Value);

            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");
            Assert.Equal("195", texts[0].Attributes[0].Value);
            Assert.Equal("57", texts[0].Attributes[1].Value);
            Assert.Equal("A", texts[0].InnerText);

            Assert.Equal("495", texts[1].Attributes[0].Value);
            Assert.Equal("57", texts[1].Attributes[1].Value);
            Assert.Equal("B", texts[1].InnerText);

            Assert.Equal("795", texts[2].Attributes[0].Value);
            Assert.Equal("57", texts[2].Attributes[1].Value);
            Assert.Equal("C", texts[2].InnerText);

            Assert.Equal("795", texts[3].Attributes[0].Value);
            Assert.Equal("207", texts[3].Attributes[1].Value);
            Assert.Equal("D", texts[3].InnerText);

            var lines = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='line']");
            Assert.Equal("215", lines[0].Attributes[0].Value);
            Assert.Equal("53", lines[0].Attributes[1].Value);
            Assert.Equal("480", lines[0].Attributes[2].Value);
            Assert.Equal("53", lines[0].Attributes[3].Value);

            Assert.Equal("515", lines[1].Attributes[0].Value);
            Assert.Equal("53", lines[1].Attributes[1].Value);
            Assert.Equal("780", lines[1].Attributes[2].Value);
            Assert.Equal("53", lines[1].Attributes[3].Value);

            Assert.Equal("515", lines[2].Attributes[0].Value);
            Assert.Equal("53", lines[2].Attributes[1].Value);
            Assert.Equal("780", lines[2].Attributes[2].Value);
            Assert.Equal("203", lines[2].Attributes[3].Value);
        }

        [Fact]
        public void OrientationRLWorks()
        {
            MemoryStream stream = new MemoryStream();

            var flowchart = new Flowchart(stream);
            flowchart.Orientation("RL");

            flowchart.AddPair("A", "B");
            flowchart.AddPair("B", "C");
            flowchart.AddPair("B", "D");
            flowchart.Draw();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var rectangles = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='rect']");
            Assert.Equal("785", rectangles[0].Attributes[0].Value);
            Assert.Equal("33", rectangles[0].Attributes[1].Value);
            Assert.Equal("30", rectangles[0].Attributes[4].Value);
            Assert.Equal("40", rectangles[0].Attributes[5].Value);

            Assert.Equal("485", rectangles[1].Attributes[0].Value);
            Assert.Equal("33", rectangles[1].Attributes[1].Value);
            Assert.Equal("30", rectangles[1].Attributes[4].Value);
            Assert.Equal("40", rectangles[1].Attributes[5].Value);

            Assert.Equal("185", rectangles[2].Attributes[0].Value);
            Assert.Equal("33", rectangles[2].Attributes[1].Value);
            Assert.Equal("30", rectangles[2].Attributes[4].Value);
            Assert.Equal("40", rectangles[2].Attributes[5].Value);

            Assert.Equal("185", rectangles[3].Attributes[0].Value);
            Assert.Equal("183", rectangles[3].Attributes[1].Value);
            Assert.Equal("30", rectangles[3].Attributes[4].Value);
            Assert.Equal("40", rectangles[3].Attributes[5].Value);

            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");
            Assert.Equal("795", texts[0].Attributes[0].Value);
            Assert.Equal("57", texts[0].Attributes[1].Value);
            Assert.Equal("A", texts[0].InnerText);

            Assert.Equal("495", texts[1].Attributes[0].Value);
            Assert.Equal("57", texts[1].Attributes[1].Value);
            Assert.Equal("B", texts[1].InnerText);

            Assert.Equal("195", texts[2].Attributes[0].Value);
            Assert.Equal("57", texts[2].Attributes[1].Value);
            Assert.Equal("C", texts[2].InnerText);

            Assert.Equal("195", texts[3].Attributes[0].Value);
            Assert.Equal("207", texts[3].Attributes[1].Value);
            Assert.Equal("D", texts[3].InnerText);

            var lines = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='line']");
            Assert.Equal("780", lines[0].Attributes[0].Value);
            Assert.Equal("53", lines[0].Attributes[1].Value);
            Assert.Equal("515", lines[0].Attributes[2].Value);
            Assert.Equal("53", lines[0].Attributes[3].Value);

            Assert.Equal("480", lines[1].Attributes[0].Value);
            Assert.Equal("53", lines[1].Attributes[1].Value);
            Assert.Equal("215", lines[1].Attributes[2].Value);
            Assert.Equal("53", lines[1].Attributes[3].Value);

            Assert.Equal("480", lines[2].Attributes[0].Value);
            Assert.Equal("53", lines[2].Attributes[1].Value);
            Assert.Equal("215", lines[2].Attributes[2].Value);
            Assert.Equal("203", lines[2].Attributes[3].Value);
        }

        [Fact]
        public void OrientationTBWorks()
        {
            MemoryStream stream = new MemoryStream();

            var flowchart = new Flowchart(stream);
            flowchart.Orientation("TB");

            flowchart.AddPair("A", "B");
            flowchart.AddPair("B", "C");
            flowchart.AddPair("B", "D");
            flowchart.Draw();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var rectangles = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='rect']");
            Assert.Equal("185", rectangles[0].Attributes[0].Value);
            Assert.Equal("33", rectangles[0].Attributes[1].Value);
            Assert.Equal("30", rectangles[0].Attributes[4].Value);
            Assert.Equal("40", rectangles[0].Attributes[5].Value);

            Assert.Equal("185", rectangles[1].Attributes[0].Value);
            Assert.Equal("183", rectangles[1].Attributes[1].Value);
            Assert.Equal("30", rectangles[1].Attributes[4].Value);
            Assert.Equal("40", rectangles[1].Attributes[5].Value);

            Assert.Equal("185", rectangles[2].Attributes[0].Value);
            Assert.Equal("333", rectangles[2].Attributes[1].Value);
            Assert.Equal("30", rectangles[2].Attributes[4].Value);
            Assert.Equal("40", rectangles[2].Attributes[5].Value);

            Assert.Equal("485", rectangles[3].Attributes[0].Value);
            Assert.Equal("333", rectangles[3].Attributes[1].Value);
            Assert.Equal("30", rectangles[3].Attributes[4].Value);
            Assert.Equal("40", rectangles[3].Attributes[5].Value);

            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");
            Assert.Equal("195", texts[0].Attributes[0].Value);
            Assert.Equal("57", texts[0].Attributes[1].Value);
            Assert.Equal("A", texts[0].InnerText);

            Assert.Equal("195", texts[1].Attributes[0].Value);
            Assert.Equal("207", texts[1].Attributes[1].Value);
            Assert.Equal("B", texts[1].InnerText);

            Assert.Equal("195", texts[2].Attributes[0].Value);
            Assert.Equal("357", texts[2].Attributes[1].Value);
            Assert.Equal("C", texts[2].InnerText);

            Assert.Equal("495", texts[3].Attributes[0].Value);
            Assert.Equal("357", texts[3].Attributes[1].Value);
            Assert.Equal("D", texts[3].InnerText);

            var lines = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='line']");
            Assert.Equal("200", lines[0].Attributes[0].Value);
            Assert.Equal("73", lines[0].Attributes[1].Value);
            Assert.Equal("200", lines[0].Attributes[2].Value);
            Assert.Equal("179", lines[0].Attributes[3].Value);

            Assert.Equal("200", lines[1].Attributes[0].Value);
            Assert.Equal("223", lines[1].Attributes[1].Value);
            Assert.Equal("200", lines[1].Attributes[2].Value);
            Assert.Equal("329", lines[1].Attributes[3].Value);

            Assert.Equal("200", lines[2].Attributes[0].Value);
            Assert.Equal("223", lines[2].Attributes[1].Value);
            Assert.Equal("500", lines[2].Attributes[2].Value);
            Assert.Equal("329", lines[2].Attributes[3].Value);
        }

        [Fact]
        public void OrientationBTWorks()
        {
            MemoryStream stream = new MemoryStream();

            var flowchart = new Flowchart(stream);
            flowchart.Orientation("BT");

            flowchart.AddPair("A", "B");
            flowchart.AddPair("B", "C");
            flowchart.AddPair("B", "D");
            flowchart.Draw();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var rectangles = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='rect']");
            Assert.Equal("185", rectangles[0].Attributes[0].Value);
            Assert.Equal("333", rectangles[0].Attributes[1].Value);
            Assert.Equal("30", rectangles[0].Attributes[4].Value);
            Assert.Equal("40", rectangles[0].Attributes[5].Value);

            Assert.Equal("185", rectangles[1].Attributes[0].Value);
            Assert.Equal("183", rectangles[1].Attributes[1].Value);
            Assert.Equal("30", rectangles[1].Attributes[4].Value);
            Assert.Equal("40", rectangles[1].Attributes[5].Value);

            Assert.Equal("185", rectangles[2].Attributes[0].Value);
            Assert.Equal("33", rectangles[2].Attributes[1].Value);
            Assert.Equal("30", rectangles[2].Attributes[4].Value);
            Assert.Equal("40", rectangles[2].Attributes[5].Value);

            Assert.Equal("485", rectangles[3].Attributes[0].Value);
            Assert.Equal("33", rectangles[3].Attributes[1].Value);
            Assert.Equal("30", rectangles[3].Attributes[4].Value);
            Assert.Equal("40", rectangles[3].Attributes[5].Value);

            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");
            Assert.Equal("195", texts[0].Attributes[0].Value);
            Assert.Equal("357", texts[0].Attributes[1].Value);
            Assert.Equal("A", texts[0].InnerText);

            Assert.Equal("195", texts[1].Attributes[0].Value);
            Assert.Equal("207", texts[1].Attributes[1].Value);
            Assert.Equal("B", texts[1].InnerText);

            Assert.Equal("195", texts[2].Attributes[0].Value);
            Assert.Equal("57", texts[2].Attributes[1].Value);
            Assert.Equal("C", texts[2].InnerText);

            Assert.Equal("495", texts[3].Attributes[0].Value);
            Assert.Equal("57", texts[3].Attributes[1].Value);
            Assert.Equal("D", texts[3].InnerText);

            var lines = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='line']");
            Assert.Equal("200", lines[0].Attributes[0].Value);
            Assert.Equal("329", lines[0].Attributes[1].Value);
            Assert.Equal("200", lines[0].Attributes[2].Value);
            Assert.Equal("223", lines[0].Attributes[3].Value);

            Assert.Equal("200", lines[1].Attributes[0].Value);
            Assert.Equal("179", lines[1].Attributes[1].Value);
            Assert.Equal("200", lines[1].Attributes[2].Value);
            Assert.Equal("73", lines[1].Attributes[3].Value);

            Assert.Equal("200", lines[2].Attributes[0].Value);
            Assert.Equal("179", lines[2].Attributes[1].Value);
            Assert.Equal("500", lines[2].Attributes[2].Value);
            Assert.Equal("73", lines[2].Attributes[3].Value);
        }
    } 
}