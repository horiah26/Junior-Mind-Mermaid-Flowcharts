using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    public interface IOrientation
    {
        public void Initialize(int Column, int Row, (double x, double y) In, (double x, double y) Out, int columnSize, int rowSize);
        public (int Column, int Row) GetColumnRow();
    }
}
