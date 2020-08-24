using System;
using System.Collections;
using System.Collections.Generic;

namespace OOP2
{
    public class List<T> : IList<T>
    {
        private T[] listArray;

        public int Count { get; private set; }

        public bool IsReadOnly { get; private set; }

        public List()
        {
            listArray = new T[4];
        }

        public virtual T this[int index]
        {
            get => listArray[index];
            set => listArray[index] = value;
        }

        public virtual void Add(T element)
        {
            ResizeIfNeeded();
            listArray[Count] = element;
            Count++;
        }

        public bool Contains(T element)
        {
            return (IndexOf(element) != -1);
        }

        public int IndexOf(T element)
        {
            int index = Array.IndexOf(listArray, element);
            return (index >= 0 && index < Count) ? index : -1;
        }

        public virtual void Insert(int index, T element)
        {
            ResizeIfNeeded();
            ShiftRight(listArray, index);

            listArray[index] = element;
            Count++;
        }

        public void Clear()
        {
            Count = 0;
        }

        public void RemoveAt(int index)
        {
            ShiftLeft(listArray, index);
            Count--;
        }

        private void ResizeIfNeeded()
        {
            if (Count >= listArray.Length)
            {
                Array.Resize(ref listArray, listArray.Length * 2);
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if(array.Length - arrayIndex <= Count || arrayIndex < 0 || array == null)
            {
                throw new ArgumentException("Wrong Array dimension or Index");
            }
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    array[arrayIndex + i] = listArray[i];
                }               
            }
        }

        public bool Remove(T element)
        {
            if (IndexOf(element) != -1)
            {
                RemoveAt(IndexOf(element));
                return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i< Count; i++)
            {
                yield return listArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void ShiftLeft(T[] array, int index)
        {
            for (int i = index; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
        }

        private void ShiftRight(T[] array, int index)
        {
            for (int i = array.Length - 1; i > index; i--)
            {
                array[i] = array[i - 1];
            }
        }
    }
}