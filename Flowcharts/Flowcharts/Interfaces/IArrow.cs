namespace Flowcharts
{
    public interface IArrow
    {
        public Element FromElement { get; set; }
        public Element ToElement { get; set; }

        public bool PushesChildrenForward { get; }

        public void Draw();
        public void Write();
        public (Element fromElement, Element toElement) GetElementPair();
    }
}