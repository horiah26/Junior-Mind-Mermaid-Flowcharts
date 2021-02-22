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

            var flowchart = new Flowchart("LeftRight", fileName, path);

            flowchart.AddPair(("D", "Rectangle"), ("Rhombus das fasf asfa sfafsd fsdfa dsafgwry wehdfffaf", "Rectangle"));
            flowchart.AddPair(("AE", "Rectangle"), ("Rhombus 3", "Rectangle"));
            flowchart.AddPair(("ABCDEF", "Rectangle"), ("Rhombh dfh dhdsfhth dgs hgdus 4", "Rectangle"));
            flowchart.AddPair(("ABCDEFG", "Rectangle"), ("Rhombuss 4", "Rectangle"));


            flowchart.AddPair(("abcd", "Rectangle"), ("Rhombus das fasf assfa sfafsdg sdhrh fddh szsdd fsdfa dsafgwry wehdfffaf", "Rectangle"));
            flowchart.AddPair(("abcde", "Rectangle"), ("gasfg afgs dhf hdshcvmghklguf  3", "Rectangle"));
            flowchart.AddPair(("abcdef", "Rectangle"), ("Rhombjhd jhdss gfhnygtikyilgjgdf dxgfh dtju fjsus d4", "Rectangle"));
            flowchart.AddPair(("abcdefg", "Rectangle"), ("Rhombus hsdah sah 5etrs hdrs gs  df4", "Rectangle"));

            flowchart.Draw();
        }
    }
}