using System.Collections;
using System.Collections.Generic;

namespace Flowcharts
{
    public class ArrowRegister : IEnumerable
    {
        public List<IArrow> arrows = new List<IArrow> { };

        public ArrowRegister() { }

        public void Add(IArrow arrow)
        {
            arrows.Add(arrow);
        }

        public List<IArrow> GetList()
        {
            return arrows;
        }

        public IEnumerator GetEnumerator()
        {
            foreach(var arrow in arrows)
            {
                yield return arrow;
            }
        }
    }
}
