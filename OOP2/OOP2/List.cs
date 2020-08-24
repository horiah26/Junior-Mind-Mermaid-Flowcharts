using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace OOP2
{
    public class List<T> : IList<T>
    {
        private T[] listArray;

        public int Count { get; private set; }

        public bool IsReadOnly { get; private set; } = false;

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
            CheckReadOnly();
            
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
            CheckIndex(index);
            CheckReadOnly();
                        
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
            CheckIndex(index);

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
            if (array == null)
            {
                throw new ArgumentNullException("Array is null");
            }
            else if(arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("Index must be greater than 0");
            }
            else if (array.Length - arrayIndex <= Count)
            {
                throw new ArgumentOutOfRangeException("The number of elements in the source T[] array is greater than the available space from arrayIndex to the end of the destination array.");
            }           
            
            for (int i = 0; i < Count; i++)
            {
                array[arrayIndex + i] = listArray[i];
            }           
        }

        public bool Remove(T element)
        {
            CheckReadOnly();

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
            for (int i = index; i < Count; i++)
            {
                array[i] = array[i + 1];
            }
        }

        private void ShiftRight(T[] array, int index)
        {
            for (int i = Count; i > index; i--)
            {
                array[i] = array[i - 1];
            }
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException("index is not a valid index in the IList<T>.");
            }
        }

        private void CheckReadOnly()
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("List is read only and cannot be modified.");
            }
        }
    }
}