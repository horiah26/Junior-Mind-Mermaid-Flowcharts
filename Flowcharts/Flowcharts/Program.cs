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
            Flowchart flowchart = new Flowchart("LeftRight", "test");

            flowchart.AddPair(("A", "Rectangle"), ("B", "Circle"), "J");
            flowchart.AddPair(("A", "Rectangle"), ("C", "Circle"), "J");
            flowchart.AddPair(("Q", "Rectangle"), ("Cbabf9as", "Circle"), "J");
            flowchart.AddPair(("A", "Rectangle"), (" dsgsd vdf sfsag sdgf D", "Rectangle"), "A to B");
            flowchart.AddPair(("E gjd jfgj djfdj dfhjdg", "Circle"), (" jfjfhj fd hkgfkh fj gfd jhfF", "Rectangle"), "A to B gaghsdg astastwe");
            flowchart.AddPair(("C", "Rectangle"), ("Hgj fjfj fdas dfsb adf d dgsbdtbds sdfb ds fas fd dsb syjdyfjyj dhj", "Rectangle"), "A to B gaghsdg astastwe weyweryer ");
            flowchart.AddPair(("Ikfkufdn gfjhyfjd jhfjyj dfnyn dn", "Circle"), ("Jgfjd dgasbaf fabfrg hewt dfsggrget dfsggeth gdfsr dergsab dfsgrb mhfdyfd gffny", "Rectangle"), "A to B gaghsdg astas twe weywe ryer  agaseg  kf");
            flowchart.AddPair(("Kfhfg fgjfg", "Circle"), ("jfdjdf fgjd jyf djgkighifL", "Rectangle"), "A to B gaghsdg as tastwe wey eryer  agaseg t rju 4 wegfsgf kf");

            flowchart.Draw();
        }
    }
}