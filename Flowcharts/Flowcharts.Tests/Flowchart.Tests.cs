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
        public void TwinsSplit()
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

        [Fact]
        public void SingleChildOfTwinsUnites()
        {
            var stream = new MemoryStream();
            Writer.CreateWriter(stream);

            var flowchart = new Flowchart("LeftRight", stream);

            flowchart.AddPair(("A", "A", rectangle), ("B", "B", "Rectangle"), arrow);
            flowchart.AddPair(("A", "A", rectangle), ("C", "C", "Rectangle"), arrow);
            flowchart.AddPair("B", ("D", "D", "Rectangle"), arrow);
            flowchart.AddPair("C", "D", arrow);
            flowchart.DrawFlowchart();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var elements = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='polygon']");
            Assert.Equal("465,153 465,113 435,113 435,153", elements[0].Attributes[0].Value);
            Assert.Equal("265,303 265,263 235,263 235,303", elements[1].Attributes[0].Value);
            Assert.Equal("665,303 665,263 635,263 635,303", elements[2].Attributes[0].Value);
            Assert.Equal("465,453 465,413 435,413 435,453", elements[3].Attributes[0].Value);


            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");
            Assert.Equal("445", texts[0].Attributes[0].Value);
            Assert.Equal("137", texts[0].Attributes[1].Value);
            Assert.Equal("B", texts[0].InnerText);

            Assert.Equal("245", texts[1].Attributes[0].Value);
            Assert.Equal("287", texts[1].Attributes[1].Value);
            Assert.Equal("A", texts[1].InnerText);

            Assert.Equal("645", texts[2].Attributes[0].Value);
            Assert.Equal("287", texts[2].Attributes[1].Value);
            Assert.Equal("D", texts[2].InnerText);

            Assert.Equal("445", texts[3].Attributes[0].Value);
            Assert.Equal("437", texts[3].Attributes[1].Value);
            Assert.Equal("C", texts[3].InnerText);

            var lines = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='line']");
            Assert.Equal("265", lines[0].Attributes[0].Value);
            Assert.Equal("283", lines[0].Attributes[1].Value);
            Assert.Equal("430", lines[0].Attributes[2].Value);
            Assert.Equal("133", lines[0].Attributes[3].Value);

            Assert.Equal("265", lines[1].Attributes[0].Value);
            Assert.Equal("283", lines[1].Attributes[1].Value);
            Assert.Equal("430", lines[1].Attributes[2].Value);
            Assert.Equal("433", lines[1].Attributes[3].Value);

            Assert.Equal("465", lines[2].Attributes[0].Value);
            Assert.Equal("133", lines[2].Attributes[1].Value);
            Assert.Equal("630", lines[2].Attributes[2].Value);
            Assert.Equal("283", lines[2].Attributes[3].Value);

            Assert.Equal("465", lines[3].Attributes[0].Value);
            Assert.Equal("433", lines[3].Attributes[1].Value);
            Assert.Equal("630", lines[3].Attributes[2].Value);
            Assert.Equal("283", lines[3].Attributes[3].Value);
        }

        [Fact]
        public void TwinsOfTwinsSituationWorks()
        {
            var stream = new MemoryStream();
            Writer.CreateWriter(stream);

            var flowchart = new Flowchart("LeftRight", stream);

            flowchart.AddPair(("A", "A", rectangle), ("B", "B", "Rectangle"), arrow);
            flowchart.AddPair(("A", "A", rectangle), ("C", "C", "Rectangle"), arrow);
            flowchart.AddPair("B", ("D", "D", "Rectangle"), arrow);
            flowchart.AddPair("B", ("E", "E", "Rectangle"), arrow);
            flowchart.AddPair("C", ("F", "F", "Rectangle"), arrow);
            flowchart.AddPair("C", ("G", "G", "Rectangle"), arrow);

            flowchart.DrawFlowchart();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var elements = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='polygon']");
            Assert.Equal("665,153 665,113 635,113 635,153", elements[0].Attributes[0].Value);
            Assert.Equal("465,303 465,263 435,263 435,303", elements[1].Attributes[0].Value);
            Assert.Equal("665,453 665,413 635,413 635,453", elements[2].Attributes[0].Value);
            Assert.Equal("265,603 265,563 235,563 235,603", elements[3].Attributes[0].Value);
            Assert.Equal("665,603 665,563 635,563 635,603", elements[4].Attributes[0].Value);
            Assert.Equal("465,753 465,713 435,713 435,753", elements[5].Attributes[0].Value);
            Assert.Equal("665,903 665,863 635,863 635,903", elements[6].Attributes[0].Value);


            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");
            Assert.Equal("645", texts[0].Attributes[0].Value);
            Assert.Equal("137", texts[0].Attributes[1].Value);
            Assert.Equal("D", texts[0].InnerText);

            Assert.Equal("445", texts[1].Attributes[0].Value);
            Assert.Equal("287", texts[1].Attributes[1].Value);
            Assert.Equal("B", texts[1].InnerText);

            Assert.Equal("645", texts[2].Attributes[0].Value);
            Assert.Equal("437", texts[2].Attributes[1].Value);
            Assert.Equal("E", texts[2].InnerText);

            Assert.Equal("245", texts[3].Attributes[0].Value);
            Assert.Equal("587", texts[3].Attributes[1].Value);
            Assert.Equal("A", texts[3].InnerText);

            Assert.Equal("645", texts[4].Attributes[0].Value);
            Assert.Equal("587", texts[4].Attributes[1].Value);
            Assert.Equal("F", texts[4].InnerText);

            Assert.Equal("445", texts[5].Attributes[0].Value);
            Assert.Equal("737", texts[5].Attributes[1].Value);
            Assert.Equal("C", texts[5].InnerText);

            Assert.Equal("645", texts[6].Attributes[0].Value);
            Assert.Equal("887", texts[6].Attributes[1].Value);
            Assert.Equal("G", texts[6].InnerText);
        }

        [Fact]
        public void WorksWith10Children()
        {
            var stream = new MemoryStream();
            Writer.CreateWriter(stream);

            var flowchart = new Flowchart("LeftRight", stream);

            flowchart.AddPair(("A", "A", rectangle), ("B", "B", "Rectangle"), arrow);
            flowchart.AddPair("A", ("C", "C", "Rectangle"), arrow);
            flowchart.AddPair("A", ("D", "D", "Rectangle"), arrow);
            flowchart.AddPair("A", ("E", "E", "Rectangle"), arrow);
            flowchart.AddPair("A", ("F", "F", "Rectangle"), arrow);
            flowchart.AddPair("A", ("G", "G", "Rectangle"), arrow);
            flowchart.AddPair("A", ("H", "H", "Rectangle"), arrow);
            flowchart.AddPair("A", ("I", "I", "Rectangle"), arrow);
            flowchart.AddPair("A", ("J", "J", "Rectangle"), arrow);
            flowchart.AddPair("A", ("K", "K", "Rectangle"), arrow);

            flowchart.DrawFlowchart();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var elements = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='polygon']");
            Assert.Equal("465,153 465,113 435,113 435,153", elements[0].Attributes[0].Value);
            Assert.Equal("465,303 465,263 435,263 435,303", elements[1].Attributes[0].Value);
            Assert.Equal("465,453 465,413 435,413 435,453", elements[2].Attributes[0].Value);
            Assert.Equal("465,603 465,563 435,563 435,603", elements[3].Attributes[0].Value);
            Assert.Equal("265,753 265,713 235,713 235,753", elements[4].Attributes[0].Value);
            Assert.Equal("465,753 465,713 435,713 435,753", elements[5].Attributes[0].Value);
            Assert.Equal("465,903 465,863 435,863 435,903", elements[6].Attributes[0].Value);
            Assert.Equal("465,1053 465,1013 435,1013 435,1053", elements[7].Attributes[0].Value);
            Assert.Equal("465,1203 465,1163 435,1163 435,1203", elements[8].Attributes[0].Value);
            Assert.Equal("465,1353 465,1313 435,1313 435,1353", elements[9].Attributes[0].Value);
            Assert.Equal("465,1503 465,1463 435,1463 435,1503", elements[10].Attributes[0].Value);


            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");
            Assert.Equal("445", texts[0].Attributes[0].Value);
            Assert.Equal("137", texts[0].Attributes[1].Value);
            Assert.Equal("B", texts[0].InnerText);

            Assert.Equal("445", texts[1].Attributes[0].Value);
            Assert.Equal("287", texts[1].Attributes[1].Value);
            Assert.Equal("C", texts[1].InnerText);

            Assert.Equal("445", texts[2].Attributes[0].Value);
            Assert.Equal("437", texts[2].Attributes[1].Value);
            Assert.Equal("D", texts[2].InnerText);

            Assert.Equal("445", texts[3].Attributes[0].Value);
            Assert.Equal("587", texts[3].Attributes[1].Value);
            Assert.Equal("E", texts[3].InnerText);

            Assert.Equal("245", texts[4].Attributes[0].Value);
            Assert.Equal("737", texts[4].Attributes[1].Value);
            Assert.Equal("A", texts[4].InnerText);

            Assert.Equal("445", texts[5].Attributes[0].Value);
            Assert.Equal("737", texts[5].Attributes[1].Value);
            Assert.Equal("F", texts[5].InnerText);

            Assert.Equal("445", texts[6].Attributes[0].Value);
            Assert.Equal("887", texts[6].Attributes[1].Value);
            Assert.Equal("G", texts[6].InnerText);

            Assert.Equal("445", texts[7].Attributes[0].Value);
            Assert.Equal("1037", texts[7].Attributes[1].Value);
            Assert.Equal("H", texts[7].InnerText);

            Assert.Equal("445", texts[8].Attributes[0].Value);
            Assert.Equal("1187", texts[8].Attributes[1].Value);
            Assert.Equal("I", texts[8].InnerText);

            Assert.Equal("445", texts[9].Attributes[0].Value);
            Assert.Equal("1337", texts[9].Attributes[1].Value);
            Assert.Equal("J", texts[9].InnerText);

            Assert.Equal("445", texts[10].Attributes[0].Value);
            Assert.Equal("1487", texts[10].Attributes[1].Value);
            Assert.Equal("K", texts[10].InnerText);
        }

        [Fact]
        public void TextBoxReizesAccordingly()
        {
            var stream = new MemoryStream();
            Writer.CreateWriter(stream);

            var flowchart = new Flowchart("LeftRight", stream);

            flowchart.AddPair(("A", "A", rectangle), ("B", "B", "Rectangle"), arrow);
            flowchart.AddPair("A", ("C", "CCC", "Rectangle"), arrow);
            flowchart.AddPair("A", ("D", "DDDDDD", "Rectangle"), arrow);
            flowchart.AddPair("A", ("E", "EEEEEEEE", "Rectangle"), arrow);
            flowchart.AddPair("A", ("F", "FFFFFF FFFFFFFF FFFF", "Rectangle"), arrow);
            flowchart.AddPair("A", ("G", "G GGG GGGG GGGG GGGG GGG", "Rectangle"), arrow);
            flowchart.AddPair("A", ("H", "HHHHHH H HHHHHH HHHH HH HHHHHH HHHH H", "Rectangle"), arrow);
            flowchart.AddPair("A", ("I", "II I IIIIIIIIII I IIIIIIIIIIIII IIIIIII II I", "Rectangle"), arrow);
            flowchart.AddPair("A", ("J", "JJJJJJJJJJJ J JJJJJJJJJJJJJJ JJJJJJJJJJJ JJJJJ JJ J J", "Rectangle"), arrow);
            flowchart.AddPair("A", ("K", "KK K KKKKK KK KKKKK KKKK KKKKKKK KKKKK KKKKK KKKK KK KKKK", "Rectangle"), arrow);

            flowchart.DrawFlowchart();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var elements = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='polygon']");
            Assert.Equal("465,153 465,113 435,113 435,153", elements[0].Attributes[0].Value);
            Assert.Equal("480.5,303 480.5,263 419.5,263 419.5,303", elements[1].Attributes[0].Value);
            Assert.Equal("501.5,453 501.5,413 398.5,413 398.5,453", elements[2].Attributes[0].Value);
            Assert.Equal("502,603 502,563 398,563 398,603", elements[3].Attributes[0].Value);
            Assert.Equal("265,753 265,713 235,713 235,753", elements[4].Attributes[0].Value);
            Assert.Equal("563.75,753 563.75,713 336.25,713 336.25,753", elements[5].Attributes[0].Value);
            Assert.Equal("580,911.5 580,854.5 320,854.5 320,911.5", elements[6].Attributes[0].Value);
            Assert.Equal("583.25,1061.5 583.25,1004.5 316.75,1004.5 316.75,1061.5", elements[7].Attributes[0].Value);
            Assert.Equal("505.25,1220 505.25,1146 394.75,1146 394.75,1220", elements[8].Attributes[0].Value);
            Assert.Equal("534.5,1378.5 534.5,1287.5 365.5,1287.5 365.5,1378.5", elements[9].Attributes[0].Value);
            Assert.Equal("570.25,1520 570.25,1446 329.75,1446 329.75,1520", elements[10].Attributes[0].Value);

            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");
            Assert.Equal("445", texts[0].Attributes[0].Value);
            Assert.Equal("137", texts[0].Attributes[1].Value);
            Assert.Equal("B", texts[0].InnerText);

            Assert.Equal("429.5", texts[1].Attributes[0].Value);
            Assert.Equal("287", texts[1].Attributes[1].Value);
            Assert.Equal("CCC", texts[1].InnerText);

            Assert.Equal("408.5", texts[2].Attributes[0].Value);
            Assert.Equal("437", texts[2].Attributes[1].Value);
            Assert.Equal("DDDDDD", texts[2].InnerText);

            Assert.Equal("408", texts[3].Attributes[0].Value);
            Assert.Equal("587", texts[3].Attributes[1].Value);
            Assert.Equal("EEEEEEEE", texts[3].InnerText);

            Assert.Equal("245", texts[4].Attributes[0].Value);
            Assert.Equal("737", texts[4].Attributes[1].Value);
            Assert.Equal("A", texts[4].InnerText);

            Assert.Equal("346.25", texts[5].Attributes[0].Value);
            Assert.Equal("737", texts[5].Attributes[1].Value);
            Assert.Equal("FFFFFF FFFFFFFF FFFF", texts[5].InnerText);

            Assert.Equal("330", texts[6].Attributes[0].Value);
            Assert.Equal("878.5", texts[6].Attributes[1].Value);
            Assert.Equal("G GGG GGGG GGGG GGGGGGG", texts[6].InnerText);

            Assert.Equal("326.75", texts[7].Attributes[0].Value);
            Assert.Equal("1028.5", texts[7].Attributes[1].Value);
            Assert.Equal("HHHHHH H HHHHHH HHHHHH HHHHHH HHHH H", texts[7].InnerText);

            Assert.Equal("404.75", texts[8].Attributes[0].Value);
            Assert.Equal("1170", texts[8].Attributes[1].Value);
            Assert.Equal("II I IIIIIIIIII IIIIIIIIIIIIIIIIIIIII II I", texts[8].InnerText);

            Assert.Equal("375.5", texts[9].Attributes[0].Value);
            Assert.Equal("1311.5", texts[9].Attributes[1].Value);
            Assert.Equal("JJJJJJJJJJJ JJJJJJJJJJJJJJJJJJJJJJJJJJ JJJJJ JJJ J", texts[9].InnerText);

            Assert.Equal("339.75", texts[10].Attributes[0].Value);
            Assert.Equal("1470", texts[10].Attributes[1].Value);
            Assert.Equal("KK K KKKKK KK KKKKKKKKK KKKKKKK KKKKKKKKKK KKKK KK KKKK", texts[10].InnerText);
        }

        [Fact]
        public void BackArrowWorks()
        {
            var stream = new MemoryStream();
            Writer.CreateWriter(stream);

            var flowchart = new Flowchart("LeftRight", stream);

            flowchart.AddPair(("A", "A", rectangle), ("B", "B", "Rectangle"), arrow);
            flowchart.AddPair("A", "B", "BackArrow");

            flowchart.DrawFlowchart();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var elements = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='polygon']");
            Assert.Equal("265,153 265,113 235,113 235,153", elements[0].Attributes[0].Value);
            Assert.Equal("465,153 465,113 435,113 435,153", elements[1].Attributes[0].Value);


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


            var backArrows = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='polyline']");

            Assert.Equal("230, 133 341.6666666666667, 141.33333333333334 470, 133", backArrows[0].Attributes[0].Value);
        }

        [Fact]
        public void SideArrowWorks()
        {
            var stream = new MemoryStream();
            Writer.CreateWriter(stream);

            var flowchart = new Flowchart("LeftRight", stream);

            flowchart.AddPair(("A", "A", rectangle), ("B", "B", "Rectangle"), arrow);
            flowchart.AddPair(("A", "A", rectangle), ("C", "C", "Rectangle"), arrow);
            flowchart.AddPair("B", "C", "SideArrow");
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

            Assert.Equal("450", lines[2].Attributes[0].Value);
            Assert.Equal("153", lines[2].Attributes[1].Value);
            Assert.Equal("450", lines[2].Attributes[2].Value);
            Assert.Equal("408", lines[2].Attributes[3].Value);
        }

        [Fact]
        public void ShapeRectangleWorks()
        {
            var stream = new MemoryStream();
            Writer.CreateWriter(stream);
            string shape = "Rectangle";
            var flowchart = new Flowchart("LeftRight", stream);

            flowchart.AddPair(("A", "A", shape), ("B", "BB", shape), arrow);
            flowchart.AddPair(("A2", "AAAAAAAA", shape), ("B2", "BBB BBBBBB BBBBBB BBBBBB BB", shape), arrow);
            flowchart.AddPair(("A4", "AAA AAAAAA A A AAAAAA A AA AAAA AAAAA AA AAAAA AAAA", shape), ("B4", "BBBB BBBB BBBB BBBBBBB BBBBBB BBBBB BBBB BBB BB BBB", shape), arrow);

            flowchart.DrawFlowchart();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var elements = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='polygon']");
            Assert.Equal("265,153 265,113 235,113 235,153", elements[0].Attributes[0].Value);
            Assert.Equal("472.5,153 472.5,113 427.5,113 427.5,153", elements[1].Attributes[0].Value);
            Assert.Equal("308.5,303 308.5,263 191.5,263 191.5,303", elements[2].Attributes[0].Value);
            Assert.Equal("560.5,311.5 560.5,254.5 339.5,254.5 339.5,311.5", elements[3].Attributes[0].Value);
            Assert.Equal("376.75,470 376.75,396 123.25,396 123.25,470", elements[4].Attributes[0].Value);
            Assert.Equal("580,470 580,396 320,396 320,470", elements[5].Attributes[0].Value);

            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");
            Assert.Equal("245", texts[0].Attributes[0].Value);
            Assert.Equal("137", texts[0].Attributes[1].Value);
            Assert.Equal("A", texts[0].InnerText);

            Assert.Equal("437.5", texts[1].Attributes[0].Value);
            Assert.Equal("137", texts[1].Attributes[1].Value);
            Assert.Equal("BB", texts[1].InnerText);

            Assert.Equal("201.5", texts[2].Attributes[0].Value);
            Assert.Equal("287", texts[2].Attributes[1].Value);
            Assert.Equal("AAAAAAAA", texts[2].InnerText);

            Assert.Equal("349.5", texts[3].Attributes[0].Value);
            Assert.Equal("278.5", texts[3].Attributes[1].Value);
            Assert.Equal("BBB BBBBBB BBBBBBBBBBBB BB", texts[3].InnerText);

            Assert.Equal("133.25", texts[4].Attributes[0].Value);
            Assert.Equal("420", texts[4].Attributes[1].Value);
            Assert.Equal("AAA AAAAAA A AAAAAAA A AA AAAAAAAAA AA AAAAA AAAA", texts[4].InnerText);

            Assert.Equal("330", texts[5].Attributes[0].Value);
            Assert.Equal("420", texts[5].Attributes[1].Value);
            Assert.Equal("BBBB BBBB BBBBBBBBBBB BBBBBB BBBBBBBBB BBB BB BBB", texts[5].InnerText);
        }

        [Fact]
        public void ShapeBannerWorks()
        {
            var stream = new MemoryStream();
            Writer.CreateWriter(stream);
            string shape = "Banner";
            var flowchart = new Flowchart("LeftRight", stream);

            flowchart.AddPair(("A", "A", shape), ("B", "BB", shape), arrow);
            flowchart.AddPair(("A2", "AAAAAAAA", shape), ("B2", "BBB BBBBBB BBBBBB BBBBBB BB", shape), arrow);
            flowchart.AddPair(("A4", "AAA AAAAAA A A AAAAAA A AA AAAA AAAAA AA AAAAA AAAA", shape), ("B4", "BBBB BBBB BBBB BBBBBBB BBBBBB BBBBB BBBB BBB BB BBB", shape), arrow);

            flowchart.DrawFlowchart();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var elements = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='polygon']");
            Assert.Equal("205,115.5 225,133 205,150.5 263,150.5 263,115.5", elements[0].Attributes[0].Value);
            Assert.Equal("397.5,115.5 417.5,133 397.5,150.5 471.5,150.5 471.5,115.5", elements[1].Attributes[0].Value);
            Assert.Equal("161.5,265.5 181.5,283 161.5,300.5 306.7,300.5 306.7,265.5", elements[2].Attributes[0].Value);
            Assert.Equal("309.5,256 329.5,283 309.5,310 557.1,310 557.1,256", elements[3].Attributes[0].Value);
            Assert.Equal("93.25,397 113.25,433 93.25,469 372.85,469 372.85,397", elements[4].Attributes[0].Value);
            Assert.Equal("290,397 310,433 290,469 576,469 576,397", elements[5].Attributes[0].Value);

            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");
            Assert.Equal("232.75", texts[0].Attributes[0].Value);
            Assert.Equal("139.5", texts[0].Attributes[1].Value);
            Assert.Equal("A", texts[0].InnerText);

            Assert.Equal("425.75", texts[1].Attributes[0].Value);
            Assert.Equal("139.5", texts[1].Attributes[1].Value);
            Assert.Equal("BB", texts[1].InnerText);

            Assert.Equal("194.6", texts[2].Attributes[0].Value);
            Assert.Equal("289.5", texts[2].Attributes[1].Value);
            Assert.Equal("AAAAAAAA", texts[2].InnerText);

            Assert.Equal("349.8", texts[3].Attributes[0].Value);
            Assert.Equal("280", texts[3].Attributes[1].Value);
            Assert.Equal("BBB BBBBBB BBBBBBBBBBBB BB", texts[3].InnerText);

            Assert.Equal("135.8", texts[4].Attributes[0].Value);
            Assert.Equal("421", texts[4].Attributes[1].Value);
            Assert.Equal("AAA AAAAAA A AAAAAAA A AA AAAAAAAAA AA AAAAA AAAA", texts[4].InnerText);

            Assert.Equal("333", texts[5].Attributes[0].Value);
            Assert.Equal("421", texts[5].Attributes[1].Value);
            Assert.Equal("BBBB BBBB BBBBBBBBBBB BBBBBB BBBBBBBBB BBB BB BBB", texts[5].InnerText);
        }

        [Fact]
        public void ShapeCricleWorks()
        {
            var stream = new MemoryStream();
            Writer.CreateWriter(stream);
            string shape = "Circle";
            var flowchart = new Flowchart("LeftRight", stream);

            flowchart.AddPair(("A", "A", shape), ("B", "BB", shape), arrow);
            flowchart.AddPair(("A2", "AAAAAAAA", shape), ("B2", "BBB BBBBBB BBBBBB BBBBBB BB", shape), arrow);
            flowchart.AddPair(("A4", "AAA AAAAAA A A AAAAAA A AA AAAA AAAAA AA AAAAA AAAA", shape), ("B4", "BBBB BBBB BBBB BBBBBBB BBBBBB BBBBB BBBB BBB BB BBB", shape), arrow);

            flowchart.DrawFlowchart();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var elements = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='circle']");
            Assert.Equal("250", elements[0].Attributes[0].Value);
            Assert.Equal("134", elements[0].Attributes[1].Value);
            Assert.Equal("20", elements[0].Attributes[2].Value);

            Assert.Equal("450", elements[1].Attributes[0].Value);
            Assert.Equal("134", elements[1].Attributes[1].Value);
            Assert.Equal("28", elements[1].Attributes[2].Value);

            Assert.Equal("250", elements[2].Attributes[0].Value);
            Assert.Equal("284", elements[2].Attributes[1].Value);
            Assert.Equal("61", elements[2].Attributes[2].Value);

            Assert.Equal("450", elements[3].Attributes[0].Value);
            Assert.Equal("284", elements[3].Attributes[1].Value);
            Assert.Equal("116", elements[3].Attributes[2].Value);

            Assert.Equal("250", elements[4].Attributes[0].Value);
            Assert.Equal("284", elements[3].Attributes[1].Value);
            Assert.Equal("133", elements[4].Attributes[2].Value);

            Assert.Equal("450", elements[5].Attributes[0].Value);
            Assert.Equal("284", elements[3].Attributes[1].Value);
            Assert.Equal("136", elements[5].Attributes[2].Value);

            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");
            Assert.Equal("243", texts[0].Attributes[0].Value);
            Assert.Equal("147", texts[0].Attributes[1].Value);
            Assert.Equal("A", texts[0].InnerText);

            Assert.Equal("436.2", texts[1].Attributes[0].Value);
            Assert.Equal("143.25", texts[1].Attributes[1].Value);
            Assert.Equal("BB", texts[1].InnerText);

            Assert.Equal("208.15", texts[2].Attributes[0].Value);
            Assert.Equal("276.4", texts[2].Attributes[1].Value);
            Assert.Equal("AAAAAAAA", texts[2].InnerText);

            Assert.Equal("361.4", texts[3].Attributes[0].Value);
            Assert.Equal("249.2", texts[3].Attributes[1].Value);
            Assert.Equal("BBB BBBBBB BBBBBBBBBBBB BB", texts[3].InnerText);

            Assert.Equal("146.95", texts[4].Attributes[0].Value);
            Assert.Equal("390.7", texts[4].Attributes[1].Value);
            Assert.Equal("AAA AAAAAA A AAAAAAA A AA AAAAAAAAA AA AAAAA AAAA", texts[4].InnerText);

            Assert.Equal("344.4", texts[5].Attributes[0].Value);
            Assert.Equal("389", texts[5].Attributes[1].Value);
            Assert.Equal("BBBB BBBB BBBBBBBBBBB BBBBBB BBBBBBBBB BBB BB BBB", texts[5].InnerText);
        }

        [Fact]
        public void ShapeCylinderWorks()
        {
            var stream = new MemoryStream();
            Writer.CreateWriter(stream);
            string shape = "Cylinder";
            var flowchart = new Flowchart("LeftRight", stream);

            flowchart.AddPair(("A", "A", shape), ("B", "BB", shape), arrow);
            flowchart.AddPair(("A2", "AAAAAAAA", shape), ("B2", "BBB BBBBBB BBBBBB BBBBBB BB", shape), arrow);
            flowchart.AddPair(("A4", "AAA AAAAAA A A AAAAAA A AA AAAA AAAAA AA AAAAA AAAA", shape), ("B4", "BBBB BBBB BBBB BBBBBBB BBBBBB BBBBB BBBB BBB BB BBB", shape), arrow);

            flowchart.DrawFlowchart();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var elements = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='polygon']");
            Assert.Equal("265,152 265,104 235,104 235,152", elements[0].Attributes[0].Value);
            Assert.Equal("472.5,152 472.5,104 427.5,104 427.5,152", elements[1].Attributes[0].Value);
            Assert.Equal("308.5,302 308.5,254 191.5,254 191.5,302", elements[2].Attributes[0].Value);
            Assert.Equal("560.5,310.925 560.5,241.675 339.5,241.675 339.5,310.925", elements[3].Attributes[0].Value);
            Assert.Equal("376.75,469.85 376.75,379.35 123.25,379.35 123.25,469.85", elements[4].Attributes[0].Value);
            Assert.Equal("580,469.85 580,379.35 320,379.35 320,469.85", elements[5].Attributes[0].Value);


            var ellipses = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='ellipse']");
            Assert.Equal("250", ellipses[0].Attributes[0].Value);
            Assert.Equal("103", ellipses[0].Attributes[1].Value);
            Assert.Equal("15", ellipses[0].Attributes[2].Value);
            Assert.Equal("10", ellipses[0].Attributes[3].Value);

            Assert.Equal("250", ellipses[1].Attributes[0].Value);
            Assert.Equal("153", ellipses[1].Attributes[1].Value);
            Assert.Equal("15", ellipses[1].Attributes[2].Value);
            Assert.Equal("10", ellipses[1].Attributes[3].Value);

            Assert.Equal("450", ellipses[2].Attributes[0].Value);
            Assert.Equal("103", ellipses[2].Attributes[1].Value);
            Assert.Equal("22.5", ellipses[2].Attributes[2].Value);
            Assert.Equal("10", ellipses[2].Attributes[3].Value);

            Assert.Equal("450", ellipses[3].Attributes[0].Value);
            Assert.Equal("153", ellipses[3].Attributes[1].Value);
            Assert.Equal("22.5", ellipses[3].Attributes[2].Value);
            Assert.Equal("10", ellipses[3].Attributes[3].Value);

            Assert.Equal("250", ellipses[4].Attributes[0].Value);
            Assert.Equal("253", ellipses[4].Attributes[1].Value);
            Assert.Equal("58.5", ellipses[4].Attributes[2].Value);
            Assert.Equal("10", ellipses[4].Attributes[3].Value);

            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");
            Assert.Equal("245", texts[0].Attributes[0].Value);
            Assert.Equal("137", texts[0].Attributes[1].Value);
            Assert.Equal("A", texts[0].InnerText);

            Assert.Equal("437.5", texts[1].Attributes[0].Value);
            Assert.Equal("137", texts[1].Attributes[1].Value);
            Assert.Equal("BB", texts[1].InnerText);

            Assert.Equal("201.5", texts[2].Attributes[0].Value);
            Assert.Equal("287", texts[2].Attributes[1].Value);
            Assert.Equal("AAAAAAAA", texts[2].InnerText);

            Assert.Equal("349.5", texts[3].Attributes[0].Value);
            Assert.Equal("278.5", texts[3].Attributes[1].Value);
            Assert.Equal("BBB BBBBBB BBBBBBBBBBBB BB", texts[3].InnerText);

            Assert.Equal("133.25", texts[4].Attributes[0].Value);
            Assert.Equal("420", texts[4].Attributes[1].Value);
            Assert.Equal("AAA AAAAAA A AAAAAAA A AA AAAAAAAAA AA AAAAA AAAA", texts[4].InnerText);

            Assert.Equal("330", texts[5].Attributes[0].Value);
            Assert.Equal("420", texts[5].Attributes[1].Value);
            Assert.Equal("BBBB BBBB BBBBBBBBBBB BBBBBB BBBBBBBBB BBB BB BBB", texts[5].InnerText);
        }

        [Fact]
        public void ShapeHexagonWorks()
        {
            var stream = new MemoryStream();
            Writer.CreateWriter(stream);
            string shape = "Hexagon";
            var flowchart = new Flowchart("LeftRight", stream);

            flowchart.AddPair(("A", "A", shape), ("B", "BB", shape), arrow);
            flowchart.AddPair(("A2", "AAAAAAAA", shape), ("B2", "BBB BBBBBB BBBBBB BBBBBB BB", shape), arrow);
            flowchart.AddPair(("A4", "AAA AAAAAA A A AAAAAA A AA AAAA AAAAA AA AAAAA AAAA", shape), ("B4", "BBBB BBBB BBBB BBBBBBB BBBBBB BBBBB BBBB BBB BB BBB", shape), arrow);

            flowchart.DrawFlowchart();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var elements = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='polygon']");
            Assert.Equal("235,113 225,133 235,153 265,153 275,133 265,113", elements[0].Attributes[0].Value);
            Assert.Equal("427.5,113 417.5,133 427.5,153 472.5,153 482.5,133 472.5,113", elements[1].Attributes[0].Value);
            Assert.Equal("191.5,263 181.5,283 191.5,303 308.5,303 318.5,283 308.5,263", elements[2].Attributes[0].Value);
            Assert.Equal("339.5,254.5 319.5,283 339.5,311.5 560.5,311.5 580.5,283 560.5,254.5", elements[3].Attributes[0].Value);
            Assert.Equal("123.25,396 93.25,433 123.25,470 376.75,470 406.75,433 376.75,396", elements[4].Attributes[0].Value);
            Assert.Equal("320,396 290,433 320,470 580,470 610,433 580,396", elements[5].Attributes[0].Value);

            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");
            Assert.Equal("245", texts[0].Attributes[0].Value);
            Assert.Equal("137", texts[0].Attributes[1].Value);
            Assert.Equal("A", texts[0].InnerText);

            Assert.Equal("437.5", texts[1].Attributes[0].Value);
            Assert.Equal("137", texts[1].Attributes[1].Value);
            Assert.Equal("BB", texts[1].InnerText);

            Assert.Equal("201.5", texts[2].Attributes[0].Value);
            Assert.Equal("287", texts[2].Attributes[1].Value);
            Assert.Equal("AAAAAAAA", texts[2].InnerText);

            Assert.Equal("349.5", texts[3].Attributes[0].Value);
            Assert.Equal("278.5", texts[3].Attributes[1].Value);
            Assert.Equal("BBB BBBBBB BBBBBBBBBBBB BB", texts[3].InnerText);

            Assert.Equal("133.25", texts[4].Attributes[0].Value);
            Assert.Equal("420", texts[4].Attributes[1].Value);
            Assert.Equal("AAA AAAAAA A AAAAAAA A AA AAAAAAAAA AA AAAAA AAAA", texts[4].InnerText);

            Assert.Equal("330", texts[5].Attributes[0].Value);
            Assert.Equal("420", texts[5].Attributes[1].Value);
            Assert.Equal("BBBB BBBB BBBBBBBBBBB BBBBBB BBBBBBBBB BBB BB BBB", texts[5].InnerText);
        }

        [Fact]
        public void ShapesParallelogramAndParallelogramAltWorks()
        {
            var stream = new MemoryStream();
            Writer.CreateWriter(stream);
            string shape1 = "Parallelogram";
            string shape2 = "ParallelogramAlt";
            var flowchart = new Flowchart("LeftRight", stream);

            flowchart.AddPair(("A", "A", shape1), ("B", "BB", shape2), arrow);
            flowchart.AddPair(("A2", "AAAAAAAA", shape1), ("B2", "BBB BBBBBB BBBBBB BBBBBB BB", shape2), arrow);
            flowchart.AddPair(("A4", "AAA AAAAAA A A AAAAAA A AA AAAA AAAAA AA AAAAA AAAA", shape1), ("B4", "BBBB BBBB BBBB BBBBBBB BBBBBB BBBBB BBBB BBB BB BBB", shape2), arrow);

            flowchart.DrawFlowchart();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var elements = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='polygon']");
            Assert.Equal("280,153 265,113 220,113 235,153", elements[0].Attributes[0].Value);
            Assert.Equal("487.5,113 472.5,153 412.5,153 427.5,113", elements[1].Attributes[0].Value);
            Assert.Equal("323.5,303 308.5,263 176.5,263 191.5,303", elements[2].Attributes[0].Value);
            Assert.Equal("581.7132034355964,254.5 560.5,311.5 318.2867965644036,311.5 339.5,254.5", elements[3].Attributes[0].Value);
            Assert.Equal("402.73076211353316,470 376.75,396 97.26923788646684,396 123.25,470", elements[4].Attributes[0].Value);
            Assert.Equal("605.9807621135332,396 580,470 294.01923788646684,470 320,396", elements[5].Attributes[0].Value);

            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");
            Assert.Equal("245", texts[0].Attributes[0].Value);
            Assert.Equal("137", texts[0].Attributes[1].Value);
            Assert.Equal("A", texts[0].InnerText);

            Assert.Equal("437.5", texts[1].Attributes[0].Value);
            Assert.Equal("137", texts[1].Attributes[1].Value);
            Assert.Equal("BB", texts[1].InnerText);

            Assert.Equal("201.5", texts[2].Attributes[0].Value);
            Assert.Equal("287", texts[2].Attributes[1].Value);
            Assert.Equal("AAAAAAAA", texts[2].InnerText);

            Assert.Equal("349.5", texts[3].Attributes[0].Value);
            Assert.Equal("278.5", texts[3].Attributes[1].Value);
            Assert.Equal("BBB BBBBBB BBBBBBBBBBBB BB", texts[3].InnerText);

            Assert.Equal("133.25", texts[4].Attributes[0].Value);
            Assert.Equal("420", texts[4].Attributes[1].Value);
            Assert.Equal("AAA AAAAAA A AAAAAAA A AA AAAAAAAAA AA AAAAA AAAA", texts[4].InnerText);

            Assert.Equal("330", texts[5].Attributes[0].Value);
            Assert.Equal("420", texts[5].Attributes[1].Value);
            Assert.Equal("BBBB BBBB BBBBBBBBBBB BBBBBB BBBBBBBBB BBB BB BBB", texts[5].InnerText);
        }

        [Fact]
        public void ShapeRhombusWorks()
        {
            var stream = new MemoryStream();
            Writer.CreateWriter(stream);
            string shape = "Rhombus";
            var flowchart = new Flowchart("LeftRight", stream);

            flowchart.AddPair(("A", "A", shape), ("B", "BB", shape), arrow);
            flowchart.AddPair(("A2", "AAAAAAAA", shape), ("B2", "BBB BBBBBB BBBBBB BBBBBB BB", shape), arrow);
            flowchart.AddPair(("A4", "AAA AAAAAA A A AAAAAA A AA AAAA AAAAA AA AAAAA AAAA", shape), ("B4", "BBBB BBBB BBBB BBBBBBB BBBBBB BBBBB BBBB BBB BB BBB", shape), arrow);

            flowchart.DrawFlowchart();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var elements = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='polygon']");
            Assert.Equal("255.75,106.25 229,133 255.75,159.75 282.5,133", elements[0].Attributes[0].Value);
            Assert.Equal("450.75,103.75 421.5,133 450.75,162.25 480,133", elements[1].Attributes[0].Value);
            Assert.Equal("250.75,217.75 185.5,283 250.75,348.25 316,283", elements[2].Attributes[0].Value);
            Assert.Equal("451.5,159 327.5,283 451.5,407 575.5,283", elements[3].Attributes[0].Value);
            Assert.Equal("252.25,286 105.25,433 252.25,580 399.25,433", elements[4].Attributes[0].Value);
            Assert.Equal("452.25,282.75 302,433 452.25,583.25 602.5,433", elements[5].Attributes[0].Value);

            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");
            Assert.Equal("246.5", texts[0].Attributes[0].Value);
            Assert.Equal("137", texts[0].Attributes[1].Value);
            Assert.Equal("A", texts[0].InnerText);

            Assert.Equal("439.75", texts[1].Attributes[0].Value);
            Assert.Equal("137", texts[1].Attributes[1].Value);
            Assert.Equal("BB", texts[1].InnerText);

            Assert.Equal("207.35", texts[2].Attributes[0].Value);
            Assert.Equal("287", texts[2].Attributes[1].Value);
            Assert.Equal("AAAAAAAA", texts[2].InnerText);

            Assert.Equal("360.55", texts[3].Attributes[0].Value);
            Assert.Equal("278.5", texts[3].Attributes[1].Value);
            Assert.Equal("BBB BBBBBB BBBBBBBBBBBB BB", texts[3].InnerText);

            Assert.Equal("145.925", texts[4].Attributes[0].Value);
            Assert.Equal("420", texts[4].Attributes[1].Value);
            Assert.Equal("AAA AAAAAA A AAAAAAA A AA AAAAAAAAA AA AAAAA AAAA", texts[4].InnerText);

            Assert.Equal("343", texts[5].Attributes[0].Value);
            Assert.Equal("420", texts[5].Attributes[1].Value);
            Assert.Equal("BBBB BBBB BBBBBBBBBBB BBBBBB BBBBBBBBB BBB BB BBB", texts[5].InnerText);
        }

        [Fact]
        public void ShapeStadiumWorks()
        {
            var stream = new MemoryStream();
            Writer.CreateWriter(stream);
            string shape = "Stadium";
            var flowchart = new Flowchart("LeftRight", stream);

            flowchart.AddPair(("A", "A", shape), ("B", "BB", shape), arrow);
            flowchart.AddPair(("A2", "AAAAAAAA", shape), ("B2", "BBB BBBBBB BBBBBB BBBBBB BB", shape), arrow);
            flowchart.AddPair(("A4", "AAA AAAAAA A A AAAAAA A AA AAAA AAAAA AA AAAAA AAAA", shape), ("B4", "BBBB BBBB BBBB BBBBBBB BBBBBB BBBBB BBBB BBB BB BBB", shape), arrow);

            flowchart.DrawFlowchart();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var elements = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='polygon']");
            Assert.Equal("265.5,151.8 265.5,114.2 234.5,114.2 234.5,151.8", elements[0].Attributes[0].Value);
            Assert.Equal("473,151.8 473,114.2 427,114.2 427,151.8", elements[1].Attributes[0].Value);
            Assert.Equal("309,301.8 309,264.2 191,264.2 191,301.8", elements[2].Attributes[0].Value);
            Assert.Equal("561,310.3 561,255.7 339,255.7 339,310.3", elements[3].Attributes[0].Value);
            Assert.Equal("377.25,468.8 377.25,397.2 122.75,397.2 122.75,468.8", elements[4].Attributes[0].Value);
            Assert.Equal("580.5,468.8 580.5,397.2 319.5,397.2 319.5,468.8", elements[5].Attributes[0].Value);

            var ellipses = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='path']");
            Assert.Equal("M 235,113 C 210,113 210,153 235,153", ellipses[0].Attributes[0].Value);
            Assert.Equal("M 265,113 C 290,113 290,153 265,153", ellipses[1].Attributes[0].Value);
            Assert.Equal("M 427.5,113 C 402.5,113 402.5,153 427.5,153", ellipses[2].Attributes[0].Value);
            Assert.Equal("M 472.5,113 C 497.5,113 497.5,153 472.5,153", ellipses[3].Attributes[0].Value);
            Assert.Equal("M 191.5,263 C 166.5,263 166.5,303 191.5,303", ellipses[4].Attributes[0].Value);
            Assert.Equal("M 308.5,263 C 333.5,263 333.5,303 308.5,303", ellipses[5].Attributes[0].Value);

            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");
            Assert.Equal("245", texts[0].Attributes[0].Value);
            Assert.Equal("137", texts[0].Attributes[1].Value);
            Assert.Equal("A", texts[0].InnerText);

            Assert.Equal("437.5", texts[1].Attributes[0].Value);
            Assert.Equal("137", texts[1].Attributes[1].Value);
            Assert.Equal("BB", texts[1].InnerText);

            Assert.Equal("201.5", texts[2].Attributes[0].Value);
            Assert.Equal("287", texts[2].Attributes[1].Value);
            Assert.Equal("AAAAAAAA", texts[2].InnerText);

            Assert.Equal("349.5", texts[3].Attributes[0].Value);
            Assert.Equal("278.5", texts[3].Attributes[1].Value);
            Assert.Equal("BBB BBBBBB BBBBBBBBBBBB BB", texts[3].InnerText);

            Assert.Equal("133.25", texts[4].Attributes[0].Value);
            Assert.Equal("420", texts[4].Attributes[1].Value);
            Assert.Equal("AAA AAAAAA A AAAAAAA A AA AAAAAAAAA AA AAAAA AAAA", texts[4].InnerText);

            Assert.Equal("330", texts[5].Attributes[0].Value);
            Assert.Equal("420", texts[5].Attributes[1].Value);
            Assert.Equal("BBBB BBBB BBBBBBBBBBB BBBBBB BBBBBBBBB BBB BB BBB", texts[5].InnerText);
        }

        [Fact]
        public void ShapeSubroutineWorks()
        {
            var stream = new MemoryStream();
            Writer.CreateWriter(stream);
            string shape = "Subroutine";
            var flowchart = new Flowchart("LeftRight", stream);

            flowchart.AddPair(("A", "A", shape), ("B", "BB", shape), arrow);
            flowchart.AddPair(("A2", "AAAAAAAA", shape), ("B2", "BBB BBBBBB BBBBBB BBBBBB BB", shape), arrow);
            flowchart.AddPair(("A4", "AAA AAAAAA A A AAAAAA A AA AAAA AAAAA AA AAAAA AAAA", shape), ("B4", "BBBB BBBB BBBB BBBBBBB BBBBBB BBBBB BBBB BBB BB BBB", shape), arrow);

            flowchart.DrawFlowchart();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var elements = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='polygon']");
            Assert.Equal("265,113 265,153 235,153 235,113 228,113 228,153 272,153 272,113 228,113 228,153 272,153 272,113 228,113", elements[0].Attributes[0].Value);
            Assert.Equal("472.5,113 472.5,153 427.5,153 427.5,113 420.5,113 420.5,153 479.5,153 479.5,113 420.5,113 420.5,153 479.5,153 479.5,113 420.5,113", elements[1].Attributes[0].Value);
            Assert.Equal("308.5,263 308.5,303 191.5,303 191.5,263 184.5,263 184.5,303 315.5,303 315.5,263 184.5,263 184.5,303 315.5,303 315.5,263 184.5,263", elements[2].Attributes[0].Value);
            Assert.Equal("560.5,254.5 560.5,311.5 339.5,311.5 339.5,254.5 332.5,254.5 332.5,311.5 567.5,311.5 567.5,254.5 332.5,254.5 332.5,311.5 567.5,311.5 567.5,254.5 332.5,254.5", elements[3].Attributes[0].Value);
            Assert.Equal("376.75,396 376.75,470 123.25,470 123.25,396 116.25,396 116.25,470 383.75,470 383.75,396 116.25,396 116.25,470 383.75,470 383.75,396 116.25,396", elements[4].Attributes[0].Value);
            Assert.Equal("580,396 580,470 320,470 320,396 313,396 313,470 587,470 587,396 313,396 313,470 587,470 587,396 313,396", elements[5].Attributes[0].Value);

            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");
            Assert.Equal("245", texts[0].Attributes[0].Value);
            Assert.Equal("137", texts[0].Attributes[1].Value);
            Assert.Equal("A", texts[0].InnerText);

            Assert.Equal("437.5", texts[1].Attributes[0].Value);
            Assert.Equal("137", texts[1].Attributes[1].Value);
            Assert.Equal("BB", texts[1].InnerText);

            Assert.Equal("201.5", texts[2].Attributes[0].Value);
            Assert.Equal("287", texts[2].Attributes[1].Value);
            Assert.Equal("AAAAAAAA", texts[2].InnerText);

            Assert.Equal("349.5", texts[3].Attributes[0].Value);
            Assert.Equal("278.5", texts[3].Attributes[1].Value);
            Assert.Equal("BBB BBBBBB BBBBBBBBBBBB BB", texts[3].InnerText);

            Assert.Equal("133.25", texts[4].Attributes[0].Value);
            Assert.Equal("420", texts[4].Attributes[1].Value);
            Assert.Equal("AAA AAAAAA A AAAAAAA A AA AAAAAAAAA AA AAAAA AAAA", texts[4].InnerText);

            Assert.Equal("330", texts[5].Attributes[0].Value);
            Assert.Equal("420", texts[5].Attributes[1].Value);
            Assert.Equal("BBBB BBBB BBBBBBBBBBB BBBBBB BBBBBBBBB BBB BB BBB", texts[5].InnerText);
        }

        [Fact]
        public void ShapeTrapezoidAndTrapezoidAltWorks()
        {
            var stream = new MemoryStream();
            Writer.CreateWriter(stream);
            string shape1 = "Trapezoid";
            string shape2 = "TrapezoidAlt";
            var flowchart = new Flowchart("LeftRight", stream);

            flowchart.AddPair(("A", "A", shape1), ("B", "BB", shape2), arrow);
            flowchart.AddPair(("A2", "AAAAAAAA", shape1), ("B2", "BBB BBBBBB BBBBBB BBBBBB BB", shape2), arrow);
            flowchart.AddPair(("A4", "AAA AAAAAA A A AAAAAA A AA AAAA AAAAA AA AAAAA AAAA", shape1), ("B4", "BBBB BBBB BBBB BBBBBBB BBBBBB BBBBB BBBB BBB BB BBB", shape2), arrow);

            flowchart.DrawFlowchart();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            var elements = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='polygon']");
            Assert.Equal("265,113 285,153 215,153 235,113", elements[0].Attributes[0].Value);
            Assert.Equal("492.5,113 472.5,153 427.5,153 407.5,113", elements[1].Attributes[0].Value);
            Assert.Equal("308.5,263 328.5,303 171.5,303 191.5,263", elements[2].Attributes[0].Value);
            Assert.Equal("588.7842712474619,254.5 560.5,311.5 339.5,311.5 311.2157287525381,254.5", elements[3].Attributes[0].Value);
            Assert.Equal("376.75,396 411.3910161513775,470 88.60898384862246,470 123.25,396", elements[4].Attributes[0].Value);
            Assert.Equal("614.6410161513776,396 580,470 320,470 285.3589838486225,396", elements[5].Attributes[0].Value);

            var texts = xmlDoc.SelectNodes("/*[name()='svg']/*[name()='text']");
            Assert.Equal("245", texts[0].Attributes[0].Value);
            Assert.Equal("137", texts[0].Attributes[1].Value);
            Assert.Equal("A", texts[0].InnerText);

            Assert.Equal("437.5", texts[1].Attributes[0].Value);
            Assert.Equal("137", texts[1].Attributes[1].Value);
            Assert.Equal("BB", texts[1].InnerText);

            Assert.Equal("201.5", texts[2].Attributes[0].Value);
            Assert.Equal("287", texts[2].Attributes[1].Value);
            Assert.Equal("AAAAAAAA", texts[2].InnerText);

            Assert.Equal("349.5", texts[3].Attributes[0].Value);
            Assert.Equal("278.5", texts[3].Attributes[1].Value);
            Assert.Equal("BBB BBBBBB BBBBBBBBBBBB BB", texts[3].InnerText);

            Assert.Equal("133.25", texts[4].Attributes[0].Value);
            Assert.Equal("420", texts[4].Attributes[1].Value);
            Assert.Equal("AAA AAAAAA A AAAAAAA A AA AAAAAAAAA AA AAAAA AAAA", texts[4].InnerText);

            Assert.Equal("330", texts[5].Attributes[0].Value);
            Assert.Equal("420", texts[5].Attributes[1].Value);
            Assert.Equal("BBBB BBBB BBBBBBBBBBB BBBBBB BBBBBBBBB BBB BB BBB", texts[5].InnerText);
        }

    }
}