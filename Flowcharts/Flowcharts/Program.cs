using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Flowcharts
{
    class Program
    {
        static void Main()
        {
            var flowchart = new Flowchart("test");
            flowchart.AddPair("A", "B");
            flowchart.AddPair("A", "C");
            flowchart.AddPair("A", "D");
            flowchart.AddPair("B", "ER");

            flowchart.AddPair("B", " sadas dcasdqaedaw asdcasdasedwa sadas aeda sdfa a");
            flowchart.AddPair("D", " sadas dcasdqaedaw asdcasdasedwa sadas aeda sdfa a");
            flowchart.AddPair(" sadas dcasdqaedaw asdcasdasedwa sadas aeda sdfa a", "E");
            flowchart.AddPair(" sadas dcasdqaedaw asdcasdasedwa sadas aeda sdfa a", "F");


            //flowchart.AddPair(" sadas dcasdqaedaw asdcasdasedwa sadas aeda sdfa a", "eq2");
            flowchart.AddPair("F", "eq");
            flowchart.AddPair("F", "eq2");
            flowchart.AddPair("F", "eq3");
            flowchart.AddPair(" sadas dcasdqaedaw asdcasdasedwa sadas aeda sdfa a", "G");
            flowchart.AddPair("G", "da");
            flowchart.AddPair("G", "lol");
            flowchart.AddPair("G", "eq");
            flowchart.AddPair("G", "lol2");
            flowchart.AddPair("G", "eq2");
            flowchart.AddPair("newA", "newB");

            flowchart.AddPair("newB", "S");
            flowchart.AddPair("newB", "G");
            flowchart.AddPair("newE", "q");
            flowchart.AddPair("newE", "qw");
            flowchart.AddPair("newE", "qww");
            flowchart.AddPair("newE", "newB");
            flowchart.AddPair("q", "S");
                 

            flowchart.Draw();

        }
    }
}