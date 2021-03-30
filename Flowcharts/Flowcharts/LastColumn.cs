using System.Collections.Generic;
using System.Linq;

namespace Flowcharts
{
    public class LastColumn
    {
        readonly Grid grid;
        public int Index { get; private set; }
        public IEnumerable<Element> Column { get; private set; }

        public LastColumn(Grid grid)
        {
            this.grid = grid;
            GetColumn();
        }

        private IEnumerable<Element> GetColumn()
        {
            GetIndex();
            var Column = new ExtractedColumn(grid, Index).GetColumn().Where(x => x != null);
            this.Column = Column;
            return Column;
        }

        private int GetIndex()
        {
            int index = 0;

            foreach(var element in grid)
            {
                if(element.Column > index)
                {
                    index = element.Column;
                }
            }

            Index = index;
            return index;
        }
    }
}
