using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Flowcharts
{
    public class FlowchartDictionarytoGridHandler
    {
        readonly Grid grid = new Grid();
        readonly FlowchartElementManager elementManager;

        public FlowchartDictionarytoGridHandler(FlowchartElementManager elementManager)
        {
            this.elementManager = elementManager;
        }

        public Grid ToGrid()
        {
            var columns = elementManager.GroupBy(x => x.Column);

            foreach (var column in columns)
            {
                int i = 0;

                foreach (var element in column)
                {
                    grid.Add(element, i++, column.Key);
                }
            }

            return grid;
        }
    }
}
