using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Flowcharts
{
    class GridWithLinearizedSubsystem : IGrid
    {
        public Element[,] ElementArray { get; private set; }

        public GridWithLinearizedSubsystem(IGrid grid)
        {
            ElementArray = ArrayOperations.CloneArray(grid);
            ElementArray = ArrayOperations.LevelElementsIndividually(ElementArray);
        }
    }
}
