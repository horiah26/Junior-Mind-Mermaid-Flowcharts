using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace OOP2
{
    public class List<T> : IEnumerable
    {        
        protected T[] listArray;

        protected int lastElementPosition = -1;

        public List()
        {
            listArray = new T[4];
        }

        public int Count => listArray.Length;

        public virtual T this[int index]
        {
            get => listArray[index];
            set => listArray[index] = value;
        }

        public virtual void Add(T element)
        {
            ResizeIfNeeded();

            listArray[lastElementPosition] = element;
        }

        public bool Contains(T element)
        {
            return (IndexOf(element) != -1);
        }

        public int IndexOf(T element)
        {
            return Array.IndexOf(listArray, element);
        }

        public virtual void Insert(int index, T element)
        {
            ResizeIfNeeded();

            for (int i = listArray.Length - 1; i > index; i--)
            {
                listArray[i] = listArray[i - 1];
            }

            listArray[index] = element;
        }

        public void Clear()
        {
            listArray = new T[0];
            lastElementPosition = -1;
        }

        public void Remove(T element)
        {
            if(IndexOf(element) != -1)
            {
                RemoveAt(IndexOf(element));
                lastElementPosition--;
            }
        }     
        
        public void RemoveAt(int index)
        {
            for (int i = index; i < listArray.Length - 1; i++)
            {
                listArray[i] = listArray[i + 1];
            }

            lastElementPosition--;
        }

        private void ResizeIfNeeded()
        {
            lastElementPosition++;

            if (lastElementPosition == listArray.Length)
            {
                Array.Resize(ref listArray, listArray.Length * 2);
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return listArray[i];
            }
        }
    }
}
