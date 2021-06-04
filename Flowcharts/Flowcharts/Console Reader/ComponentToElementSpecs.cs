using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class ComponentToElementSpecs
    {
        readonly string component;
        readonly Flowchart flowchart;

        public ComponentToElementSpecs(string component, Flowchart flowchart)
        {
            this.component = component;
            this.flowchart = flowchart;
        }

        public (string key, string text, string shape) GetComponents()
        {
            string key = null;
            string text = null;
            string shape = null;

            int firstIndex = -1;
            int middleIndex = -1;
            int lastIndex = -1;

            if (component.IndexOf("([") < component.IndexOf("])") && component.IndexOf("([") != -1 && component.IndexOf("])") != -1)
            {
                shape = "Stadium";

                firstIndex = component.IndexOf("([");
                middleIndex = firstIndex + 2;
                lastIndex = component.IndexOf("])");
            }
            else if (component.IndexOf("[[") < component.IndexOf("]]") && component.IndexOf("[[") != -1 && component.IndexOf("]]") != -1)
            {
                shape = "Subroutine";

                firstIndex = component.IndexOf("[[");
                middleIndex = firstIndex + 2;
                lastIndex = component.IndexOf("]]");
            }
            else if (component.IndexOf("[(") < component.IndexOf(")]") && component.IndexOf("[(") != -1 && component.IndexOf(")]") != -1)
            {
                shape = "Cylinder";

                firstIndex = component.IndexOf("[(");
                middleIndex = firstIndex + 2;
                lastIndex = component.IndexOf(")]");
            }
            else if (component.IndexOf("((") < component.IndexOf("))") && component.IndexOf("((") != -1 && component.IndexOf("))") != -1)
            {
                shape = "Circle";

                firstIndex = component.IndexOf("((");
                middleIndex = firstIndex + 2;
                lastIndex = component.IndexOf("))");
            }
            else if (component.IndexOf(">") < component.IndexOf("]") && component.IndexOf(">") != -1 && component.IndexOf("]") != -1)
            {
                shape = "Banner";

                firstIndex = component.IndexOf(">");
                middleIndex = firstIndex + 1;
                lastIndex = component.IndexOf("]");
            }
            else if (component.IndexOf("{{") < component.IndexOf("}}") && component.IndexOf("{{") != -1 && component.IndexOf("}}") != -1)
            {
                shape = "Hexagon";

                firstIndex = component.IndexOf("{{");
                middleIndex = firstIndex + 2;
                lastIndex = component.IndexOf("}}");

            }
            else if (component.IndexOf("{") < component.IndexOf("}") && component.IndexOf("{") != -1 && component.IndexOf("}") != -1)
            {
                shape = "Rhombus";

                firstIndex = component.IndexOf("{");
                middleIndex = firstIndex + 1;
                lastIndex = component.IndexOf("}");
            }
            else if (component.IndexOf("[/") < component.IndexOf("/]") && component.IndexOf("[/") != -1 && component.IndexOf("/]") != -1)
            {
                shape = "Parallelogram";

                firstIndex = component.IndexOf("[/");
                middleIndex = firstIndex + 2;
                lastIndex = component.IndexOf("/]");
            }
            else if (component.IndexOf("[\\") < component.IndexOf("\\]") && component.IndexOf("[\\") != -1 && component.IndexOf("\\]") != -1)
            {
                shape = "ParallelogramAlt";

                firstIndex = component.IndexOf("[\\");
                middleIndex = firstIndex + 2;
                lastIndex = component.IndexOf("\\]");
            }
            else if (component.IndexOf("[/") < component.IndexOf("\\]") && component.IndexOf("[/") != -1 && component.IndexOf("\\]") != -1)
            {
                shape = "Trapezoid";

                firstIndex = component.IndexOf("[/");
                middleIndex = firstIndex + 2;
                lastIndex = component.IndexOf("\\]");
            }
            else if (component.IndexOf("[\\") < component.IndexOf("/]") && component.IndexOf("[\\") != -1 && component.IndexOf("/]") != -1)
            {
                shape = "TrapezoidAlt";

                firstIndex = component.IndexOf("[\\");
                middleIndex = firstIndex + 2;
                lastIndex = component.IndexOf("/]");
            }
            else if (component.IndexOf("[") < component.IndexOf("]") && component.IndexOf("[") != -1 && component.IndexOf("]") != -1)
            {
                shape = "Rectangle";
                firstIndex = component.IndexOf("[");
                middleIndex = firstIndex + 1;
                lastIndex = component.IndexOf("]");
            }
            else if (component.IndexOf("(") < component.IndexOf(")") && component.IndexOf("(") != -1 && component.IndexOf(")") != -1)
            {
                shape = "RoundedRectangle";
                firstIndex = component.IndexOf("(");
                middleIndex = firstIndex + 1;
                lastIndex = component.IndexOf(")");
            }
            else
            {
                var dictionary = flowchart.elementRegister.dictionary;

                if (dictionary.ContainsKey(component.Trim()))
                {
                    key = dictionary[component].Key;
                    text = dictionary[component].Text;

                    return (key, text, null);
                }

                throw new InputFormatException("Shape paranthesis is incorrect or id does not belong to a previously declared element");
            }

            key = component.Substring(0, firstIndex).Trim();
            text = component[middleIndex..lastIndex].Trim();

            return (key, text, shape);
        }
    }


}
