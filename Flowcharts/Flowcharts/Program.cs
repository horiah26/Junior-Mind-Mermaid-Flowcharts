namespace Flowcharts
{
    class Program
    {
        static void Main()
        {
            string fileName = "test";
            string path = null;

            var flowchart = new Flowchart("LeftRight", fileName, path);

            flowchart.AddPair(("A1", "A", "Rhombus"), ("A", "A", "Rhombus"), "Arrow");
            flowchart.AddPair(("A2", "A", "Rhombus"), ("A", "A", "Rhombus"), "Arrow");
            flowchart.AddPair(("A3", "A", "Rhombus"), ("A", "A", "Rhombus"), "Arrow");
            flowchart.AddPair(("A4", "A", "Rhombus"), ("A", "A", "Rhombus"), "Arrow");

            flowchart.AddPair(("A", "A", "Rhombus"), ("E", "E", "Rhombus"), "Arrow");
            flowchart.AddPair(("B", "B", "Rhombus"), ("E", "E", "Rhombus"), "Arrow");
            flowchart.AddPair(("C", "D", "Rhombus"), ("E", "E", "Rhombus"), "Arrow");
            flowchart.AddPair(("J", "J", "Rhombus"), ("E", "E", "Rhombus"), "Arrow");

            //flowchart.AddPair(("C", "D", "Rhombus"), ("HG", "HG", "Rhombus"), "Arrow");

            flowchart.AddPair(("E", "E", "Rhombus"), ("Q", "Q", "Rhombus"), "Arrow");
            flowchart.AddPair(("E", "E", "Rhombus"), ("Q1", "Q1", "Rhombus"), "Arrow");
            flowchart.AddPair(("E", "E", "Rhombus"), ("Z", "Z", "Rhombus"), "Arrow");

            flowchart.AddPair(("Z", "Z", "Rhombus"), ("H", "H", "Rhombus"), "Arrow");
             
            flowchart.AddPair(("H", "H", "Rhombus"), ("W", "W", "Rhombus"), "Arrow");
            //flowchart.AddPair(("Z", "Z", "Rhombus"), ("Q", "Q", "Rhombus"), "Arrow");

            flowchart.Draw();
        }
    }
}