namespace Flowcharts
{
    class Program
    {
        static void Main()
        {
            var flowchart = new Flowchart("test");
            flowchart.AddPair("A", "B");
            flowchart.AddPair("A", "C");
            flowchart.AddPair("A", "D");
            flowchart.AddPair("B", "E");
            flowchart.AddPair("B", "S");
            flowchart.AddPair("B", "Q");
            flowchart.AddPair("C", "Q");
            flowchart.AddPair("D", "W");


            flowchart.Draw();
        }
    }
}