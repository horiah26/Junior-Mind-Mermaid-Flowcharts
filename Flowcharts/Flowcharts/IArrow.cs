namespace Flowcharts
{
    public interface IArrow
    {
        public Element fromElement { get; set; }
        public Element toElement { get; set; }

        public void Draw();
        public void Write();
        public (Element fromElement, Element toElement) GetElementPair();
    }
}
