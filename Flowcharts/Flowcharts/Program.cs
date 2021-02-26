namespace Flowcharts
{
    class Program
    {
        static void Main()
        {
            string fileName = "test";
            string path = @"D:\Code\OOP2\Flowcharts\Flowcharts\bin\Debug\";

            var flowchart = new Flowchart("DownTop", fileName, path);

            flowchart.AddPair(("A", "Parallelogram"), ("Parallelogram das fasf asfa sfafsd fsdfa dsafgwry wehdfffaf", "Parallelogram"));
            flowchart.AddPair(("AB", "Parallelogram"), ("Parallelogram 3", "Parallelogram"));
            flowchart.AddPair(("ABC", "Parallelogram"), ("Rhombh dfh dhdsfhth dgs hgdus 4", "Parallelogram"));
            flowchart.AddPair(("ABCD", "Parallelogram"), ("Parallelograms 4", "Parallelogram"));
            flowchart.AddPair(("ABCDEF", "Parallelogram"), ("Rhombjhd jhdss gfhnygtikyilgjgdf dxgfh dtju fjsus d4", "Parallelogram"));
            flowchart.AddPair(("ABCDEFG", "Parallelogram"), ("Circldsge hsdah sah 5etrs hdrs gs  df4", "Parallelogram"));
            flowchart.AddPair(("abcdefg", "Parallelogram"), ("Circle hsdah sahasg 5etrs hdrs gs  df4", "Parallelogram"));
            flowchart.AddPair(("ABCDda da sdas avc sdfafa sdfcawda sfdas afEFGHI", "Parallelogram"), ("Circle hsdagaah sah 5etrs hdrs gs  df4", "Parallelogram"));
            flowchart.AddPair(("ABCDEfasf a afasf saf sagvfsdgvree bs bsvb s aFGHIJ", "Parallelogram"), ("Circle hsdaaah sah 5etrs hdrs gs  df4", "Parallelogram"));
            flowchart.AddPair(("ABCDsdg a dsgrsgad vsdfg wegasv dsavaEFGHIJK", "Parallelogram"), ("Circle hsdah sah agag5etrs hdrs gs  df4", "Parallelogram"));
            flowchart.AddPair(("ABCDEFGHIJKL", "Parallelogram"), ("Circle hasfsdah sah 5etrs hdrs gs  df4", "Parallelogram"));

            flowchart.Draw();
        }
    }
}