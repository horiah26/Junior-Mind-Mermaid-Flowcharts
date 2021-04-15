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
            string rounded = "RoundedRectangle";
            string yes = "Yes";
            string no = "No";

            for(int i = 9; i < 10; i++)
            {
                var flowchart = new Flowchart("LeftRight", fileName + i, path);
                GetCase(i, flowchart);
                flowchart.DrawFlowchart();
            }


            void GetCase(int i, Flowchart flowchart)
            {
                if(i == 1)
                {
                    flowchart.AddPair(("A1", "Ordering services", "Stadium"), ("A2", "Complete purchace requisition form (Use CCPR if payment is made by credit card)", rectangle), arrow);
                    flowchart.AddPair("A2", ("A3", "Approved ?", rectangle), arrow);
                    flowchart.AddPair("A3", ("A4", "Is service to be provided by an independednt contractor?", rectangle), arrow, yes);
                    flowchart.AddPair("A3", ("A5", "Modify terms and conditions to Comply with requirements", rectangle), arrow, no);
                    flowchart.AddPair("A5", ("A2", "Complete purchace requisition form (Use CCPR if payment is made by credit card)", rectangle), backArrow);
                    flowchart.AddPair("A4", ("A6", "Are there an independent Contractor's Agreement and W-9 on file?", rectangle), arrow, yes);
                    flowchart.AddPair("A4", ("A7", "Obtain P.O. from Controller", rectangle), arrow, no);
                    flowchart.AddPair("A6", ("A9", no, rectangle), arrow);
                    flowchart.AddPair("A6", ("A10", yes, rectangle), arrow);
                    flowchart.AddPair("A7", ("A8", "Place Request for services with Vendor or contractor", "Circle"), arrow);
                    flowchart.AddPair("A9", ("A11", "Obtain independent contractor's agreement and W-9", rectangle), arrow);
                    flowchart.AddPair("A11", "A6", backArrow);
                    flowchart.AddPair("A10", "A7", backArrow);
                }
                else if( i == 2)
                {
                    flowchart.AddPair(("Collect", "Collect late payments", "Stadium"), ("Send", "Send Collection Letter", rectangle), arrow);
                    flowchart.AddPair("Send", ("Rhombus1", "Payment received within one week?", rhombus), arrow);
                    flowchart.AddPair("Rhombus1", ("Assistant", "Accounting Assistant Calls Customer for Payment", rectangle), arrow, no);
                    flowchart.AddPair("Rhombus1", ("Forward", "Forward Payment to Payment Processing", "Parallelogram"), arrow, yes);
                    flowchart.AddPair("Assistant", ("Received?", "Payment Received?", rhombus), arrow);
                    flowchart.AddPair("Received?", "Forward", backArrow, yes);
                    flowchart.AddPair("Received?", ("Payment>1000", "Payment > $1000?", rectangle), arrow, no);
                    flowchart.AddPair("Payment>1000", ("Invoice", "Write Off Invoice as closed", rectangle), arrow, no);
                    flowchart.AddPair("Payment>1000", ("Agency", "Contact Collection Agency", rectangle), arrow, yes);
                    flowchart.AddPair("Agency", ("End", "End", "Stadium"), arrow);
                    flowchart.AddPair("Invoice", "End", arrow);
                    flowchart.AddPair("Forward", "End", arrow);
                }
                else if (i == 3)
                {
                    flowchart.AddPair(("Arrives", "Patient arrives", stadium), ("System?", "Patient in the system?", rhombus), arrow);
                    flowchart.AddPair("System?", ("Nurse?", "Nurse available?", rhombus), arrow, yes);
                    flowchart.AddPair("System?", ("Paperwork", "Patient needs to complete paperwork", rectangle), arrow, no);
                    flowchart.AddPair("Paperwork", "System?", backArrow);
                    flowchart.AddPair("Nurse?", ("Pulse", "Take pulse, blood pressure, weight, urine", rectangle), arrow, yes);
                    flowchart.AddPair("Nurse?", ("Waiting room", "Waiting room", rectangle), arrow, no);
                    flowchart.AddPair("Waiting room", "Nurse?", backArrow);
                    flowchart.AddPair("Pulse", ("Doctor?", "Doctor available?", rhombus), arrow);
                    flowchart.AddPair("Doctor?", ("PatientDoctor", "Patient with doctor", rectangle), arrow, yes);
                    flowchart.AddPair("Doctor?", ("Waiting room2", "Waiting room", rectangle), arrow, no);
                    flowchart.AddPair("Waiting room2", "Doctor?", backArrow);
                    flowchart.AddPair("PatientDoctor", ("FollowUp?", "Need follow-up appointment?", rhombus), "Arrow");
                    flowchart.AddPair("FollowUp?", ("MakeAppointment", "Make an appointment", rectangle), arrow, yes);
                    flowchart.AddPair("FollowUp?", ("Medication?", "Need medication?", rhombus), arrow, no);
                    flowchart.AddPair("Medication?", ("Pharmacy", "Patient sent to pharmacy?", rectangle), arrow, yes);
                    flowchart.AddPair("Pharmacy", ("Dispense", "Dispense medication", rectangle), arrow);
                    flowchart.AddPair("Dispense", ("End", "Patient leaves", "Stadium"), arrow);
                    flowchart.AddPair("MakeAppointment", "End", arrow);
                }
                else if (i == 4)
                {
                    flowchart.AddPair(("Call", "Phone call is placed", stadium), ("Ringer?", "Is ringer turned on?", rhombus), arrow);
                    flowchart.AddPair("Ringer?", ("Phone rings", "Phone rings", rectangle), arrow, yes);
                    flowchart.AddPair("Ringer?", ("Voice", "Voice mail picks up", rectangle), arrow, no);
                    flowchart.AddPair("Phone rings", ("User", "Does user pick up?", rhombus), arrow);
                    flowchart.AddPair("User", ("Ring4", "Is it ring #4?", rhombus), arrow, no);
                    flowchart.AddPair("User", ("End", "Phone call is complete", stadium), arrow, yes);
                    flowchart.AddPair("Ring4", "Voice", backArrow, yes);
                    flowchart.AddPair("Ring4", "Phone rings", backArrow, no);
                    flowchart.AddPair("Voice", "End", arrow);
                }
                else if (i == 5)
                {

                    flowchart.AddPair(("Start", "Receive order from customer", rectangle), ("Design?", "Is design required?", rhombus), arrow);
                    flowchart.AddPair("Design?", ("Design", "Design to requirements", rectangle), arrow, yes);
                    flowchart.AddPair("Design?", ("Buy materials", "Buy materials", rectangle), arrow, no);
                    flowchart.AddPair("Buy materials", ("Receive parts", "Receive parts from customers", rectangle), arrow);
                    flowchart.AddPair("Buy materials", ("Receive material", "Receive material", rectangle), arrow);
                    flowchart.AddPair("Design", "Buy materials", "SideArrow");
                    flowchart.AddPair("Receive parts", ("Acceptable?", "Is material acceptable?", rhombus), arrow);
                    flowchart.AddPair("Receive material", "Acceptable?", arrow);
                    flowchart.AddPair("Acceptable?", ("Inspection results", "Inspection results", "Parallelogram"), arrow);
                    flowchart.AddPair("Acceptable?", ("Build", "Build to requirements", rectangle), arrow, yes);
                    flowchart.AddPair("Acceptable?", ("Return", "Return to subcontractors", rectangle), arrow, no);
                    flowchart.AddPair("Return", "Receive material", backArrow);
                    flowchart.AddPair("Build", ("Verify", "Verify built to requirements", rectangle), arrow);
                    flowchart.AddPair("Verify", ("Acceptable product?", "Is product acceptable?", rhombus), arrow);
                    flowchart.AddPair("Acceptable product?", ("Inspection results2", "Inspection results", "Parallelogram"), arrow);
                    flowchart.AddPair("Acceptable product?", ("Package", "Package and ship finished product", rectangle), arrow, yes);
                    flowchart.AddPair("Acceptable product?", ("Rework", "Rework to requirements", rectangle), arrow, no);
                    flowchart.AddPair("Rework", "Verify", backArrow);
                    flowchart.AddPair("Package", ("Support", "Provide service support", rectangle), arrow);
                }
                else if (i == 6)
                {
                    flowchart.AddPair(("Order placed", "Order is placed online", stadium), ("Confirmation", "Email confirmation is sent to both the customer and the web email", rectangle), arrow);
                    flowchart.AddPair("Confirmation", ("Order checked", "Order is checked on Reference point to confirm purchased goods", rectangle), arrow);
                    flowchart.AddPair("Order checked", ("In stock?", "Are the purchased goods in stock?", rhombus), arrow);
                    flowchart.AddPair("In stock?", ("Cat & Dan", "Cat and Dan are contacted for an ETA of the goods", rectangle), arrow, no);
                    flowchart.AddPair("In stock?", ("Allocated", "Stock is allocated in the designated areas", rectangle), arrow, yes);
                    flowchart.AddPair("In stock?", ("Customer contacted", "Customer is contacted to arrange delivery or collection", rectangle), arrow, yes);
                    flowchart.AddPair("Cat & Dan", ("Calendar appointment", "Calendar appointment is scheduled for ETA date", rectangle), arrow);
                    flowchart.AddPair("Cat & Dan", ("Customer ETA", "Customer is called and informed of ETA", rectangle), arrow);
                    flowchart.AddPair("Calendar appointment", ("Goods arrive", "Goods arrive in stock and are allocated", rectangle), arrow);
                    flowchart.AddPair("Goods arrive", "Customer contacted", arrow);
                    flowchart.AddPair("Customer contacted", ("UK?", "Is customer based in the UK?", rhombus), arrow);
                    flowchart.AddPair("UK?", ("Post office", "Take goods to the Post Office", rectangle), arrow, yes);
                    flowchart.AddPair("UK?", ("Reference point", "Enter on Reference point delivery / collection details", rectangle), arrow, no);
                    flowchart.AddPair("Post office", ("Postage", "Pay postage and VAT", rectangle), arrow);
                    flowchart.AddPair("Postage", ("End", "Customer recieves goods and reference point is updated", stadium), arrow);
                    flowchart.AddPair("Reference point", "End", arrow);
                }
                else if (i == 7)
                {
                    flowchart.AddPair(("Start", "AE or SDR sells a business package", rounded), ("AE?", "Account owned by AE?", rhombus), arrow);
                    flowchart.AddPair("AE?", ("Keeps ownership", "AE keeps ownership of the account", rhombus), arrow, yes);
                    flowchart.AddPair("AE?", ("Opportunity?", "AE has an open opportunity on the account?", rhombus), arrow, no);
                    flowchart.AddPair("Opportunity?", ("Opportunity", "AE has an open opportunity on the account", rounded), arrow, yes);
                    flowchart.AddPair("Opportunity?", ("No opportunity", "No open opportunity on the account", rounded), arrow, no);
                    flowchart.AddPair("Opportunity", ("Employees?2", "How many employees?", rhombus), arrow);

                    flowchart.AddPair("Employees?2", ("SMB2", "Hand off account to SMB AM. Round Robin after 120 days", rounded), arrow, "< 100 employees");
                    flowchart.AddPair("Employees?2", ("AM2", "Hand off account to AM. Round Robin after 120 days", rounded), arrow, "101 - 5000 +");

                    flowchart.AddPair("No opportunity", ("Employees?", "How many employees?", rhombus), arrow);
                    flowchart.AddPair("Employees?", ("SMB", "Hand off account to SMB AM. Round Robin after 120 days", rounded), arrow, "< 100 employees");
                    flowchart.AddPair("Employees?", ("AM", "Hand off account to AM. Round Robin after 120 days", rounded), arrow, "101 - 5000 +");
                    flowchart.AddPair("SMB", ("Spreadsheets", "Sales Ops sends spreadsheets", rounded), arrow);
                    flowchart.AddPair("AM", ("Spreadsheets", "Sales Ops sends spreadsheets", rounded), arrow);
                    flowchart.AddPair("SMB2", ("Spreadsheets", "Sales Ops sends spreadsheets", rounded), arrow);
                    flowchart.AddPair("AM2", ("Spreadsheets", "Sales Ops sends spreadsheets", rounded), arrow);
                    flowchart.AddPair("Spreadsheets", ("Uploads", "Sales Ops uploads account changes to Salesforce", rounded), arrow);
                }
                else if (i == 8)
                {
                    flowchart.AddPair(("Start", "Customer Payment Processing", stadium), ("Receive Payment", "Receive Payment in Mail", rectangle), arrow);
                    flowchart.AddPair("Receive Payment", ("Invoice?", "Does Payment Correspond To Outsanding Invoice?", rhombus), arrow);
                    flowchart.AddPair("Invoice?", ("Forward copy", "Forward Copy of Check to Sales Department to Write Order?", rectangle), arrow, no);
                    flowchart.AddPair("Forward copy", ("Create Invoice", "Create Invoice For Order", rectangle), arrow);
                    flowchart.AddPair("Invoice?", ("Match Payment", "Match Payment to Invoice", rectangle), arrow, yes);
                    flowchart.AddPair("Create Invoice", "Match Payment", "SideArrow");
                    flowchart.AddPair("Match Payment", ("Accounts Match?", "Accounts Match?", rectangle), arrow);
                    flowchart.AddPair("Accounts Match?", ("Record Receipt", "Record Receipt in Accounting System and Deposit Check", stadium), arrow, yes);
                    flowchart.AddPair("Accounts Match?", ("Discrepancy?", "Is Discrepancy Over $500?", rectangle), arrow, no);
                    flowchart.AddPair("Discrepancy?", ("Write off", "Write off Discrepancy", rectangle), arrow, no);
                    flowchart.AddPair("Discrepancy?", ("Overpayment?", "Is Discrepancy an Overpayment?", rectangle), arrow, yes);
                    flowchart.AddPair("Write off", "Record Receipt", "BackArrow");

                    flowchart.AddPair("Overpayment?", ("Issue Refund", "Issue Refund for Amount of Overpayment", rectangle), arrow, yes);
                    flowchart.AddPair("Overpayment?", ("Contact Costumer", "Contact Customer to Request Balance of Payment", rectangle), arrow, no);

                    flowchart.AddPair("Issue Refund", "Record Receipt", "BackArrow");
                    flowchart.AddPair("Contact Costumer", "Receive Payment", "BackArrow");
                }
                else if (i == 9)
                {
                    flowchart.AddPair(("Start", "Start", stadium), ("Emergency?", "Is it an Emergency?", rhombus), arrow);
                    flowchart.AddPair("Emergency?", ("War?", "Did the US declare War?", rhombus), arrow, yes);
                    flowchart.AddPair("War?", ("Zombie?", "Is it a Zombie Attack?", rhombus), arrow, no);
                    flowchart.AddPair("Zombie?", ("Fire?", "Is there a Fire?", rhombus), arrow, no);
                    flowchart.AddPair("Fire?", ("Dead?", "Is Someone Dead?", rhombus), arrow, no);
                    flowchart.AddPair("Dead?", ("Sad later", "I'll be sad later. Let me be happy now", rectangle), arrow, yes);
                    flowchart.AddPair("Sad later", ("End", "End", stadium), arrow);

                    flowchart.AddPair("War?", ("Evacuating?", "Are we evacuating?", rhombus), arrow, yes);
                    flowchart.AddPair("Zombie?", "Evacuating?", "SideArrow", yes);
                    flowchart.AddPair("Fire?", "Evacuating?", "SideArrow", yes);
                    flowchart.AddPair("Evacuating?", ("Knock", "KNOCK!", rectangle), arrow, yes);


                    flowchart.AddPair("Emergency?", ("Visiting?", "Is someone visiting?", rhombus), arrow, no);

                    flowchart.AddPair("Visiting?", ("They can wait", "They can wait", rectangle), arrow, yes);
                    flowchart.AddPair("Visiting?", ("Going somewhere?", "Are you going somewhere?", rhombus), arrow, no);
                    flowchart.AddPair("Going somewhere?", ("Tell me later", "Tell me later", rectangle), arrow, no);
                    flowchart.AddPair("Going somewhere?", ("Leave a note", "Leave a note", rectangle), arrow, yes);

                    flowchart.AddPair("Evacuating?", "Tell me later", arrow, yes);
                    flowchart.AddPair("Dead?", "Tell me later", "SideArrow", yes);
                }
            }
        }
    }
}