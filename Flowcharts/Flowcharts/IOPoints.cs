namespace Flowcharts
{
    public class IOPoints
    {
        public (double x, double y) In { get; set; }
        public (double x, double y) Out { get; set; }
        public (double x, double y) BackArrowLeft { get; set; }
        public (double x, double y) BackArrowRight { get; set; }

        public IOPoints((double x, double y) In, (double x, double y) Out, (double x, double y) BackArrowLeft, (double x, double y) BackArrowRight)
        {
            this.In = In;
            this.Out = Out;
            this.BackArrowLeft = BackArrowLeft;
            this.BackArrowRight = BackArrowRight;
        }
    }
}
