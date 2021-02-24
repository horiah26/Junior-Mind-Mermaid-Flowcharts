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

            flowchart.AddPair(("A", "Banner"), ("Banner das fasf asfa sfafsd fsdfa dsafgwry wehdfffaf", "Banner"));
            flowchart.AddPair(("AB", "Banner"), ("Banner 3", "Banner"));
            flowchart.AddPair(("ABC", "Banner"), ("Rhombh dfh dhdsfhth dgs hgdus 4", "Banner"));
            flowchart.AddPair(("ABCD", "Banner"), ("Banners 4", "Banner"));

            flowchart.AddPair(("abcd", "Banner"), ("Banner das fasf assfa sfafsdg sdhrh fddh szsdd fsdfa dsafgwry wehdfffaf", "Banner"));
            flowchart.AddPair(("abcde", "Banner"), ("gasfg afgs dhf hdshcvmghklguf  3", "Banner"));
            flowchart.AddPair(("abcdef", "Banner"), ("Rhombjhd jhdss gfhnygtikyilgjgdf dxgfh dtju fjsus d4", "Banner"));
            flowchart.AddPair(("abcdefg", "Banner"), ("Banner hsdah sah 5etrs hdrs gs  df4", "Banner"));

            flowchart.Draw();
        }
    }
}