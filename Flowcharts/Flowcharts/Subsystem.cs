using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flowcharts
{
    public class Subsystem
    {
        public string Name { get; private set; }
        public string Color { get; set; }

        public Subsystem(string name)
        {
            Name = name;
        }

        public (int lowestRow, int lowestColumn, int highestRow, int highestColumn) GetSubsystemLocation(Element[,] ElementArray)
        {
            List<(int row, int column)> coordinates = new List<(int row, int column)> { };

            for (int i = 0; i < ElementArray.GetLength(0); i++)
            {
                for (int j = 0; j < ElementArray.GetLength(1); j++)
                {
                    if (ElementArray[i, j] != null && ElementArray[i, j].Subsystems.Contains(this))
                    {
                        coordinates.Add((i, j));
                    }
                }
            }

            int lowestRow = coordinates.Min(x => x.row);
            int lowestColumn = coordinates.Min(x => x.column);

            int highestRow = coordinates.Max(x => x.row);
            int highestColumn = coordinates.Max(x => x.column);

            return (lowestRow, lowestColumn, highestRow, highestColumn);
        }
    }
}
