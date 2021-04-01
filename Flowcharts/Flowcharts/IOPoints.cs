namespace Flowcharts
{
    class IOPoints
    {
        public (double x, double y) In;
        public (double x, double y) Out;
        public (double x, double y) BackArrowIn;

        public IOPoints((double x, double y) In, (double x, double y) Out)
        {
            this.In = In;
            this.Out = Out;
        }

        public IOPoints((double x, double y) In, (double x, double y) Out, (double x, double y) BackArrowIn)
        {
            this.In = In;
            this.Out = Out;
            this.BackArrowIn = BackArrowIn;
        }
    }
}
