using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    public class OrderedArrows : IArrowRegister
    {
        public List<IArrow> ArrowList { get; private set; }

        public OrderedArrows(ArrowRegister arrowRegister)
        {
            ArrowList = arrowRegister.ArrowList;
            ArrangeArrows();
        }

        private void ArrangeArrows()
        {
            var forwardArrows = new List<IArrow>() { };
            var backArrows = new List<IArrow>() { };

            foreach (IArrow arrow in ArrowList)
            {
                if (typeof(BackArrow) == arrow.GetType())
                {
                    backArrows.Add(arrow);
                }
                else
                {
                    forwardArrows.Add(arrow);
                }
            }

            backArrows.AddRange(forwardArrows);

            ArrowList = backArrows;
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

        public IEnumerator GetEnumerator()
        {
            foreach (var arrow in ArrowList)
            {
                yield return arrow;
            }
        }
    }
}
