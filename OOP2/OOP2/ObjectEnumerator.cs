using System.Collections;

namespace OOP2
{
    public class ObjectEnumerator : IEnumerator
    {
        private readonly ObjectArray objArray;
        private int position = -1;

        public ObjectEnumerator(ObjectArray array)
        {
            objArray = array;
        }

        public object Current => objArray[position];

        public bool MoveNext()
        {
            position++;

            return position < objArray.Count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}

