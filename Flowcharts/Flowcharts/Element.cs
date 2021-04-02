﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Flowcharts
{
    public class Element
    {
        public (double x, double y) In;
        public (double x, double y) Out;

        public (double x, double y) BackArrowEntry;

        public IOrientation orientation;

        readonly string orientationName;
        public string shapeString = "Rectangle";

        readonly XmlWriter xmlWriter;
        public string Text { get; private set; }
        public string Key { get; private set; }

        public List<Element> parentElements = new List<Element> { };
        public List<Element> childElements = new List<Element> { };

        public int Column = 0;
        public int Row = 0;

        public Element(XmlWriter xmlWriter, string Text, string orientationName)
        {
            CheckLength(Text);

            this.xmlWriter = xmlWriter;
            this.Text = Text;
            this.orientationName = orientationName;
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

        public void Draw(int columnSize, int rowSize)
        {
            Type orientationType = Type.GetType("Flowcharts.Orientation" + orientationName);
            IOrientation orientation = (IOrientation)Activator.CreateInstance(orientationType);

            orientation.Initialize(Column, Row, columnSize, rowSize);

            this.orientation = orientation;

            var InOut = new DrawnElement(xmlWriter, orientation, Text, shapeString).Draw();

            In = InOut.In;
            Out = InOut.Out;
            BackArrowEntry = InOut.BackArrowEntry;
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