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
    } 
}