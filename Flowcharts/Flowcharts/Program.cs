namespace Flowcharts
{
    class Program
    {
        static void Main()
        {
            string fileName = "test";
            string path = null;

            var flowchart = new Flowchart("DownTop", fileName, path);

            flowchart.AddPair(("A1", "Ordering services", "Stadium"), ("A2", "Complete purchace requisition form (Use CCPR if payment is made by credit card)", "Stadium"), "Arrow");
            flowchart.AddPair("A2", ("A3", "Approved ?", "Stadium"), "Arrow");
            flowchart.AddPair("A3", ("A4", "Is service to be provided by an independednt contractor?", "Stadium"), "Arrow", "Yes");
            flowchart.AddPair("A3", ("A5", "Modify terms and conditions to Comply with requirements", "Stadium"), "Arrow", "No");
            flowchart.AddPair("A5", ("A2", "Complete purchace requisition form (Use CCPR if payment is made by credit card)", "Circle"), "BackArrow");
            flowchart.AddPair("A4", ("A6", "Are there an independent Contractor's Agreement and W-9 on file?", "Circle"), "Arrow", "Yes");
            flowchart.AddPair("A4", ("A7", "Obtain P.O. from Controller", "Circle"), "Arrow", "No");
            flowchart.AddPair("A6", ("A9", "No", "Circle"), "Arrow");
            flowchart.AddPair("A6", ("A10", "Yesadore", "Circle"), "Arrow");
            flowchart.AddPair("A7", ("A8", "Place Request for services with Vendor or contractor", "Circle"), "Arrow");
            flowchart.AddPair("A9", ("A11", "Obtain independent contractor's agreement and W-9", "Stadium"), "Arrow");
            flowchart.AddPair("A11", ("A6"), "BackArrow");
            flowchart.AddPair("A10", ("A7"), "BackArrow");

            flowchart.AddPair("A10", ("A14", "Test", "Rectangle"), "Arrow");
            flowchart.AddPair("A8", ("A1sa4", "Tessaast", "Rectangle"), "Arrow");
            flowchart.Draw();
        }
    }
}