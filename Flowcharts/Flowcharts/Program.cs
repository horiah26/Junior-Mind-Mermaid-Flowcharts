namespace Flowcharts
{
    class Program
    {
        static void Main()
        {
            string fileName = "test";
            string path = null;

            var flowchart = new Flowchart("LeftRight", fileName, path);
            flowchart.AddPair(("Element1", "Lorem Ipsum", "Rhombus"), ("Element2","Lorem ipsum dolor sit amet, consectetur adipiscing ", "TrapezoidAlt"), "Duis egestas urna lacus");
            flowchart.AddPair(("Element3", "Lorem ipsum dolor sit amet, consectetur adipiscing", "Trapezoid"), ("Element4", "Lorem ipsum dolor adipiscing ", "TrapezoidAlt"), "Duis egestas urna lacus");
            flowchart.AddPair(("Element5", "Nullam sit ", "Circle"), ("Element6", "Vivamus tristique lectus in turpis vehicula pulvinar", "Banner"), "Vestibulum quis sollicitudin mi, et ornare libero. Nunc sed convallis magna. Vestibulum id elit risus.");
            flowchart.AddPair(("Element7", "A", "Stadium"), ("Element8", "Donec viverra est eget felis dignissim, venenatis blandit magna consectetur", "Cylinder"), "fagbdsbs sfa");
            flowchart.AddPair(("Element9", "Sed at erat interdum metus sagittis", "Rhombus"), ("Element10", "Etiam tincidunt ", "Subroutine"), "Nulla sagittis, ligula ut suscipit bibendum");
            flowchart.AddPair(("Element11", "Aliquam pharetra metus non tellus vehicula", "Rhombus"), ("Element12", "consequat", "Rhombus"), "Curabitur id egestas ligula");
            flowchart.AddPair(("Element13", "Morbi dolor nisi, feugiat ut ipsum eget, tincidunt aliquam ", "ParallelogramAlt"), ("Element14", "Lorem ipsum dolor sit amet", "Stadium"), "lacus vitae venenatis");
            flowchart.AddPair(("Element15", "Sed et rhoncus dui. Cras pretium mollis nibh, elementum semper metus vulputate id", "Stadium"), ("Element16", "elementum eros consequat auctor. Pellentesque", "Stadium"), "Nam in enim magna");
            flowchart.AddPair(("Element17", "Duis egestas", "Stadium"), ("Element18", "Curabitur fermentum nisl tortor, in hendrerit", "Stadium"), "Curabitur");
            flowchart.AddPair(("Element19", "Pellentesque habitant morbi ", "Rhombus"), ("Element20", "Phasellus condimentum porttitor lacus ", "Stadium"));
            flowchart.AddPair(("Element21", "Suspendisse congue posuere velit", "Stadium"), ("Element22", "consectetur adipiscing elit", "Stadium"), "Morbi lacinia condimentum lectus");
            flowchart.AddPair(("Element23", "nulla finibus eu", "Stadium"), ("Element24", "Quisque", "Stadium"), "Maecenas varius vehicula ");

            flowchart.Draw();
        }
    }
}