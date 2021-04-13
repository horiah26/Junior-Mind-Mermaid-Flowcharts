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

        public IOrientation orientation;

        public string shapeName = "Rectangle";
        
        public string Text { get; private set; }
        public string Key { get; private set; }

        public List<Element> parentElements = new List<Element> { };
        public List<Element> childElements = new List<Element> { };

        public int Column = 0;
        public int Row = 0;

        public Element(string Key, string Text, string shapeName)
        {
            CheckLength(Text);

            this.Text = Text;
            orientation = StaticOrientation.Orientation;
            this.Key = Key;
            this.shapeName = shapeName;
        }

        public Element(Element element)
        {
            In = element.In;
            Out = element.Out;
            BackArrowLeft = element.BackArrowLeft;
            BackArrowRight = element.BackArrowRight;
            Text = element.Text;
            Key = element.Key;
            orientation = element.orientation;
            parentElements = element.parentElements;
            childElements = element.childElements;
            Column = element.Column;
            Row = element.Row;
            shapeName = element.shapeName;        
        }

        public void AddParent(Element previous)
        {
            parentElements.Add(previous);
            UpdateColumn();
        }

        public void AddChild(Element next)
        {
            childElements.Add(next);
        }

        public void UpdateColumn()
        {
            var maxPreviousColumn = parentElements.Max(x => x.Column);
            Column = maxPreviousColumn + 1;
        }

        public void Draw(int Columns, int Rows)
        {
            orientation.Initialize(Column, Row, Columns, Rows);

            var IO = new DrawnElement(orientation, Text, shapeName).Draw();

            In = IO.In;
            Out = IO.Out;
            BackArrowLeft = IO.BackArrowLeft;
            BackArrowRight = IO.BackArrowRight;
        }
    

        public int MinColumnOfChildren()
        {
            int minColumn = 0;

            if (childElements.Count != 0)
            {
                minColumn = childElements.Min(x => x.Column);
            }

            return minColumn;
        }

        private void CheckLength(string text)
        {
            int limit = 85;

            if (text.Length > limit)
            {
                throw new ArgumentException("Text length cannot exceed {0} characters" + limit);
            }
        }
    }
}