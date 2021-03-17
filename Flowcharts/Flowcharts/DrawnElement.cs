﻿using System;
using System.Xml;

namespace Flowcharts
{
    class DrawnElement
    {
        readonly XmlWriter xmlWriter;
        readonly IOrientation orientation;
        private readonly int distanceFromEdge;
        private readonly int unitLength;
        private readonly int unitHeight;
        double textAlignment;
        readonly string text;
        readonly string shapeString;

        public DrawnElement(XmlWriter xmlWriter, IOrientation orientation, string text, string shapeString) 
        {
            this.orientation = orientation;
            this.text = text;
            this.xmlWriter = xmlWriter;
            this.shapeString = shapeString;

            (distanceFromEdge, unitLength, unitHeight) = new GridSpacing(orientation).GetSpacing();
        }

        public IOPoints Draw()
        {
            string[] lines;

            var textSplitter = new SplitText(text); 
            lines = new SplitText(text).GetLines();

            IOPoints InOut = DrawBox();

            PrepareAndWriteText(lines);

            return InOut;
        }

        public void PrepareAndWriteText(string[] splitLines)
        {
            (int x, int y) fitInBox = (10, 7);
            var (column, row) = orientation.GetColumnRow();

            double xPosition = distanceFromEdge + (column * unitLength + fitInBox.x) + (unitLength - textAlignment) / 2;
            double yPosition = distanceFromEdge + (row * unitHeight + fitInBox.y);

            new WrittenText(xmlWriter, xPosition, yPosition, splitLines).Write();
        }

        public IOPoints DrawBox()
        {
            Type shapeType = Type.GetType("Flowcharts.Shape" + shapeString);
            IShape shape = (IShape)Activator.CreateInstance(shapeType, new object[] { xmlWriter, orientation, text });

            (IOPoints InOut, double textAlignment) = shape.Draw();

            this.textAlignment = textAlignment;
            return InOut;
        }           
    }
}