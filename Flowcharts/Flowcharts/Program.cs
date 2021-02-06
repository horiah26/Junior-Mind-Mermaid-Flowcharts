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
            Flowchart flowchart = new Flowchart("TopDown", "test");

            flowchart.AddPair(("A", "Rectangle"), ("Bqwqfq qf fwe f3 fgsgbg ", "Rectangle"), "J");
            flowchart.AddPair(("A", "Rectangle"), (" dsgsd vdf sg sg sfg tedb sasfsag sdgf D", "Rectangle"), "A to B");
            flowchart.AddPair(("E gjd jfgj djfdj dfhjdg", "Rectangle"), (" jfjfhj fd hkgfkh fj gfd jhfF", "Rectangle"), "A to B gaghsdg astastwe");
            flowchart.AddPair(("Gjfdj fgjyj fgjd fjgfjdfjgfjfg", "Rectangle"), ("Hgj fjfj fyjdyfjyj dhj", "Rectangle"), "A to B gaghsdg astastwe weyweryer ");
            flowchart.AddPair(("Ikfkufdn gfjhyfjd jhfjyj dfnyn dn", "Rectangle"), ("Jgfjd mhfdyfd gffny", "Rectangle"), "A to B gaghsdg astas twe weywe ryer  agaseg  kf");
            flowchart.AddPair(("Kfhfg fgjfg", "Rectangle"), ("jfdjdf fgjd jyf djgkighifL", "Rectangle"), "A to B gaghsdg as tastwe wey eryer  agaseg t rju 4 wegfsgf kf");


            flowchart.Draw();
        }
    }
}