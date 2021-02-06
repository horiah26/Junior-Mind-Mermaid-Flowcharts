using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class FlowchartArrowManager : IEnumerable
    {
        public List<Arrow> arrows = new List<Arrow> { };

        public FlowchartArrowManager() { }

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
