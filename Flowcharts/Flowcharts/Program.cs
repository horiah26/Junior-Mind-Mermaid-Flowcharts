namespace Flowcharts
{
    class Program
    {
        static void Main()
        {
            string fileName = "test";
            //string path = @"D:\Code\OOP2\Flowcharts\Flowcharts\bin\Debug\";

            var flowchart = new Flowchart("TopDown", fileName);

            flowchart.AddPair(("A", "Cylinder"), ("Cylinder das fasf asfa sfafsd fsdfa dsafgwry wehdfffaf", "Cylinder"));
            flowchart.AddPair(("AB", "Cylinder"), ("Cylinder 3", "Cylinder"));
            flowchart.AddPair(("ABC", "Cylinder"), ("Rhombh dfh dhdsfhth dgs hgdus 4", "Cylinder"));
            flowchart.AddPair(("ABC 41 234 255 34724 dg nfhmndf ngdn fgn fdn fn fdhn gsn sdnsf rh gh ss D", "Cylinder"), ("Cylinders 4", "Cylinder"));
            flowchart.AddPair(("ABCDEF", "Cylinder"), ("Rhombjhd jhdss gfhnygtikyilgjgdf dxgfh dtju fjsus d4", "Cylinder"));
            flowchart.AddPair(("ABCDEFG", "Cylinder"), ("Circldsge hsdah sah 5etrs hdrs gs  df4", "Cylinder"));
            flowchart.AddPair(("abcdefg", "Cylinder"), ("Circle hsdah sahasg 5etrs hdrs gs  df4", "Cylinder"));
            flowchart.AddPair(("ABCDda da sdas avc  afEFGHI", "Cylinder"), ("Circle hsdagaah sah 5etrs hdrs gs  df4", "Cylinder"));
            flowchart.AddPair(("ABCDEfasf a afasf saf sagvfsdgvree bs bsvb s aFGHIJ", "Cylinder"), ("Circle hsdaaah sah 5etrs hdrs gs  df4", "Cylinder"));
            flowchart.AddPair(("ABCDsdg a dsgrsgad vsdfg wegasv dsavaEFGHIJK", "Cylinder"), ("Circle hsdah sah agag5etrs hdrs gs  df4", "Cylinder"));
            flowchart.AddPair(("ABCDEFGHIJKL", "Cylinder"), ("Circle hasfsdah sah 5etrs hdrs gs  df4", "Cylinder"));

            flowchart.Draw();
        }
    }
}