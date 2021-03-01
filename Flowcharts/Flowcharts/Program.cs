namespace Flowcharts
{
    class Program
    {
        static void Main()
        {
            string fileName = "test";
            //string path = @"D:\Code\OOP2\Flowcharts\Flowcharts\bin\Debug\";

            var flowchart = new Flowchart("LeftRight", fileName);

            flowchart.AddPair(("A", "RoundedRectangle"), ("RoundedRectangle das fasf asfa sfafsd fsdfa dsafgwry wehdfffaf", "RoundedRectangle"), "asfabvas ");
            flowchart.AddPair(("AB", "RoundedRectangle"), ("RoundedRectangle 3", "RoundedRectangle"));
            flowchart.AddPair(("ABC", "RoundedRectangle"), ("Rhombh dfh dhdsfhth dgs hgdus 4", "RoundedRectangle"));
            flowchart.AddPair(("ABC 41 234 255 34724 dg nfhmndf ngdn fgn fdn fn fdhn gsn sdnsf rh gh ss D", "RoundedRectangle"), ("RoundedRectangles 4", "RoundedRectangle"));
            flowchart.AddPair(("ABCDEF", "RoundedRectangle"), ("Rhombjhd jhdss gfhnygtikyilgjgdf dxgfh dtju fjsus d4", "RoundedRectangle"));
            flowchart.AddPair(("ABCDEFG", "RoundedRectangle"), ("Circldsge hsdah sah 5etrs hdrs gs  df4", "RoundedRectangle"));
            flowchart.AddPair(("abcdefg", "RoundedRectangle"), ("Circle hsdah sahasg 5etrs hdrs gs  df4", "RoundedRectangle"));
            flowchart.AddPair(("ABCDda da sdas avc  afEFGHI", "RoundedRectangle"), ("Circle hsdagaah sah 5etrs hdrs gs  df4", "RoundedRectangle"));
            flowchart.AddPair(("ABCDEfasf a afasf saf sagvfsdgvree bs bsvb s aFGHIJ", "RoundedRectangle"), ("Circle hsdaaah sah 5etrs hdrs gs  df4", "RoundedRectangle"));
            flowchart.AddPair(("ABCDsdg a dsgrsgad vsdfg wegasv dsavaEFGHIJK", "RoundedRectangle"), ("Circle hsdah sah agag5etrs hdrs gs  df4", "RoundedRectangle"));
            flowchart.AddPair(("ABCDEFGHIJKL", "RoundedRectangle"), ("Circle hasfsdah sah 5etrs hdrs gs  df4", "RoundedRectangle"));

            flowchart.Draw();
        }
    }
}