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

            //flowchart.AddPair(("Start", "Start", "Stadium", sys), ("A1", "A1", "Stadium", sys), "Arrow");
            //flowchart.AddPair("Start", ("A2", "A2", "Stadium", sys), "Arrow");
            //flowchart.AddPair("A2", ("C3", "C3", "Rectangle"), "Arrow");
            //flowchart.AddPair("A2", ("C2", "C2", "Stadium"), "Arrow");
            //flowchart.AddPair("A2", ("C3", "C3", "Rectangle"), "Arrow");
            //flowchart.AddPair("A1", ("B1", "B1", "Rectangle", sys), "Arrow");
            //flowchart.AddPair("A1", ("B2", "B2", "Rectangle"), "Arrow");
            //flowchart.AddPair("B1", ("C1", "C1", "Rectangle"), "Arrow");
            //flowchart.AddPair("B2", ("C2", "C2", "Rectangle"), "SideArrow");

            //flowchart.AddPair(("Collect", "Collect late payments", "Stadium"), ("Send", "Send Collection Letter", "Rectangle"), "Arrow");
            //flowchart.AddPair(("Send"), ("Rhombus1", "Payment received within one week?", "Rhombus", sys), "Arrow");
            //flowchart.AddPair(("Rhombus1"), ("Assistant", "Accounting Assistant Calls Customer for Payment", "Rectangle", sys), "Arrow", "No");
            //flowchart.AddPair(("Rhombus1"), ("Forward", "Forward Payment to Payment Processing", "Parallelogram"), "Arrow", "Yes");
            //flowchart.AddPair(("Assistant"), ("Received?", "Payment Received?", "Rhombus"), "Arrow");
            //flowchart.AddPair(("Received?"), ("Forward"), "BackArrow", "Yes");
            //flowchart.AddPair(("Received?"), ("Payment>1000", "Payment > $1000?", "Rectangle"), "Arrow", "No");
            //flowchart.AddPair(("Payment>1000"), ("Invoice", "Write Off Invoice as closed", "Rectangle"), "Arrow", "No");
            //flowchart.AddPair(("Payment>1000"), ("Agency", "Contact Collection Agency", "Rectangle"), "Arrow", "Yes");
            //flowchart.AddPair(("Agency"), ("End", "End", "Stadium", sys), "Arrow");
            //flowchart.AddPair(("Invoice"), ("End"), "Arrow");
            //flowchart.AddPair(("Forward"), ("End"), "Arrow");

            //flowchart.AddPair(("Start", "Start", "Stadium"), ("Emergency?", "Is it an Emergency?", "Rhombus"), "Arrow");
            //flowchart.AddPair(("Emergency?"), ("War?", "Did the US declare War?", "Rhombus"), "Arrow", "Yes");
            //flowchart.AddPair(("War?"), ("Zombie?", "Is it a Zombie Attack?", "Rhombus"), "Arrow", "No");
            //flowchart.AddPair(("Zombie?"), ("Fire?", "Is there a Fire?", "Rhombus", sys), "Arrow", "No");
            //flowchart.AddPair(("Fire?"), ("Dead?", "Is Someone Dead?", "Rhombus"), "Arrow", "No");
            //flowchart.AddPair(("Dead?"), ("Sad later", "I'll be sad later. Let me be happy now", "Rectangle", sys), "Arrow", "Yes");
            //flowchart.AddPair(("Sad later"), ("End", "End", "Stadium"), "Arrow");
            //flowchart.AddPair(("War?"), ("Evacuating?", "Are we evacuating?", "Rhombus", sys), "Arrow", "Yes");
            //flowchart.AddPair(("Zombie?"), ("Evacuating?"), "SideArrow", "Yes");
            //flowchart.AddPair(("Fire?"), ("Evacuating?"), "SideArrow", "Yes");
            //flowchart.AddPair(("Evacuating?"), ("Knock", "KNOCK!", "Rectangle", sys), "Arrow", "Yes");
            //flowchart.AddPair(("Emergency?"), ("Visiting?", "Is someone visiting?", "Rhombus", sys), "Arrow", "No");
            //flowchart.AddPair(("Visiting?"), ("They can wait", "They can wait", "Rectangle", sys), "Arrow", "Yes");
            //flowchart.AddPair(("Visiting?"), ("Going somewhere?", "Are you going somewhere?", "Rhombus"), "Arrow", "No");
            //flowchart.AddPair(("Going somewhere?"), ("Tell me later", "Tell me later", "Rectangle", sys), "Arrow", "No");
            //flowchart.AddPair(("Going somewhere?"), ("Leave a note", "Leave a note", "Rectangle"), "Arrow", "Yes");
            //flowchart.AddPair(("Evacuating?"), ("Tell me later"), "Arrow", "Yes");
            //flowchart.AddPair(("Dead?"), ("Tell me later"), "SideArrow", "Yes");

          //flowchart.AddPair(("Start", "AE or SDR sells a business package", "ParallelogramAlt"), ("AE?", "Account owned by AE?", "Rhombus"), "Arrow");
          //flowchart.AddPair(("AE?"), ("Keeps ownership", "AE keeps ownership of the account", "Stadium"), "Arrow", "Yes");
          //flowchart.AddPair(("AE?"), ("Opportunity?", "AE has an open opportunity on the account?", "Banner"), "ThickLink", "No");
          //flowchart.AddPair(("Opportunity?"), ("Opportunity", "AE has an open opportunity on the account", "Parallelogram", sys), "Arrow", "Yes");
          //flowchart.AddPair(("Opportunity?"), ("No opportunity", "No open opportunity on the account", "Rectangle"), "Arrow", "No");
          //flowchart.AddPair(("Opportunity"), ("Employees?2", "How many employees?", "Banner"), "ThickLink");
          //flowchart.AddPair(("Employees?2"), ("SMB2", "Hand off account to SMB AM. Round Robin after 120 days", "Hexagon", sys), "Arrow", "< 100 employees");
          //flowchart.AddPair(("Employees?2"), ("AM2", "Hand off account to AM. Round Robin after 120 days", "RoundedRectangle"), "Arrow", "101 - 5000 +");
          //flowchart.AddPair(("No opportunity"), ("Employees?", "How many employees?", "Banner"), "Link");
          //flowchart.AddPair(("Employees?"), ("SMB", "Hand off account to SMB AM. Round Robin after 120 days", "Subroutine"), "Arrow", "< 100 employees");
          //flowchart.AddPair(("Employees?"), ("AM", "Hand off account to AM. Round Robin after 120 days", "Trapezoid"), "Arrow", "101 - 5000 +");
          //flowchart.AddPair(("SMB"), ("Spreadsheets", "Sales Ops sends spreadsheets", "Banner"), "ThickLink");
          //flowchart.AddPair(("AM"), ("Spreadsheets", "Sales Ops sends spreadsheets", "ParallelogramAlt"), "Link");
          //flowchart.AddPair(("SMB2"), ("Spreadsheets", "Sales Ops sends spreadsheets", "RoundedRectangle"), "DottedLink");
          //flowchart.AddPair(("AM2"), ("Spreadsheets", "Sales Ops sends spreadsheets", "Banner"), "DottedLink");
          //flowchart.AddPair(("Spreadsheets"), ("Uploads", "Sales Ops uploads account changes to Salesforce", "Cylinder"), "Arrow");

            flowchart.DrawFlowchart();
        }
    }
}