using System;
using System.IO;
using System.Xml;
using Xunit;

namespace Flowcharts.Tests
{
    public class GridTests
    {

        [Fact]
        public void CanCreateGrid()
        {
            var grid = new Grid();
            Assert.NotNull(grid);
        }

        [Fact]
        public void CanAddElementInPositionZero()
        {
            XmlWriter xmlWriter;
            MemoryStream MemoryStream = new MemoryStream();
            xmlWriter = XmlWriter.Create(MemoryStream);
            var element = new Element(xmlWriter, "a", "LR");

            var grid = new Grid();

            grid.Add(element, 0, 0);
            
            Assert.Equal(element,grid.ElementAt(0,0));
        }

        [Fact]
        public void CanAddElementInSpecificPosition()
        {
            XmlWriter xmlWriter;
            MemoryStream MemoryStream = new MemoryStream();
            xmlWriter = XmlWriter.Create(MemoryStream);

            var element = new Element(xmlWriter, "a", "LR");

            var grid = new Grid();

            grid.Add(element, 2, 3);

            Assert.Equal(element, grid.ElementAt(2, 3));
        }

        [Fact]
        public void CanAddMultipleElements()
        {
            XmlWriter xmlWriter;
            MemoryStream MemoryStream = new MemoryStream();
            xmlWriter = XmlWriter.Create(MemoryStream);

            var elementA = new Element(xmlWriter, "a", "LR");
            var elementB = new Element(xmlWriter, "b", "LR");
            var elementC = new Element(xmlWriter, "c", "LR");
            var elementD = new Element(xmlWriter, "d", "LR");

            var grid = new Grid();

            grid.Add(elementA, 0, 0);
            grid.Add(elementB, 0, 1);
            grid.Add(elementC, 1, 0);
            grid.Add(elementD, 2, 2);

            Assert.Equal(elementA, grid.ElementAt(0, 0));
            Assert.Equal(elementB, grid.ElementAt(0, 1));
            Assert.Equal(elementC, grid.ElementAt(1, 0));
            Assert.Equal(elementD, grid.ElementAt(2, 2));
        }

        [Fact]
        public void GridResizesOverInitial10x10()
        {
            XmlWriter xmlWriter;
            MemoryStream MemoryStream = new MemoryStream();
            xmlWriter = XmlWriter.Create(MemoryStream);

            var element = new Element(xmlWriter, "a", "LR");

            var grid = new Grid();

            Assert.Equal((10,10), grid.Dimensions());

            grid.Add(element, 12, 11);

            Assert.Equal(element, grid.ElementAt(12, 11));
            Assert.Equal((13, 12), grid.Dimensions());
        }


        [Fact]
        public void GridResizesOnlyColumns()
        {
            XmlWriter xmlWriter;
            MemoryStream MemoryStream = new MemoryStream();
            xmlWriter = XmlWriter.Create(MemoryStream);

            var element = new Element(xmlWriter, "a", "LR");

            var grid = new Grid();

            Assert.Equal((10, 10), grid.Dimensions());

            grid.Add(element, 1, 17);

            Assert.Equal(element, grid.ElementAt(1, 17));
            Assert.Equal((10, 18), grid.Dimensions());
        }

        [Fact]
        public void GridResizesOnlyRows()
        {
            XmlWriter xmlWriter;
            MemoryStream MemoryStream = new MemoryStream();
            xmlWriter = XmlWriter.Create(MemoryStream);

            var element = new Element(xmlWriter, "a", "LR");

            var grid = new Grid();

            Assert.Equal((10, 10), grid.Dimensions());

            grid.Add(element, 13, 5);

            Assert.Equal(element, grid.ElementAt(13, 5));
            Assert.Equal((14, 10), grid.Dimensions());
        }

        [Fact]
        public void CanLowerColumnFromPosition()
        {
            XmlWriter xmlWriter;
            MemoryStream MemoryStream = new MemoryStream();
            xmlWriter = XmlWriter.Create(MemoryStream);

            var elementA = new Element(xmlWriter, "a", "LR");
            var elementB = new Element(xmlWriter, "b", "LR");

            var grid = new Grid();

            grid.Add(elementA, 0, 0);
            grid.Add(elementB, 1, 0);

            grid.LowerColumnInGrid(0, 0, 2);

            Assert.Equal(elementA, grid.ElementAt(2, 0));
            Assert.Equal(elementB, grid.ElementAt(3, 0));
        }

        [Fact]
        public void CanLowerColumnFromPositionStartingAtACertainPoint()
        {
            XmlWriter xmlWriter;
            MemoryStream MemoryStream = new MemoryStream();
            xmlWriter = XmlWriter.Create(MemoryStream);

            var elementA = new Element(xmlWriter, "a", "LR");
            var elementB = new Element(xmlWriter, "b", "LR");

            var grid = new Grid();

            grid.Add(elementA, 0, 3);
            grid.Add(elementB, 1, 3);

            grid.LowerColumnInGrid(1, 3, 1);

            Assert.Equal(elementA, grid.ElementAt(0, 3));
            Assert.Equal(elementB, grid.ElementAt(2, 3));
        }

        [Fact]
        public void ThrowsExceptionIfAddingElementAtCoordinatesOfExistingElement()
        {
            XmlWriter xmlWriter;
            MemoryStream MemoryStream = new MemoryStream();
            xmlWriter = XmlWriter.Create(MemoryStream);

            var elementA = new Element(xmlWriter, "a", "LR");
            var elementB = new Element(xmlWriter, "b", "LR");

            var grid = new Grid();

            grid.Add(elementA, 1, 1);

            Assert.Throws<InvalidOperationException>(() => grid.Add(elementB, 1, 1));
        }       
    }
}
