namespace Flowcharts
{
    class Program
    {
        static void Main()
        {
            string fileName = "test";
            string path = null;

            var flowchart = new Flowchart("LeftRight", fileName, path);

            flowchart.AddPair(("A", "A", "Rhombus"), ("E", "E", "Rhombus"), "Arrow");
            flowchart.AddPair(("B", "B", "Rhombus"), ("E", "E", "Rhombus"), "Arrow");
            flowchart.AddPair(("C", "D", "Rhombus"), ("E", "E", "Rhombus"), "Arrow");
            //flowchart.AddPair(("D", "D", "Rhombus"), ("E", "E", "Rhombus"), "Arrow");

            flowchart.AddPair(("A", "A", "Rhombus"), ("F", "F", "Rhombus"), "Arrow");
            flowchart.AddPair(("D", "D", "Rhombus"), ("F", "F", "Rhombus"), "Arrow");

            flowchart.AddPair(("B", "B", "Rhombus"), ("F", "F", "Rhombus"), "Arrow");
            //flowchart.AddPair(("C", "D", "Rhombus"), ("F", "F", "Rhombus"), "Arrow");
            //flowchart.AddPair(("A", "A", "Rhombus"), ("G", "G", "Rhombus"), "Arrow");
            //flowchart.AddPair(("B", "B", "Rhombus"), ("G", "G", "Rhombus"), "Arrow");
            //flowchart.AddPair(("C", "D", "Rhombus"), ("G", "G", "Rhombus"), "Arrow");
            //flowchart.AddPair(("D", "D", "Rhombus"), ("G", "G", "Rhombus"), "Arrow");

            flowchart.Draw();
        }
    }
}