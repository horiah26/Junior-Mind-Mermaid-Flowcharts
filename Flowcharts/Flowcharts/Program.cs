namespace Flowcharts
{
    class Program
    {
        static void Main()
        {
            string fileName = "test";
            //string path = @"D:\Code\OOP2\Flowcharts\Flowcharts\bin\Debug\";

            var flowchart = new Flowchart("TopDown", fileName);

            flowchart.AddPair(("A", "Stadium"), ("Stadium das fasf asfa sfafsd fsdfa dsafgwry wehdfffaf", "Stadium"), "asfabvas ");
            flowchart.AddPair(("AB", "Stadium"), ("Stadium 3", "Stadium"));
            flowchart.AddPair(("ABC", "Stadium"), ("Rhombh dfh dhdsfhth dgs hgdus 4", "Stadium"));
            flowchart.AddPair(("ABC 41 234 255 34724 dg nfhmndf ngdn fgn fdn fn fdhn gsn sdnsf rh gh ss D", "Stadium"), ("Stadiums 4", "Stadium"));
            flowchart.AddPair(("ABCDEF", "Stadium"), ("Rhombjhd jhdss gfhnygtikyilgjgdf dxgfh dtju fjsus d4", "Stadium"));
            flowchart.AddPair(("ABCDEFG", "Stadium"), ("Circldsge hsdah sah 5etrs hdrs gs  df4", "Stadium"));
            flowchart.AddPair(("abcdefg", "Stadium"), ("Circle hsdah sahasg 5etrs hdrs gs  df4", "Stadium"));
            flowchart.AddPair(("ABCDda da sdas avc  afEFGHI", "Stadium"), ("Circle hsdagaah sah 5etrs hdrs gs  df4", "Stadium"));
            flowchart.AddPair(("ABCDEfasf a afasf saf sagvfsdgvree bs bsvb s aFGHIJ", "Stadium"), ("Circle hsdaaah sah 5etrs hdrs gs  df4", "Stadium"));
            flowchart.AddPair(("ABCDsdg a dsgrsgad vsdfg wegasv dsavaEFGHIJK", "Stadium"), ("Circle hsdah sah agag5etrs hdrs gs  df4", "Stadium"));
            flowchart.AddPair(("ABCDEFGHIJKL", "Stadium"), ("Circle hasfsdah sah 5etrs hdrs gs  df4", "Stadium"));

            flowchart.Draw();
        }
    }
}