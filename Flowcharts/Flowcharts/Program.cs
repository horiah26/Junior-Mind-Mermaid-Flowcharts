namespace Flowcharts
{
    class Program
    {
        static void Main(string[] args)
        {
            string shape = "Banner";
            string arrow = "Arrow";

            string[] text;
            string path = null;

            //if (args.Length > 0)
            //{
            //    if (args.Length == 2)
            //    {
            //        path = args[1];
            //    }

            //    int lastDash = args[0].LastIndexOf("\\") + 1;
            //    int extension = args[0].LastIndexOf(".");
            //    string fileName = args[0][lastDash..extension];

            //    text = System.IO.File.ReadAllLines(args[0]);
            //    var reader = new ReadFromFile(text).GetSpecs();
            //    var flowchart = Factory.Flowchart("TopDown", fileName, path);
            //    new SpecsToFlowchart(flowchart, reader).AddToFlowchart();
            //    flowchart.DrawFlowchart();
            //}
            Subsystem sys = new Subsystem("sys");
            var flowchart = Factory.Flowchart("LeftRight", "test");

            //flowchart.AddPair(stre, ("Start", "Start", "Stadium"), ("A1", "A1", "Stadium"), "Arrow");
            //flowchart.AddPair(stre, "Start", ("A2", "A2", "Stadium"), "Arrow");
            //flowchart.AddPair("A2", ("C3", "C3", "Rectangle"), "Arrow");
            //flowchart.AddPair(stre, "A2", ("C2", "C2", "Stadium"), "Arrow");
            //flowchart.AddPair("A2", ("C3", "C3", "Rectangle"), "Arrow");
            //flowchart.AddPair("A1", ("B1", "B1", "Rectangle"), "Arrow");
            //flowchart.AddPair("A1", ("B2", "B1", "Rectangle"), "Arrow");
            //flowchart.AddPair("B1", ("C1", "C1", "Rectangle"), "Arrow");
            //flowchart.AddPair("B2", ("C2", "C2", "Rectangle"), "SideArrow");

            flowchart.AddPair(("Collect", "Collect late payments", "Stadium"), ("Send", "Send Collection Letter", "Rectangle"), "Arrow");
            flowchart.AddPair(("Send"), ("Rhombus1", "Payment received within one week?", "Rhombus"), "Arrow");
            flowchart.AddPair(("Rhombus1"), ("Assistant", "Accounting Assistant Calls Customer for Payment", "Rectangle"), "Arrow", "No");
            flowchart.AddPair(("Rhombus1"), ("Forward", "Forward Payment to Payment Processing", "Parallelogram"), "Arrow", "Yes");
            flowchart.AddPair(("Assistant"), ("Received?", "Payment Received?", "Rhombus"), "Arrow");
            flowchart.AddPair(("Received?"), ("Forward"), "BackArrow", "Yes");
            flowchart.AddPair(("Received?"), ("Payment>1000", "Payment > $1000?", "Rectangle"), "Arrow", "No");
            flowchart.AddPair(("Payment>1000"), ("Invoice", "Write Off Invoice as closed", "Rectangle"), "Arrow", "No");
            flowchart.AddPair(("Payment>1000"), ("Agency", "Contact Collection Agency", "Rectangle"), "Arrow", "Yes");
            flowchart.AddPair(("Agency"), ("End", "End", "Stadium"), "Arrow");
            flowchart.AddPair(("Invoice"), ("End"), "Arrow");
            flowchart.AddPair(("Forward"), ("End"), "Arrow");


            flowchart.DrawFlowchart();
        }
    }
}