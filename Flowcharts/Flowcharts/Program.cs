using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Flowcharts
{
    class Program
    {
        static void Main()
        {
            string fileName = "test";
            //string path = @"D:\Code\OOP2\Flowcharts\Flowcharts\bin\Debug\";

            var flowchart = new Flowchart("LeftRight", fileName);

            flowchart.AddPair(("Rhombus", "Rhombus"), ("Rhombus 2", "Rhombus"), "Rhombus to rhombus");
            flowchart.AddPair(("Circle", "Circle"), ("Rhombus 2", "Rhombus"), "Circle to rhombus");
            flowchart.AddPair(("Rectangle", "Rectangle"), ("Rhombus 2", "Rhombus"), "Rectangle to rhombus");

            flowchart.Draw();
        }
    }
}