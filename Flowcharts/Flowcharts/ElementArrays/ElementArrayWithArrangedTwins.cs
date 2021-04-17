using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flowcharts
{
    public class ElementArrayWithArrangedTwins : IElementArray
    {
        public Element[,] ElementArray { get; private set; }

        public ElementArrayWithArrangedTwins(Element[,] ElementArray)
        {
            this.ElementArray = ElementArray;
            LinearizeInLoweredTwinSituation();
            LinearizeInTwinsSituationForward();
        }

        private void LinearizeInLoweredTwinSituation()
        {
            var rows = ElementArray.GetLength(0);
            var columns = ElementArray.GetLength(1);

            for (int i = 1; i < rows; i++)
            {
                for (int j = columns - 1; j >= 0; j--)
                {
                    if (ElementArray[i, j] != null
                        && ElementArray[i, j].childElements.Count() == 2)
                    {
                        int difference = Convert.ToInt32(ElementArray[i, j].childElements.Average(x => x.Row)) - i;

                        if (ElementArray[i + difference, j] == null)
                        {
                            ElementArray[i + difference, j] = ElementArray[i, j];
                            ElementArray[i, j] = null;
                            ArrayOperations.Update(ElementArray);
                        }
                    }
                }
            }
        }

        private void LinearizeInTwinsSituationForward()
        {
            var rows = ElementArray.GetLength(0);
            var columns = ElementArray.GetLength(1);

            ElementArray = ArrayOperations.Resize(ElementArray, rows + 1, columns);

            for (int i = 1; i < rows - 1; i++)
            {
                for (int j = 0; j < columns - 1; j++)
                {
                    if (ElementArray[i, j] != null
                        && ElementArray[i, j].childElements.Count() == 2
                        && ElementArray[i, j].parentElements.Count() == 1
                        && ElementArray[i, j].parentElements.First().childElements.Count() == 1
                        && ElementArray[i - 1, j + 1] == ElementArray[i, j].childElements[0]
                        && ElementArray[i + 1, j + 1] == ElementArray[i, j].childElements[1]
                        && ElementArray[i, j].parentElements.First().Row > i
                        )
                    {
                        if (ElementArray[i + 1, j] == null
                            && ElementArray[i, j + 1] == null
                            && ElementArray[i + 2, j + 1] == null)
                        {
                            ElementArray[i + 1, j] = ElementArray[i, j];
                            ElementArray[i, j] = null;

                            ElementArray[i, j + 1] = ElementArray[i - 1, j + 1];
                            ElementArray[i - 1, j + 1] = null;

                            ElementArray[i + 2, j + 1] = ElementArray[i + 1, j + 1];
                            ElementArray[i + 1, j + 1] = null;
                        }
                    }
                }
            }
        }
    }
}
