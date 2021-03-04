namespace Flowcharts
{
    class Program
    {
        static void Main()
        {
            string fileName = "test";
            string path = null;

            var flowchart = new Flowchart("LeftRight", fileName, path);
            flowchart.AddPair(("Lorem Ipsum", "Rhombus"), ("Lorem ipsum dolor sit amet, consectetur adipiscing ", "TrapezoidAlt"), "Duis egestas urna lacus");
            flowchart.AddPair(("Lorem ipsum dolor sit amet, consectetur adipiscing", "Trapezoid"), ("Lorem ipsum dolor adipiscing ", "TrapezoidAlt"), "Duis egestas urna lacus");
            flowchart.AddPair(("Nullam sit ", "Circle"), ("Vivamus tristique lectus in turpis vehicula pulvinar", "Banner"), "Vestibulum quis sollicitudin mi, et ornare libero. Nunc sed convallis magna. Vestibulum id elit risus.");
            flowchart.AddPair(("A", "Stadium"), ("Donec viverra est eget felis dignissim, venenatis blandit magna consectetur", "Cylinder"), "fagbdsbs sfa");
            flowchart.AddPair(("Sed at erat interdum metus sagittis", "Rhombus"), ("Etiam tincidunt ", "Subroutine"), "Nulla sagittis, ligula ut suscipit bibendum");
            flowchart.AddPair(("Aliquam pharetra metus non tellus vehicula", "Rhombus"), ("consequat", "Rhombus"), "Curabitur id egestas ligula");
            flowchart.AddPair(("Morbi dolor nisi, feugiat ut ipsum eget, tincidunt aliquam ", "ParallelogramAlt"), ("Lorem ipsum dolor sit amet", "Stadium"), "lacus vitae venenatis");
            flowchart.AddPair(("Sed et rhoncus dui. Cras pretium mollis nibh, elementum semper metus vulputate id", "Stadium"), ("elementum eros consequat auctor. Pellentesque", "Stadium"), "Nam in enim magna");
            flowchart.AddPair(("Duis egestas", "Stadium"), ("Curabitur fermentum nisl tortor, in hendrerit", "Stadium"), "Curabitur");
            flowchart.AddPair(("Pellentesque habitant morbi ", "Rhombus"), ("Phasellus condimentum porttitor lacus ", "Stadium"));
            flowchart.AddPair(("Suspendisse congue posuere velit", "Stadium"), ("consectetur adipiscing elit", "Stadium"), "Morbi lacinia condimentum lectus");
            flowchart.AddPair(("nulla finibus eu", "Stadium"), ("Quisque", "Stadium"), "Maecenas varius vehicula ");

            flowchart.Draw();
        }
    }
}