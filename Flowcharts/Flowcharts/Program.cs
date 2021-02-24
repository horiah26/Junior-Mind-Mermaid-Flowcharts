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
            string path = @"D:\Code\OOP2\Flowcharts\Flowcharts\bin\Debug\";

            var flowchart = new Flowchart("DownTop", fileName, path);

            flowchart.AddPair(("A", "Hexagon"), ("Hexagon das fasf asfa sfafsd fsdfa dsafgwry wehdfffaf", "Hexagon"));
            flowchart.AddPair(("AB", "Hexagon"), ("Hexagon 3", "Hexagon"));
            flowchart.AddPair(("ABC", "Hexagon"), ("Rhombh dfh dhdsfhth dgs hgdus 4", "Hexagon"));
            flowchart.AddPair(("ABCD", "Hexagon"), ("Rectangles 4", "Hexagon"));

            flowchart.AddPair(("abcd", "Hexagon"), ("Hexagon das fasf assfa sfafsdg sdhrh fddh szsdd fsdfa dsafgwry wehdfffaf", "Hexagon"));
            flowchart.AddPair(("abcde", "Hexagon"), ("gasfg afgs dhf hdshcvmghklguf  3", "Hexagon"));
            flowchart.AddPair(("abcdef", "Hexagon"), ("Rhombjhd jhdss gfhnygtikyilgjgdf dxgfh dtju fjsus d4", "Hexagon"));
            flowchart.AddPair(("abcdefg", "Hexagon"), ("Circle hsdah sah 5etrs hdrs gs  df4", "Hexagon"));

            flowchart.Draw();
        }
    }
}