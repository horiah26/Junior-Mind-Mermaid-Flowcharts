namespace Flowcharts
{
    public interface IArrow
    {
        public void Draw();
        public (Element fromElement, Element toElement) GetElementPair();
    }
}
