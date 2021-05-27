using System;

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



            //Console.WriteLine("Orientation? LeftRight / RightLeft / TopDown / DownTop");
            //string orientation = Console.ReadLine();


            string line = "";
            while (line != "end")
            {
                line = Console.ReadLine();
                if (line != "")
                {
                    AnalyzeLine(line);
                }    
            }

            //var flowchart = Factory.Flowchart(orientation, "test");
            //GridSpacing.SetLarge();
                    
            void AnalyzeLine(string line)
            {               
                var str = SeparateElements(line);
                for (int i = 0; i < 2; i++) 
                {
                    IdentifyShape(str[i]);
                }
            }

            string[] SeparateElements(string line)
            {
                string element1 = null;
                string element2 = null;

                string secondHalf = null;
                string arrow = null;
                string text = null;

                if (line.IndexOf("-->") != -1)
                {
                    var index = line.IndexOf("-->");
                    element1 = line.Substring(0, index).Trim();
                    secondHalf = line[(index + 3)..].Trim();
                    (text, element2) = SeparateArrowTextFromElement2(secondHalf);
                    arrow = "Arrow";
                }
                else if (line.IndexOf("/-->") != -1)
                {
                    var index = line.IndexOf("/-->");
                    element1 = line.Substring(0, index).Trim();
                    secondHalf = line[(index + 4)..].Trim();
                    (text, element2) = SeparateArrowTextFromElement2(secondHalf);
                    arrow = "SideArrow";
                }
                else if (line.IndexOf("---") != -1)
                {
                    var index = line.IndexOf("---");
                    element1 = line.Substring(0, index).Trim();
                    secondHalf = line[(index + 3)..].Trim();
                    (text, element2) = SeparateArrowTextFromElement2(secondHalf);
                    arrow = "Link";
                }
                else if (line.IndexOf("-.->") != -1)
                {
                    var index = line.IndexOf("-.->");
                    element1 = line.Substring(0, index).Trim();
                    secondHalf = line[(index + 4)..].Trim();
                    (text, element2) = SeparateArrowTextFromElement2(secondHalf);
                    arrow = "DottedLink";
                }
                else if (line.IndexOf("==>") != -1)
                {
                    var index = line.IndexOf("==>");
                    element1 = line.Substring(0, index).Trim();
                    secondHalf = line[(index + 3)..].Trim();
                    (text, element2) = SeparateArrowTextFromElement2(secondHalf);
                    arrow = "ThickLink";
                }
                
                return new string[] { element1, element2, arrow, text };
            }

            (string text, string element2) SeparateArrowTextFromElement2(string secondHalf)
            {
                string text = null;
                string element2 = secondHalf;
                int textStart = secondHalf.IndexOf("|");
                int textEnd = secondHalf.LastIndexOf("|");

                if (textStart != textEnd)
                {
                    text = secondHalf.Substring(textStart + 1, secondHalf.Length - textEnd - 1).Trim();
                    element2 = secondHalf[(textEnd + 1)..].Trim();
                }

                return (text, element2);
            }

            (string key, string text, string shape) IdentifyShape(string element)
            {
                string key = null;
                string text = null;
                string shape = null;

                int firstIndex = -1;
                int middleIndex = -1;
                int lastIndex = -1;

                if (element.IndexOf("([") < element.IndexOf("])") && element.IndexOf("([") != -1 && element.IndexOf("])") != -1)
                {
                    shape = "Stadium";

                    firstIndex = element.IndexOf("([");
                    middleIndex = firstIndex + 2;
                    lastIndex = element.IndexOf("])");
                }
                else if (element.IndexOf("[[") < element.IndexOf("]]") && element.IndexOf("[[") != -1 && element.IndexOf("]]") != -1)
                {
                    shape = "Subroutine";

                    firstIndex = element.IndexOf("[[");
                    middleIndex = firstIndex + 2;
                    lastIndex = element.IndexOf("]]");
                }
                else if (element.IndexOf("[(") < element.IndexOf(")]") && element.IndexOf("[(") != -1 && element.IndexOf(")]") != -1)
                {
                    shape = "Cylinder";

                    firstIndex = element.IndexOf("[(");
                    middleIndex = firstIndex + 2;
                    lastIndex = element.IndexOf(")]");
                }
                else if (element.IndexOf("((") < element.IndexOf("))") && element.IndexOf("((") != -1 && element.IndexOf("))") != -1)
                {
                    shape = "Circle";

                    firstIndex = element.IndexOf("((");
                    middleIndex = firstIndex + 2;
                    lastIndex = element.IndexOf("))");
                }
                else if (element.IndexOf(">") < element.IndexOf("]") && element.IndexOf(">") != -1 && element.IndexOf("]") != -1)
                {
                    shape = "Banner";

                    firstIndex = element.IndexOf(">");
                    middleIndex = firstIndex + 1;
                    lastIndex = element.IndexOf("]");
                }
                else if (element.IndexOf("{{") < element.IndexOf("}}") && element.IndexOf("{{") != -1 && element.IndexOf("}}") != -1)
                {
                    shape = "Hexagon";

                    firstIndex = element.IndexOf("{{");
                    middleIndex = firstIndex + 2;
                    lastIndex = element.IndexOf("}}");

                }
                else if (element.IndexOf("{") < element.IndexOf("}") && element.IndexOf("{") != -1 && element.IndexOf("}") != -1)
                {
                    shape = "Rhombus";

                    firstIndex = element.IndexOf("{");
                    middleIndex = firstIndex + 1;
                    lastIndex = element.IndexOf("}");
                }
                else if (element.IndexOf("[/") < element.IndexOf("/]") && element.IndexOf("[/") != -1 && element.IndexOf("/]") != -1)
                {
                    shape = "Parallelogram";

                    firstIndex = element.IndexOf("[/");
                    middleIndex = firstIndex + 2;
                    lastIndex = element.IndexOf("/]");
                }
                else if (element.IndexOf("[\\") < element.IndexOf("\\]") && element.IndexOf("[\\") != -1 && element.IndexOf("\\]") != -1)
                {
                    shape = "ParallelogramAlt";

                    firstIndex = element.IndexOf("[\\");
                    middleIndex = firstIndex + 2;
                    lastIndex = element.IndexOf("\\]");
                }
                else if (element.IndexOf("[/") < element.IndexOf("\\]") && element.IndexOf("[/") != -1 && element.IndexOf("\\]") != -1)
                {
                    shape = "Trapezoid";

                    firstIndex = element.IndexOf("[/");
                    middleIndex = firstIndex + 2;
                    lastIndex = element.IndexOf("\\]");
                }
                else if (element.IndexOf("[\\") < element.IndexOf("/]") && element.IndexOf("[\\") != -1 && element.IndexOf("/]") != -1)
                {
                    shape = "TrapezoidAlt";

                    firstIndex = element.IndexOf("[\\");
                    middleIndex = firstIndex + 2;
                    lastIndex = element.IndexOf("/]");
                }
                else if (element.IndexOf("(") < element.IndexOf(")") && element.IndexOf("(") != -1 && element.IndexOf(")") != -1)
                {
                    shape = "RoundedRectangle";
                    firstIndex = element.IndexOf("(");
                    middleIndex = firstIndex + 1;
                    lastIndex = element.IndexOf(")");
                }
                else if (element.IndexOf("[") < element.IndexOf("]") && element.IndexOf("[") != -1 && element.IndexOf("]") != -1)
                {
                    shape = "Rectangle";
                    firstIndex = element.IndexOf("[");
                    middleIndex = firstIndex + 1;
                    lastIndex = element.IndexOf("]");
                }
                else
                {
                    throw new ArgumentException("Shape paranthesis is incorrect");
                }

                key = element.Substring(0, firstIndex);
                text = element.Substring(middleIndex, lastIndex - middleIndex);

                return (key, text, shape);
            }
        }
    }
}