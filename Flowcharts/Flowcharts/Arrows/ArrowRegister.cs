using System.Collections;
using System.Collections.Generic;

namespace Flowcharts
{
    public class ArrowRegister : IArrowRegister
    {
        public List<IArrow> ArrowList { get; private set; }

        public ArrowRegister() 
        {
            ArrowList = new List<IArrow>() { };
        }

        public void Add(IArrow arrow)
        {
            ArrowList.Add(arrow);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var arrow in ArrowList)
            {
                yield return arrow;
            }
        }
    }
}
