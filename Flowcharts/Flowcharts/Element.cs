using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Flowcharts
{
    public class Element
    {
        public (double x, double y) In;
        public (double x, double y) Out;
        public (double x, double y) BackArrowLeft;
        public (double x, double y) BackArrowRight;
        public IOrientation Orientation { get; private set; }
        public Type ShapeType { get; private set; }
        public string Text { get; private set; }
        public string Key { get; private set; }

        public List<Element> parentElements = new List<Element> { };
        public List<Element> childElements = new List<Element> { };

        public int Column { get; set; }
        public int Row { get; set; }

        public Element(string Key, string Text, string shapeName)
        {
            TextOperations.TextLengthWithinLimit(Text);

            ShapeType = Type.GetType("Flowcharts.Shape" + shapeName);
            this.Text = Text;
            Orientation = StaticOrientation.Orientation;
            this.Key = Key;
        }

        public Element(Element element)
        {            
            In = element.In;
            Out = element.Out;
            BackArrowLeft = element.BackArrowLeft;
            BackArrowRight = element.BackArrowRight;
            Text = element.Text;
            Key = element.Key;
            Orientation = element.Orientation;
            parentElements = element.parentElements;
            childElements = element.childElements;
            Column = element.Column;
            Row = element.Row;
            ShapeType = element.ShapeType;
        }

        public void AddParent(Element previous)
        {
            parentElements.Add(previous);
            Column = parentElements.Max(x => x.Column) + 1;
        }

        public void AddChild(Element next)
        {
            childElements.Add(next);
        }

        public void Draw(int Columns, int Rows)
        {
            Orientation.Initialize(Column, Row, Columns, Rows);

            var IO = ElementOperations.Draw(Text, ShapeType);

            In = IO.In;
            Out = IO.Out;

            BackArrowLeft = IO.BackArrowLeft;
            BackArrowRight = IO.BackArrowRight;
        }
    }
}