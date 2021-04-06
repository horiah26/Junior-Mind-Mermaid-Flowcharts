using System.Collections.Generic;

namespace Flowcharts
{
    public interface IGrid
    {
        Element[,] ElementArray { get; }

        public IEnumerator<Element> GetEnumerator() 
        {
            foreach (Element element in ElementArray)
            {
                if (element != null)
                {
                    yield return element;
                }
            } 
        }        
    }
}