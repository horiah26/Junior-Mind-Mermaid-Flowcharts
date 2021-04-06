using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    public class OrderedArrows
    {
        readonly ArrowRegister arrowRegister;

        public OrderedArrows(ArrowRegister arrowRegister)
        {
            this.arrowRegister = arrowRegister;
        }

        private List<Arrow> ArrangeArrows()
        {
            var forwardArrows = new List<Arrow>() { };
            var backArrows = new List<Arrow>() { };

            foreach (Arrow arrow in arrowRegister)
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

            return backArrows;
        }

        public void DrawArrows()
        {
           var arrows = ArrangeArrows();

            foreach (Arrow arrow in arrows)
            {
                arrow.Draw();
            }

            foreach (Arrow arrow in arrows)
            {
                arrow.Write();
            }

        }
    }
}
