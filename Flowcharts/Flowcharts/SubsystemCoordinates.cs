namespace Flowcharts
{
    public class SubsystemCoordinates
    {
        public (double xPos, double yPos) cornerLeftUp;
        public (double xPos, double yPos) cornerLeftDown;
        public (double xPos, double yPos) cornerRightUp;
        public (double xPos, double yPos) cornerRightDown;

        public string Coordinates { get; private set; }
        public  (double xPos, double yPos) TextPosition { get; private set; }

        public SubsystemCoordinates((double xPos, double yPos) cornerLeftUp, (double xPos, double yPos) cornerLeftDown, (double xPos, double yPos) cornerRightUp, (double xPos, double yPos) cornerRightDown, (double xPos, double yPos) textPosition)
        {
            this.cornerLeftDown = cornerLeftDown;
            this.cornerLeftUp = cornerLeftUp;
            this.cornerRightDown = cornerRightDown;
            this.cornerRightUp = cornerRightUp;

            Coordinates = cornerLeftUp.xPos.ToString() + "," + cornerLeftUp.yPos.ToString() + " " + cornerLeftDown.xPos.ToString() + "," + cornerLeftDown.yPos.ToString()
            + " " + cornerRightDown.xPos.ToString() + "," + cornerRightDown.yPos.ToString() + " " + cornerRightUp.xPos.ToString() + "," + cornerRightUp.yPos.ToString();

            TextPosition = textPosition;
        }
    }
}
