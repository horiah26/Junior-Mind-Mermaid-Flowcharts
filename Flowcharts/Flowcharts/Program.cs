namespace Flowcharts
{
    class Program
    {
        static void Main()
        {
            string fileName = "test";
            string path = @"D:\Code\OOP2\Flowcharts\Flowcharts\bin\Debug\";

            var flowchart = new Flowchart("RightLeft", fileName, path);

            flowchart.AddPair(("A", "TrapezoidAlt"), ("TrapezoidAlt das fasf asfa sfafsd fsdfa dsafgwry wehdfffaf", "TrapezoidAlt"));
            flowchart.AddPair(("AB", "TrapezoidAlt"), ("TrapezoidAlt 3", "TrapezoidAlt"));
            flowchart.AddPair(("ABC", "TrapezoidAlt"), ("Rhombh dfh dhdsfhth dgs hgdus 4", "TrapezoidAlt"));
            flowchart.AddPair(("ABCD", "TrapezoidAlt"), ("TrapezoidAlts 4", "TrapezoidAlt"));
            flowchart.AddPair(("ABCDEF", "TrapezoidAlt"), ("Rhombjhd jhdss gfhnygtikyilgjgdf dxgfh dtju fjsus d4", "TrapezoidAlt"));
            flowchart.AddPair(("ABCDEFG", "TrapezoidAlt"), ("Circldsge hsdah sah 5etrs hdrs gs  df4", "TrapezoidAlt"));
            flowchart.AddPair(("abcdefg", "TrapezoidAlt"), ("Circle hsdah sahasg 5etrs hdrs gs  df4", "TrapezoidAlt"));
            flowchart.AddPair(("ABCDda da sdas avc sdfafa sdfcawda sfdas afEFGHI", "TrapezoidAlt"), ("Circle hsdagaah sah 5etrs hdrs gs  df4", "TrapezoidAlt"));
            flowchart.AddPair(("ABCDEfasf a afasf saf sagvfsdgvree bs bsvb s aFGHIJ", "TrapezoidAlt"), ("Circle hsdaaah sah 5etrs hdrs gs  df4", "TrapezoidAlt"));
            flowchart.AddPair(("ABCDsdg a dsgrsgad vsdfg wegasv dsavaEFGHIJK", "TrapezoidAlt"), ("Circle hsdah sah agag5etrs hdrs gs  df4", "TrapezoidAlt"));
            flowchart.AddPair(("ABCDEFGHIJKL", "TrapezoidAlt"), ("Circle hasfsdah sah 5etrs hdrs gs  df4", "TrapezoidAlt"));

            flowchart.Draw();
        }
    }
}