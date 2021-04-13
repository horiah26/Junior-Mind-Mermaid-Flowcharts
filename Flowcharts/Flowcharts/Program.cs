namespace Flowcharts
{
    class Program
    {
        static void Main()
        {
            string fileName = "test";
            string path = null;

            string arrow = "Arrow";
            string backArrow = "BackArrow";
            string rectangle = "Rectangle";
            string rhombus = "Rhombus";
            string stadium = "Stadium";

            var flowchart = new Flowchart("DownTop", fileName, path);

            //flowchart.AddPair(("A1", "Ordering services", "Stadium"), ("A2", "Complete purchace requisition form (Use CCPR if payment is made by credit card)", rectangle), arrow);
            //flowchart.AddPair("A2", ("A3", "Approved ?", rectangle), arrow);
            //flowchart.AddPair("A3", ("A4", "Is service to be provided by an independednt contractor?", rectangle), arrow, "Yes");
            //flowchart.AddPair("A3", ("A5", "Modify terms and conditions to Comply with requirements", rectangle), arrow, "No");
            //flowchart.AddPair("A5", ("A2", "Complete purchace requisition form (Use CCPR if payment is made by credit card)", rectangle), backArrow);
            //flowchart.AddPair("A4", ("A6", "Are there an independent Contractor's Agreement and W-9 on file?", rectangle), arrow, "Yes");
            //flowchart.AddPair("A4", ("A7", "Obtain P.O. from Controller", rectangle), arrow, "No");
            //flowchart.AddPair("A6", ("A9", "No", rectangle), arrow);
            //flowchart.AddPair("A6", ("A10", "Yes", rectangle), arrow);
            //flowchart.AddPair("A7", ("A8", "Place Request for services with Vendor or contractor", "Circle"), arrow);
            //flowchart.AddPair("A9", ("A11", "Obtain independent contractor's agreement and W-9", rectangle), arrow);
            //flowchart.AddPair("A11", "A6", backArrow);
            //flowchart.AddPair("A10", "A7", backArrow);

            //flowchart.AddPair(("Collect", "Collect late payments", "Stadium"), ("Send", "Send Collection Letter", rectangle), arrow);
            //flowchart.AddPair("Send", ("Rhombus1", "Payment received within one week?", rhombus), arrow);
            //flowchart.AddPair("Rhombus1", ("Assistant", "Accounting Assistant Calls Customer for Payment", rectangle), arrow, "No");
            //flowchart.AddPair("Rhombus1", ("Forward", "Forward Payment to Payment Processing", "Parallelogram"), arrow, "Yes");
            //flowchart.AddPair("Assistant", ("Received?", "Payment Received?", rhombus), arrow);
            //flowchart.AddPair("Received?", "Forward", backArrow, "Yes");
            //flowchart.AddPair("Received?", ("Payment>1000", "Payment > $1000?", rectangle), arrow, "No");
            //flowchart.AddPair("Payment>1000", ("Invoice", "Write Off Invoice as closed", rectangle), arrow, "No");
            //flowchart.AddPair("Payment>1000", ("Agency", "Contact Collection Agency", rectangle), arrow, "Yes");
            //flowchart.AddPair("Agency", ("End", "End", "Stadium"), arrow);
            //flowchart.AddPair("Invoice", "End", arrow);
            //flowchart.AddPair("Forward", "End", arrow);

            //flowchart.AddPair(("Arrives", "Patient arrives", stadium), ("System?", "Patient in the system?", rhombus), arrow);
            //flowchart.AddPair("System?", ("Nurse?", "Nurse available?", rhombus), arrow, "Yes");
            //flowchart.AddPair("System?", ("Paperwork", "Patient needs to complete paperwork", rectangle), arrow, "No");
            //flowchart.AddPair("Paperwork", "System?", backArrow);
            //flowchart.AddPair("Nurse?", ("Pulse", "Take pulse, blood pressure, weight, urine", rectangle), arrow, "Yes");
            //flowchart.AddPair("Nurse?", ("Waiting room", "Waiting room", rectangle), arrow, "No");
            //flowchart.AddPair("Waiting room", "Nurse?", backArrow);
            //flowchart.AddPair("Pulse", ("Doctor?", "Doctor available?", rhombus), arrow);
            //flowchart.AddPair("Doctor?", ("PatientDoctor", "Patient with doctor", rectangle), arrow, "Yes");
            //flowchart.AddPair("Doctor?", ("Waiting room2", "Waiting room", rectangle), arrow, "No");
            //flowchart.AddPair("Waiting room2", "Doctor?", backArrow);
            //flowchart.AddPair("PatientDoctor", ("FollowUp?", "Need follow-up appointment?", rhombus), "Arrow");
            //flowchart.AddPair("FollowUp?", ("MakeAppointment", "Make an appointment", rectangle), arrow, "Yes");
            //flowchart.AddPair("FollowUp?", ("Medication?", "Need medication?", rhombus), arrow, "No");
            //flowchart.AddPair("Medication?", ("Pharmacy", "Patient sent to pharmacy?", rectangle), arrow, "Yes");
            //flowchart.AddPair("Pharmacy", ("Dispense", "Dispense medication", rectangle), arrow);
            //flowchart.AddPair("Dispense", ("End", "Patient leaves", "Stadium"), arrow);
            //flowchart.AddPair("MakeAppointment", "End", arrow);

            //flowchart.AddPair(("Call", "Phone call is placed", stadium), ("Ringer?", "Is ringer turned on?", rhombus), arrow);
            //flowchart.AddPair("Ringer?", ("Phone rings", "Phone rings", rectangle), arrow, "Yes");
            //flowchart.AddPair("Ringer?", ("Voice", "Voice mail picks up", rectangle), arrow, "No");
            //flowchart.AddPair("Phone rings", ("User", "Does user pick up?", rhombus), arrow);
            //flowchart.AddPair("User", ("Ring4", "Is it ring #4?", rhombus), arrow, "No");
            //flowchart.AddPair("User", ("End", "Phone call is complete", stadium), arrow, "Yes");
            //flowchart.AddPair("Ring4", "Voice", backArrow, "Yes");
            //flowchart.AddPair("Ring4", "Phone rings", backArrow, "No");
            //flowchart.AddPair("Voice", "End", arrow);

            flowchart.AddPair(("Start", "Receive order from customer", rectangle), ("Design?", "Is design required?", rhombus), arrow);
            flowchart.AddPair("Design?", ("Design", "Design to requirements", rectangle), arrow, "Yes");
            flowchart.AddPair("Design?", ("Buy materials", "Buy materials", rectangle), arrow, "No");
            flowchart.AddPair("Buy materials", ("Receive parts", "Receive parts from customers", rectangle), arrow);
            flowchart.AddPair("Buy materials", ("Receive material", "Receive material", rectangle), arrow);
            flowchart.AddPair("Receive parts", "Receive material", "SideArrow" ,"sfgasgwe wet ");
            flowchart.AddPair("Buy materials", "Design", "SideArrow","taseras s ");

            flowchart.DrawFlowchart();
        }
    }
}