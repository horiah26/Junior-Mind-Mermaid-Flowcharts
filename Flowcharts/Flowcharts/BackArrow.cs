using System;

namespace Flowcharts
{
    class BackArrow : Arrow
    {
        public BackArrow(Element fromElement, Element toElement, string text) : base(fromElement, toElement, text)
        {
            this.FromElement = fromElement;
            this.ToElement = toElement;
        }

        override public void Draw()
        {
            ArrowOperations.DrawBackArrow(FromElement, ToElement, GetArrowPoints());
        }

        public override string[] GetArrowPoints()
        {
            return ArrowOperations.GetBackArrowPoints(FromElement, ToElement);
        }

        public override (double xPosition, double yPosition) CalculatePosition()
        {
            var points = GetArrowPoints();

            return (Convert.ToDouble(points[2]), Convert.ToDouble(points[3]));
        }
    }
}
