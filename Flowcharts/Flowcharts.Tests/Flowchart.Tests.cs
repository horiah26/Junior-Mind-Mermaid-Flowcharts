using System.IO;
using System.Xml;
using Xunit;

namespace Flowcharts.Tests
{
    public class FlowchartTests
    {
        string arrow = "Arrow";
        string rectangle = "Rectangle";

        //GridSpacing 150 200 150, 150 200 200

        [Fact]
        public void CanAddAPair()
        {
            var stream = new MemoryStream();
            Writer.CreateWriter(stream);

            var flowchart = new Flowchart("LeftRight", stream);
            flowchart.AddPair(("A", "A", rectangle), ("B", "B", "Rectangle"), arrow);
            flowchart.DrawFlowchart();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var polygons = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='polygon']");

            Assert.Equal("265,153 265,113 235,113 235,153", polygons[0].Attributes[0].Value);

            Assert.Equal("465,153 465,113 435,113 435,153", polygons[1].Attributes[0].Value);
          
            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");

            Assert.Equal("245", texts[0].Attributes[0].Value);
            Assert.Equal("137", texts[0].Attributes[1].Value);
            Assert.Equal("A", texts[0].InnerText);

            Assert.Equal("445", texts[1].Attributes[0].Value);
            Assert.Equal("137", texts[1].Attributes[1].Value);
            Assert.Equal("B", texts[1].InnerText);

            var lines = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='line']");
            Assert.Equal("265", lines[0].Attributes[0].Value);
            Assert.Equal("133", lines[0].Attributes[1].Value);
            Assert.Equal("430", lines[0].Attributes[2].Value);
            Assert.Equal("133", lines[0].Attributes[3].Value);
        }

        [Fact]
        public void TextBoxResizesIfTextTooLong()
        {
            var stream = new MemoryStream();
            Writer.CreateWriter(stream);

            var flowchart = new Flowchart("LeftRight", stream);

            flowchart.AddPair(("A", "Lorem ipsum dolor sit amet, consectetur", rectangle), ("B", "B", rectangle), arrow);

            flowchart.DrawFlowchart();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var elements = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='polygon']");

            Assert.Equal("331.25,170 331.25,96 168.75,96 168.75,170", elements[0].Attributes[0].Value);

            Assert.Equal("465,153 465,113 435,113 435,153", elements[1].Attributes[0].Value);

            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");

            Assert.Equal("178.75", texts[0].Attributes[0].Value);
            Assert.Equal("120", texts[0].Attributes[1].Value);
            Assert.Equal("Lorem ipsum dolorsit amet,consectetur", texts[0].InnerText);

            Assert.Equal("445", texts[1].Attributes[0].Value);
            Assert.Equal("137", texts[1].Attributes[1].Value);
            Assert.Equal("B", texts[1].InnerText);

            var lines = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='line']");
            Assert.Equal("331.25", lines[0].Attributes[0].Value);
            Assert.Equal("133", lines[0].Attributes[1].Value);
            Assert.Equal("430", lines[0].Attributes[2].Value);
            Assert.Equal("133", lines[0].Attributes[3].Value);
        }

        [Fact]
        public void CanAddMultiple()
        {
            var stream = new MemoryStream();
            Writer.CreateWriter(stream);

            var flowchart = new Flowchart("LeftRight", stream);

            flowchart.AddPair(("A", "A", rectangle), ("B", "B", "Rectangle"), arrow);
            flowchart.AddPair(("A", "A", rectangle), ("C", "C", "Rectangle"), arrow);
            flowchart.DrawFlowchart();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var elements = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='polygon']");
            Assert.Equal("465,153 465,113 435,113 435,153", elements[0].Attributes[0].Value);
            Assert.Equal("265,303 265,263 235,263 235,303", elements[1].Attributes[0].Value);
            Assert.Equal("465,453 465,413 435,413 435,453", elements[2].Attributes[0].Value);


            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");
            Assert.Equal("445", texts[0].Attributes[0].Value);
            Assert.Equal("137", texts[0].Attributes[1].Value);
            Assert.Equal("B", texts[0].InnerText);

            Assert.Equal("245", texts[1].Attributes[0].Value);
            Assert.Equal("287", texts[1].Attributes[1].Value);
            Assert.Equal("A", texts[1].InnerText);

            Assert.Equal("445", texts[2].Attributes[0].Value);
            Assert.Equal("437", texts[2].Attributes[1].Value);
            Assert.Equal("C", texts[2].InnerText);

            var lines = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='line']");
            Assert.Equal("265", lines[0].Attributes[0].Value);
            Assert.Equal("283", lines[0].Attributes[1].Value);
            Assert.Equal("430", lines[0].Attributes[2].Value);
            Assert.Equal("133", lines[0].Attributes[3].Value);

            Assert.Equal("265", lines[1].Attributes[0].Value);
            Assert.Equal("283", lines[1].Attributes[1].Value);
            Assert.Equal("430", lines[1].Attributes[2].Value);
            Assert.Equal("433", lines[1].Attributes[3].Value);
        }

        [Fact]
        public void ParentRepositionsIfHas3Children()
        {
            MemoryStream stream = new MemoryStream();

            var flowchart = new Flowchart("LeftRight", stream);


            flowchart.AddPair(("A", "A", rectangle), ("B", "B", rectangle), arrow);
            flowchart.AddPair(("A", "A", rectangle), ("C", "C", rectangle), arrow);
            flowchart.AddPair(("A", "A", rectangle), ("D", "D", rectangle), arrow);

            flowchart.DrawFlowchart();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var elements = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='polygon']");
            Assert.Equal("465,153 465,113 435,113 435,153", elements[0].Attributes[0].Value);
            Assert.Equal("265,303 265,263 235,263 235,303", elements[1].Attributes[0].Value);
            Assert.Equal("465,303 465,263 435,263 435,303", elements[2].Attributes[0].Value);
            Assert.Equal("465,453 465,413 435,413 435,453", elements[3].Attributes[0].Value);

            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");
            Assert.Equal("445", texts[0].Attributes[0].Value);
            Assert.Equal("137", texts[0].Attributes[1].Value);
            Assert.Equal("B", texts[0].InnerText);

            Assert.Equal("245", texts[1].Attributes[0].Value);
            Assert.Equal("287", texts[1].Attributes[1].Value);
            Assert.Equal("A", texts[1].InnerText);

            Assert.Equal("445", texts[2].Attributes[0].Value);
            Assert.Equal("287", texts[2].Attributes[1].Value);
            Assert.Equal("C", texts[2].InnerText);

            Assert.Equal("445", texts[3].Attributes[0].Value);
            Assert.Equal("437", texts[3].Attributes[1].Value);
            Assert.Equal("D", texts[3].InnerText);

            var lines = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='line']");
            Assert.Equal("265", lines[0].Attributes[0].Value);
            Assert.Equal("283", lines[0].Attributes[1].Value);
            Assert.Equal("430", lines[0].Attributes[2].Value);
            Assert.Equal("133", lines[0].Attributes[3].Value);

            Assert.Equal("265", lines[1].Attributes[0].Value);
            Assert.Equal("283", lines[1].Attributes[1].Value);
            Assert.Equal("430", lines[1].Attributes[2].Value);
            Assert.Equal("283", lines[1].Attributes[3].Value);

            Assert.Equal("265", lines[2].Attributes[0].Value);
            Assert.Equal("283", lines[2].Attributes[1].Value);
            Assert.Equal("430", lines[2].Attributes[2].Value);
            Assert.Equal("433", lines[2].Attributes[3].Value);
        }

        [Fact]
        public void LastItemsInColumnAlignToTheirParents()
        {
            MemoryStream stream = new MemoryStream();

            var flowchart = new Flowchart("LeftRight", stream);
            flowchart.AddPair(("A", "A", rectangle), ("B", "B", rectangle), arrow);
            flowchart.AddPair(("A", "A", rectangle), ("C", "C", rectangle), arrow);
            flowchart.AddPair(("A", "A", rectangle), ("D", "D", rectangle), arrow);
            flowchart.AddPair("D", ("E", "E", rectangle), arrow);

            flowchart.DrawFlowchart();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var elements = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='polygon']");
            Assert.Equal("465,153 465,113 435,113 435,153", elements[0].Attributes[0].Value);
            Assert.Equal("265,303 265,263 235,263 235,303", elements[1].Attributes[0].Value);
            Assert.Equal("465,303 465,263 435,263 435,303", elements[2].Attributes[0].Value);
            Assert.Equal("465,453 465,413 435,413 435,453", elements[3].Attributes[0].Value);
            Assert.Equal("665,453 665,413 635,413 635,453", elements[4].Attributes[0].Value);

            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");
            Assert.Equal("445", texts[0].Attributes[0].Value);
            Assert.Equal("137", texts[0].Attributes[1].Value);
            Assert.Equal("B", texts[0].InnerText);

            Assert.Equal("245", texts[1].Attributes[0].Value);
            Assert.Equal("287", texts[1].Attributes[1].Value);
            Assert.Equal("A", texts[1].InnerText);

            Assert.Equal("445", texts[2].Attributes[0].Value);
            Assert.Equal("287", texts[2].Attributes[1].Value);
            Assert.Equal("C", texts[2].InnerText);

            Assert.Equal("445", texts[3].Attributes[0].Value);
            Assert.Equal("437", texts[3].Attributes[1].Value);
            Assert.Equal("D", texts[3].InnerText);

            Assert.Equal("645", texts[4].Attributes[0].Value);
            Assert.Equal("437", texts[4].Attributes[1].Value);
            Assert.Equal("E", texts[4].InnerText);

            var lines = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='line']");
            Assert.Equal("265", lines[0].Attributes[0].Value);
            Assert.Equal("283", lines[0].Attributes[1].Value);
            Assert.Equal("430", lines[0].Attributes[2].Value);
            Assert.Equal("133", lines[0].Attributes[3].Value);

            Assert.Equal("265", lines[1].Attributes[0].Value);
            Assert.Equal("283", lines[1].Attributes[1].Value);
            Assert.Equal("430", lines[1].Attributes[2].Value);
            Assert.Equal("283", lines[1].Attributes[3].Value);

            Assert.Equal("265", lines[2].Attributes[0].Value);
            Assert.Equal("283", lines[2].Attributes[1].Value);
            Assert.Equal("430", lines[2].Attributes[2].Value);
            Assert.Equal("433", lines[2].Attributes[3].Value);

            Assert.Equal("465", lines[3].Attributes[0].Value);
            Assert.Equal("433", lines[3].Attributes[1].Value);
            Assert.Equal("630", lines[3].Attributes[2].Value);
            Assert.Equal("433", lines[3].Attributes[3].Value);
        }


        [Fact]
        public void OrientationRightLeftWorks()
        {
            MemoryStream MemoryStream = new MemoryStream();

            var flowchart = new Flowchart("RightLeft", MemoryStream);

            flowchart.AddPair(("A", "A", rectangle), ("B", "B", rectangle), arrow);
            flowchart.AddPair(("A", "A", rectangle), ("C", "C", rectangle), arrow);
            flowchart.AddPair(("A", "A", rectangle), ("D", "D", rectangle), arrow);

            flowchart.DrawFlowchart();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(MemoryStream);

            var elements = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='polygon']");

            Assert.Equal("265,153 265,113 235,113 235,153", elements[0].Attributes[0].Value);
            Assert.Equal("465,303 465,263 435,263 435,303", elements[1].Attributes[0].Value);
            Assert.Equal("265,303 265,263 235,263 235,303", elements[2].Attributes[0].Value);
            Assert.Equal("265,453 265,413 235,413 235,453", elements[3].Attributes[0].Value);

            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");
            Assert.Equal("245", texts[0].Attributes[0].Value);
            Assert.Equal("137", texts[0].Attributes[1].Value);
            Assert.Equal("B", texts[0].InnerText);

            Assert.Equal("445", texts[1].Attributes[0].Value);
            Assert.Equal("287", texts[1].Attributes[1].Value);
            Assert.Equal("A", texts[1].InnerText);

            Assert.Equal("245", texts[2].Attributes[0].Value);
            Assert.Equal("287", texts[2].Attributes[1].Value);
            Assert.Equal("C", texts[2].InnerText);

            Assert.Equal("245", texts[3].Attributes[0].Value);
            Assert.Equal("437", texts[3].Attributes[1].Value);
            Assert.Equal("D", texts[3].InnerText);

            var lines = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='line']");
            Assert.Equal("435", lines[0].Attributes[0].Value);
            Assert.Equal("283", lines[0].Attributes[1].Value);
            Assert.Equal("270", lines[0].Attributes[2].Value);
            Assert.Equal("133", lines[0].Attributes[3].Value);

            Assert.Equal("435", lines[1].Attributes[0].Value);
            Assert.Equal("283", lines[1].Attributes[1].Value);
            Assert.Equal("270", lines[1].Attributes[2].Value);
            Assert.Equal("283", lines[1].Attributes[3].Value);

            Assert.Equal("435", lines[2].Attributes[0].Value);
            Assert.Equal("283", lines[2].Attributes[1].Value);
            Assert.Equal("270", lines[2].Attributes[2].Value);
            Assert.Equal("433", lines[2].Attributes[3].Value);
        }

        [Fact]
        public void OrientationTopDownWorks()
        {
            MemoryStream stream = new MemoryStream();

            var flowchart = new Flowchart("TopDown", stream);

            flowchart.AddPair(("A", "A", rectangle), ("B", "B", rectangle), arrow);
            flowchart.AddPair(("B", "B", rectangle), ("C", "C", rectangle), arrow);
            flowchart.AddPair(("C", "C", rectangle), ("D", "D", rectangle), arrow);

            flowchart.DrawFlowchart();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var elements = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='polygon']");

            Assert.Equal("265,153 265,113 235,113 235,153", elements[0].Attributes[0].Value);
            Assert.Equal("265,353 265,313 235,313 235,353", elements[1].Attributes[0].Value);
            Assert.Equal("265,553 265,513 235,513 235,553", elements[2].Attributes[0].Value);
            Assert.Equal("265,753 265,713 235,713 235,753", elements[3].Attributes[0].Value);

            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");
            Assert.Equal("245", texts[0].Attributes[0].Value);
            Assert.Equal("137", texts[0].Attributes[1].Value);
            Assert.Equal("A", texts[0].InnerText);

            Assert.Equal("245", texts[1].Attributes[0].Value);
            Assert.Equal("337", texts[1].Attributes[1].Value);
            Assert.Equal("B", texts[1].InnerText);

            Assert.Equal("245", texts[2].Attributes[0].Value);
            Assert.Equal("537", texts[2].Attributes[1].Value);
            Assert.Equal("C", texts[2].InnerText);

            Assert.Equal("245", texts[3].Attributes[0].Value);
            Assert.Equal("737", texts[3].Attributes[1].Value);
            Assert.Equal("D", texts[3].InnerText);

            var lines = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='line']");
            Assert.Equal("250", lines[0].Attributes[0].Value);
            Assert.Equal("153", lines[0].Attributes[1].Value);
            Assert.Equal("250", lines[0].Attributes[2].Value);
            Assert.Equal("309", lines[0].Attributes[3].Value);

            Assert.Equal("250", lines[1].Attributes[0].Value);
            Assert.Equal("353", lines[1].Attributes[1].Value);
            Assert.Equal("250", lines[1].Attributes[2].Value);
            Assert.Equal("509", lines[1].Attributes[3].Value);

            Assert.Equal("250", lines[2].Attributes[0].Value);
            Assert.Equal("553", lines[2].Attributes[1].Value);
            Assert.Equal("250", lines[2].Attributes[2].Value);
            Assert.Equal("709", lines[2].Attributes[3].Value);
        }

        [Fact]
        public void OrientationDownTopWorks()
        {
            MemoryStream stream = new MemoryStream();

            var flowchart = new Flowchart("DownTop", stream);

            flowchart.AddPair(("A", "A", rectangle), ("B", "B", rectangle), arrow);
            flowchart.AddPair(("B", "B", rectangle), ("C", "C", rectangle), arrow);
            flowchart.AddPair(("B", "B", rectangle), ("D", "D", rectangle), arrow);

            flowchart.DrawFlowchart();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var elements = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='polygon']");
            Assert.Equal("265,153 265,113 235,113 235,153", elements[0].Attributes[0].Value);
            Assert.Equal("465,553 465,513 435,513 435,553", elements[1].Attributes[0].Value);
            Assert.Equal("465,353 465,313 435,313 435,353", elements[2].Attributes[0].Value);
            Assert.Equal("665,153 665,113 635,113 635,153", elements[3].Attributes[0].Value);

            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");
            Assert.Equal("245", texts[0].Attributes[0].Value);
            Assert.Equal("137", texts[0].Attributes[1].Value);
            Assert.Equal("C", texts[0].InnerText);

            Assert.Equal("445", texts[1].Attributes[0].Value);
            Assert.Equal("537", texts[1].Attributes[1].Value);
            Assert.Equal("A", texts[1].InnerText);

            Assert.Equal("445", texts[2].Attributes[0].Value);
            Assert.Equal("337", texts[2].Attributes[1].Value);
            Assert.Equal("B", texts[2].InnerText);

            Assert.Equal("645", texts[3].Attributes[0].Value);
            Assert.Equal("137", texts[3].Attributes[1].Value);
            Assert.Equal("D", texts[3].InnerText);

            var lines = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='line']");
            Assert.Equal("450", lines[0].Attributes[0].Value);
            Assert.Equal("513", lines[0].Attributes[1].Value);
            Assert.Equal("450", lines[0].Attributes[2].Value);
            Assert.Equal("357", lines[0].Attributes[3].Value);

            Assert.Equal("450", lines[1].Attributes[0].Value);
            Assert.Equal("313", lines[1].Attributes[1].Value);
            Assert.Equal("250", lines[1].Attributes[2].Value);
            Assert.Equal("157", lines[1].Attributes[3].Value);

            Assert.Equal("450", lines[2].Attributes[0].Value);
            Assert.Equal("313", lines[2].Attributes[1].Value);
            Assert.Equal("650", lines[2].Attributes[2].Value);
            Assert.Equal("157", lines[2].Attributes[3].Value);
        }
    } 
}
