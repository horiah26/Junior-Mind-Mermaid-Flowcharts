namespace Flowcharts
{
    class IOPoints
    {
        public (double x, double y) In;
        public (double x, double y) Out;
        public (double x, double y) BackArrowEntry;

        public IOPoints((double x, double y) In, (double x, double y) Out, (double x, double y) BackArrowEntry)
        {
            this.In = In;
            this.Out = Out;
            this.BackArrowEntry = BackArrowEntry;
        }
    }
}
