using System.Collections;
using System.Collections.Generic;

namespace Flowcharts
{
    public interface IArrowRegister
    {
        List<IArrow> ArrowList { get; }

        public IEnumerator GetEnumerator()
        {
            foreach (var arrow in ArrowList)
            {
                yield return arrow;
            }
        }

        public void DrawArrows()
        {
            foreach (IArrow arrow in ArrowList)
            {
                arrow.Draw();
            }

            foreach (IArrow arrow in ArrowList)
            {
                arrow.Write();
            }
        }
    }
}