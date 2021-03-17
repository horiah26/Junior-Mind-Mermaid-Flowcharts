using System.Collections;
using System.Collections.Generic;

namespace Flowcharts
{
    class ArrowRegister : IEnumerable
    {
        public List<Arrow> arrows = new List<Arrow> { };

        public ArrowRegister() { }

        public void Add(Arrow arrow)
        {
            arrows.Add(arrow);
        }

        public List<Arrow> GetList()
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
