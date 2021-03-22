namespace Flowcharts
{
    class Program
    {
        static void Main()
        {
            string fileName = "test";
            string path = null;

            var flowchart = new Flowchart("LeftRight", fileName, path);
            flowchart.AddPair(("A", "A", "Rhombus"), ("C", "C", "Rhombus"), "Arrow");
            flowchart.AddPair(("B", "B", "Rhombus"), ("C", "C", "Rhombus"), "Arrow");
            flowchart.AddPair(("D", "D", "Rhombus"), ("C", "C", "Rhombus"), "Arrow");

            flowchart.AddPair(("A", "A", "Rhombus"), ("E", "E", "Rhombus"), "Arrow");
            flowchart.AddPair(("B", "B", "Rhombus"), ("E", "E", "Rhombus"), "Arrow");
            flowchart.AddPair(("D", "D", "Rhombus"), ("E", "E", "Rhombus"), "Arrow");

            flowchart.AddPair(("A", "A", "Rhombus"), ("H", "H", "Rhombus"), "Arrow");
            flowchart.AddPair(("B", "B", "Rhombus"), ("H", "H", "Rhombus"), "Arrow");
            flowchart.AddPair(("D", "D", "Rhombus"), ("H", "H", "Rhombus"), "Arrow");

            flowchart.AddPair(("A", "A", "Rhombus"), ("G", "G", "Rhombus"), "Arrow");
            flowchart.AddPair(("B", "B", "Rhombus"), ("G", "G", "Rhombus"), "Arrow");
            flowchart.AddPair(("D", "D", "Rhombus"), ("G", "G", "Rhombus"), "Arrow");

            //flowchart.AddPair(("A", "A", "Rhombus"), ("I", "I", "Rhombus"), "Arrow");
            //flowchart.AddPair(("B", "B", "Rhombus"), ("I", "I", "Rhombus"), "Arrow");
            //flowchart.AddPair(("D", "D", "Rhombus"), ("I", "I", "Rhombus"), "Arrow");

            //flowchart.AddPair(("F", "F", "Rhombus"), ("E", "E", "Rhombus"), "Arrow");
            //flowchart.AddPair(("B", "B", "Rhombus"), ("E", "E", "Rhombus"), "Arrow");
            //flowchart.AddPair(("C", "C", "Rhombus"), ("F", "F", "Rhombus"), "Arrow");
            //flowchart.AddPair(("C", "C", "Rhombus"), ("G", "G", "Rhombus"), "Arrow");
            //flowchart.AddPair(("C", "C", "Rhombus"), ("H", "H", "Rhombus"), "Arrow");
            //flowchart.AddPair(("Element9", "Sed at erat interdum metus sagittis", "Rhombus"), ("Element10", "Etiam tincidunt ", "Subroutine"), "Arrow", "Nulla sagittis, ligula ut suscipit bibendum");
            //flowchart.AddPair(("Element11", "Aliquam pharetra metus non tellus vehicula", "Rhombus"), ("Element12", "consequat", "Rhombus"), "Arrow", "Curabitur id egestas ligula");
            //flowchart.AddPair(("Element13", "Morbi dolor nisi, feugiat ut ipsum eget, tincidunt aliquam ", "ParallelogramAlt"), ("Element14", "Lorem ipsum dolor sit amet", "Stadium"), "Arrow", "lacus vitae venenatis");
            //flowchart.AddPair(("Element15", "Sed et rhoncus dui. Cras pretium mollis nibh, elementum semper metus vulputate id", "Stadium"), ("Element16", "elementum eros consequat auctor. Pellentesque", "Stadium"), "Arrow", "Nam in enim magna");
            //flowchart.AddPair(("Element17", "Duis egestas", "Stadium"), ("Element18", "Curabitur fermentum nisl tortor, in hendrerit", "Stadium"), "Arrow", "Curabitur");
            //flowchart.AddPair(("Element19", "Pellentesque habitant morbi ", "Rhombus"), ("Element20", "Phasellus condimentum porttitor lacus ", "Stadium"),"Arrow");
            //flowchart.AddPair(("Element21", "Suspendisse congue posuere velit", "Stadium"), ("Element22", "consectetur adipiscing elit", "Stadium"), "Arrow", "Morbi lacinia condimentum lectus");
            //flowchart.AddPair(("Element23", "nulla finibus eu", "Stadium"), ("Element24", "Quisque", "Stadium"), "Arrow", "Maecenas varius vehicula ");

            flowchart.Draw();
        }
    }
}