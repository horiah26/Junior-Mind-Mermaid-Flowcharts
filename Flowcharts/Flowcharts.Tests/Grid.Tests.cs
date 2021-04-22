using System;
using System.IO;
using System.Xml;
using Xunit;

namespace Flowcharts.Tests
{
    public class GridTests
    {
        readonly string rectangle = "Rectangle";

        [Fact]
        public void CanCreateGrid()
        {
            var grid = new Grid();
            Assert.NotNull(grid);
        }

        [Fact]
        public void CanAddElementInPositionZero()
        {
            Writer.CreateWriter(new MemoryStream());
            var element = new Element("A", "A", rectangle);
            var grid = new Grid();

            grid.Add(element, 0, 0);

            Assert.Equal(element, grid.ElementArray[0, 0]);
        }

        [Fact]
        public void CanAddElementInSpecificPosition()
        {
            Writer.CreateWriter(new MemoryStream());

            var element = new Element("A", "A", rectangle);

            var grid = new Grid();

            var array = ArrayOperations.AddElement(grid.ElementArray, element, 2, 3);

            Assert.Equal(element, array[2, 3]);
        }

        [Fact]
        public void CanAddMultipleElements()
        {
            Writer.CreateWriter(new MemoryStream());

            var elementA = new Element( "A", "A",rectangle);
            var elementB = new Element( "B", "B",rectangle);
            var elementC = new Element( "C", "C",rectangle);
            var elementD = new Element( "D", "D",rectangle);

            var grid = new Grid();

            grid.Add(elementA, 0, 0);
            grid.Add(elementB, 0, 1);
            grid.Add(elementC, 1, 0);
            grid.Add(elementD, 2, 2);

            Assert.Equal(elementA, grid.ElementArray[0, 0]);
            Assert.Equal(elementB, grid.ElementArray[0, 1]);
            Assert.Equal(elementC, grid.ElementArray[1, 0]);
            Assert.Equal(elementD, grid.ElementArray[2, 2]);
        }

        [Fact]
        public void GridResizesOverInitial10x10()
        {
            Writer.CreateWriter(new MemoryStream());

            var element = new Element("A", "A",rectangle);

            var grid = new Grid(10, 10);

            Assert.Equal(10, grid.ElementArray.GetLength(0));
            Assert.Equal(10, grid.ElementArray.GetLength(1));

            grid.Add(element, 12, 11);

            Assert.Equal(element, grid.ElementArray[12, 11]);

            Assert.Equal(13, grid.ElementArray.GetLength(0));
            Assert.Equal(12, grid.ElementArray.GetLength(1));
        }


        [Fact]
        public void GridResizesOnlyColumns()
        {
            Writer.CreateWriter(new MemoryStream());

            var element = new Element("A", "A", rectangle);

            var grid = new Grid();

            Assert.Equal(1, grid.ElementArray.GetLength(0));
            Assert.Equal(1, grid.ElementArray.GetLength(1));

            grid.Add(element, 1, 17);

            Assert.Equal(element, grid.ElementArray[1, 17]);

            Assert.Equal(2, grid.ElementArray.GetLength(0));
            Assert.Equal(18, grid.ElementArray.GetLength(1));
        }

        [Fact]
        public void GridResizesOnlyRows()
        {
            Writer.CreateWriter(new MemoryStream());

            var element = new Element("A", "A", rectangle);

            var grid = new Grid(10, 10);

            Assert.Equal(10, grid.ElementArray.GetLength(0));
            Assert.Equal(10, grid.ElementArray.GetLength(1));

            grid.Add(element, 13, 5);

            Assert.Equal(element, grid.ElementArray[13, 5]);

            Assert.Equal(14, grid.ElementArray.GetLength(0));
            Assert.Equal(10, grid.ElementArray.GetLength(1));
        }

        [Fact]
        public void CanLowerColumnFromPosition()
        {
            Writer.CreateWriter(new MemoryStream());

            var elementA = new Element("A", "A", rectangle);
            var elementB = new Element("B", "B", rectangle);

            var grid = new Grid(10, 10);

            grid.Add(elementA, 0, 0);
            grid.Add(elementB, 1, 0);

            ArrayOperations.LowerColumns(grid.ElementArray, 0, 0, 2);

            Assert.Equal(elementA, grid.ElementArray[2, 0]);
            Assert.Equal(elementB, grid.ElementArray[3, 0]);
        }

        [Fact]
        public void CanLowerColumnFromPositionStartingAtACertainPoint()
        {
            Writer.CreateWriter(new MemoryStream());

            var elementA = new Element("A", "A", rectangle);
            var elementB = new Element("B", "B", rectangle);

            var grid = new Grid(10, 10);

            grid.Add(elementA, 0, 3);
            grid.Add(elementB, 1, 3);

            ArrayOperations.LowerColumns(grid.ElementArray, 1, 3, 1);

            Assert.Equal(elementA, grid.ElementArray[0, 3]);
            Assert.Equal(elementB, grid.ElementArray[2, 3]);
        }

        [Fact]
        public void ThrowsExceptionIfAddingElementAtpointsOfExistingElement()
        {
            Writer.CreateWriter(new MemoryStream());

            var elementA = new Element("A", "A", rectangle);
            var elementB = new Element("B", "B", rectangle);

            var grid = new Grid(10, 10);

            grid.Add(elementA, 1, 1);

            Assert.Throws<InvalidOperationException>(() => grid.Add(elementB, 1, 1));
        }
    }
}
