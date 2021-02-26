namespace Flowcharts
{
    class Program
    {
        static void Main()
        {
            string fileName = "test";
            string path = @"D:\Code\OOP2\Flowcharts\Flowcharts\bin\Debug\";

            var flowchart = new Flowchart("RightLeft", fileName, path);

            flowchart.AddPair(("A", "ParallelogramAlt"), ("ParallelogramAlt das fasf asfa sfafsd fsdfa dsafgwry wehdfffaf", "ParallelogramAlt"));
            flowchart.AddPair(("AB", "ParallelogramAlt"), ("ParallelogramAlt 3", "ParallelogramAlt"));
            flowchart.AddPair(("ABC", "ParallelogramAlt"), ("Rhombh dfh dhdsfhth dgs hgdus 4", "ParallelogramAlt"));
            flowchart.AddPair(("ABCD", "ParallelogramAlt"), ("ParallelogramAlts 4", "ParallelogramAlt"));
            flowchart.AddPair(("ABCDEF", "ParallelogramAlt"), ("Rhombjhd jhdss gfhnygtikyilgjgdf dxgfh dtju fjsus d4", "ParallelogramAlt"));
            flowchart.AddPair(("ABCDEFG", "ParallelogramAlt"), ("Circldsge hsdah sah 5etrs hdrs gs  df4", "ParallelogramAlt"));
            flowchart.AddPair(("abcdefg", "ParallelogramAlt"), ("Circle hsdah sahasg 5etrs hdrs gs  df4", "ParallelogramAlt"));
            flowchart.AddPair(("ABCDda da sdas avc sdfafa sdfcawda sfdas afEFGHI", "ParallelogramAlt"), ("Circle hsdagaah sah 5etrs hdrs gs  df4", "ParallelogramAlt"));
            flowchart.AddPair(("ABCDEfasf a afasf saf sagvfsdgvree bs bsvb s aFGHIJ", "ParallelogramAlt"), ("Circle hsdaaah sah 5etrs hdrs gs  df4", "ParallelogramAlt"));
            flowchart.AddPair(("ABCDsdg a dsgrsgad vsdfg wegasv dsavaEFGHIJK", "ParallelogramAlt"), ("Circle hsdah sah agag5etrs hdrs gs  df4", "ParallelogramAlt"));
            flowchart.AddPair(("ABCDEFGHIJKL", "ParallelogramAlt"), ("Circle hasfsdah sah 5etrs hdrs gs  df4", "ParallelogramAlt"));

            flowchart.Draw();
        }
    }
}