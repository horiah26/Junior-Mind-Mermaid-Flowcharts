namespace Flowcharts
{
    class Program
    {
        static void Main()
        {
            string fileName = "test";
            string path = @"D:\Code\OOP2\Flowcharts\Flowcharts\bin\Debug\";

            var flowchart = new Flowchart("DownTop", fileName, path);

            flowchart.AddPair(("A", "Banner"), ("Banner das fasf asfa sfafsd fsdfa dsafgwry wehdfffaf", "Banner"));
            flowchart.AddPair(("AB", "Banner"), ("Banner 3", "Banner"));
            flowchart.AddPair(("ABC", "Banner"), ("Rhombh dfh dhdsfhth dgs hgdus 4", "Banner"));
            flowchart.AddPair(("ABCD", "Banner"), ("Banners 4", "Banner"));
            flowchart.AddPair(("ABCDEF", "Banner"), ("Rhombjhd jhdss gfhnygtikyilgjgdf dxgfh dtju fjsus d4", "Banner"));
            flowchart.AddPair(("ABCDEFG", "Banner"), ("Circldsge hsdah sah 5etrs hdrs gs  df4", "Banner"));
            flowchart.AddPair(("abcdefg", "Banner"), ("Circle hsdah sahasg 5etrs hdrs gs  df4", "Banner"));
            flowchart.AddPair(("ABCDda da sdas avc sdfafa sdfcawda sfdas afEFGHI", "Banner"), ("Circle hsdagaah sah 5etrs hdrs gs  df4", "Banner"));
            flowchart.AddPair(("ABCDEfasf a afasf saf sagvfsdgvree bs bsvb s aFGHIJ", "Banner"), ("Circle hsdaaah sah 5etrs hdrs gs  df4", "Banner"));
            flowchart.AddPair(("ABCDsdg a dsgrsgad vsdfg wegasv dsavaEFGHIJK", "Banner"), ("Circle hsdah sah agag5etrs hdrs gs  df4", "Banner"));
            flowchart.AddPair(("ABCDEFGHIJKL", "Banner"), ("Circle hasfsdah sah 5etrs hdrs gs  df4", "Banner"));

            flowchart.Draw();
        }
    }
}