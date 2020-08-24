using System;

namespace OOP2
{
    public class IntArray
    {
        private int[] array;

        public int Count { get; private set; }

        public IntArray()
        {
            this.array = new int[4];
        }

        public virtual int this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public virtual void Add(int element)
        {
            ResizeIfNeeded();
            array[Count] = element;
            Count++;

        }

        public bool Contains(int element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(int element)
        {
            int index = Array.IndexOf(array, element);
            return (index >= 0 && index < Count) ? index : -1;
        }

        public virtual void Insert(int index, int element)
        {
            ResizeIfNeeded();
            shiftRight(array, index);

            array[index] = element;
            Count++;          
        }

        public void Clear()
        {
            Count = 0;
        }

        public void Remove(int element)
        {
            if(IndexOf(element) != -1)
            {
                RemoveAt(IndexOf(element));
            }            
        }

        public void RemoveAt(int index)
        {
            shiftLeft(array, index);
            Count--;
        }

        private void shiftLeft(int[] array, int index)
        {
            for (int i = index; i < Count; i++)
            {
                array[i] = array[i + 1];
            }
        }

        private void shiftRight(int[] array, int index)
        {
            for (int i = Count; i > index; i--)
            {
                array[i] = array[i - 1];
            }
        }

        private void ResizeIfNeeded()
        {  
            if (Count >= array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }
        }
    }
}