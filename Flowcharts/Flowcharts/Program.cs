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
            Flowchart flowchart = new Flowchart("DownTop", "test");

            flowchart.AddPair(("A", "Rhombus"), ("B", "Rhombus"), "J");
            flowchart.AddPair(("ABC", "Rhombus"), ("ABCa", "Rhombus"), "J");
            flowchart.AddPair(("abcd", "Rhombus"), ("ABCasgg", "Rhombus"), "J");
            flowchart.AddPair(("abcde", "Rhombus"), ("ABCashsa", "Rhombus"), "J");
            flowchart.AddPair(("abcdef", "Rhombus"), ("ABC sagasgas saas", "Rhombus"), "J");
            flowchart.AddPair(("abcdefg", "Rhombus"), ("ABC safasg ", "Rhombus"), "J");
            flowchart.AddPair(("abcdefgh", "Rhombus"), (" agaeg ABC", "Rhombus"), "J");
            flowchart.AddPair(("abcdefghi", "Rhombus"), ("ABC agasg af asfa", "Rhombus"), "J");
            flowchart.AddPair(("abcdefghij", "Rhombus"), ("Bfgag ABC af aABCDEFGHI", "Rhombus"), "J");
            flowchart.AddPair(("abcdefghijk", "Rhombus"), ("Basfga af afa ", "Rhombus"), "J");
            flowchart.AddPair(("abcdefghijkl", "Rhombus"), ("Basfas fas faf qaf aw ", "Rhombus"), "J");
            flowchart.AddPair(("Abcdefghijlmnopqrst", "Rhombus"), ("B", "Rhombus"), "J");
            flowchart.AddPair(("abcdefgh asbdeasg safgasf aegsadgx vsadg setSfsad as", "Rhombus"), ("B", "Rhombus"), "J");
            flowchart.AddPair(("Se deschide programul si se uita la setari", "Rhombus"), ("Agsasag sdga adg", "Rhombus"), "J");
            //flowchart.AddPair(("Q", "Rectangle"), ("Cbabf9as", "Circle"), "J");
            //flowchart.AddPair(("A", "Rectangle"), (" dsgsd vdf sfsag sdgf D", "Rectangle"), "A to B");
            //flowchart.AddPair(("E gjd jfgj djfdj dfhjdg", "Circle"), (" jfjfhj fd hkgfkh fj gfd jhfF", "Rectangle"), "A to B gaghsdg astastwe");
            //flowchart.AddPair(("C", "Rectangle"), ("Hgj fjfj fdas dfsb adf d dgsbdtbds sdfb ds fas fd dsb syjdyfjyj dhj", "Rectangle"), "A to B gaghsdg astastwe weyweryer ");
            //flowchart.AddPair(("Ikfkufdn gfjhyfjd jhfjyj dfnyn dn", "Circle"), ("Jgfjd dgasbaf fabfrg hewt dfsggrget dfsggeth gdfsr dergsab dfsgrb mhfdyfd gffny", "Rectangle"), "A to B gaghsdg astas twe weywe ryer  agaseg  kf");
            //flowchart.AddPair(("Kfhfg fgjfg", "Circle"), ("jfdjdf fgjd jyf djgkighifL", "Rectangle"), "A to B gaghsdg as tastwe wey eryer  agaseg t rju 4 wegfsgf kf");

            flowchart.Draw();
        }
    }
}