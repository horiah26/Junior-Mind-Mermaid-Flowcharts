using System.Collections.Generic;
using System.Linq;

namespace Flowcharts
{
    public class LastColumn
    {
        readonly Element[,] elementArray;
        public int Index { get; private set; }
        public IEnumerable<Element> Column { get; private set; }

        public LastColumn(Element[,] elementArray)
        {
            this.elementArray = elementArray;
            GetColumn();
        }

        private IEnumerable<Element> GetColumn()
        {
            GetIndex();
            var Column = ArrayOperations.ExtractColumn(elementArray, Index).Where(x => x != null);
            this.Column = Column;
            return Column;
        }

        private int GetIndex()
        {
            int index = 0;

            foreach(var element in elementArray)
            {
                if(element != null && element.Column > index)
                {
                    index = element.Column;
                }
            }

            Index = index;
            return index;
        }
    }
}
