namespace Flowcharts
{
    class Program
    {
        static void Main()
        {
            string fileName = "test";
            string path = @"D:\Code\OOP2\Flowcharts\Flowcharts\bin\Debug\";

            var flowchart = new Flowchart("DownTop", fileName, path);

            flowchart.AddPair(("A", "Hexagon"), ("Rectangle das fasf asfa sfafsd fsdfa dsafgwry wehdfffaf", "Rectangle"));
            flowchart.AddPair(("AB", "Hexagon"), ("Rectangle 3", "Rectangle"));
            flowchart.AddPair(("ABC", "Hexagon"), ("Rhombh dfh dhdsfhth dgs hgdus 4", "Rectangle"));
            flowchart.AddPair(("ABCD", "Hexagon"), ("Rectangles 4", "Rectangle"));
            flowchart.AddPair(("ABCDEF", "Hexagon"), ("Rhombjhd jhdss gfhnygtikyilgjgdf dxgfh dtju fjsus d4", "Rectangle"));
            flowchart.AddPair(("ABCDEFG", "Hexagon"), ("Circldsge hsdah sah 5etrs hdrs gs  df4", "Rectangle"));
            flowchart.AddPair(("abcdefg", "Hexagon"), ("Circle hsdah sahasg 5etrs hdrs gs  df4", "Rectangle"));
            flowchart.AddPair(("ABCDda da sdas avc sdfafa sdfcawda sfdas afEFGHI", "Rectangle"), ("Circle hsdagaah sah 5etrs hdrs gs  df4", "Rectangle"));
            flowchart.AddPair(("ABCDEfasf a afasf saf sagvfsdgvree bs bsvb s aFGHIJ", "Rectangle"), ("Circle hsdaaah sah 5etrs hdrs gs  df4", "Rectangle"));
            flowchart.AddPair(("ABCDsdg a dsgrsgad vsdfg wegasv dsavaEFGHIJK", "Rectangle"), ("Circle hsdah sah agag5etrs hdrs gs  df4", "Rectangle"));
            flowchart.AddPair(("ABCDEFGHIJKL", "Hexagon"), ("Circle hasfsdah sah 5etrs hdrs gs  df4", "Rectangle"));

            flowchart.Draw();
        }
    }
}