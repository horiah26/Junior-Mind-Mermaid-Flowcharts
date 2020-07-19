using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2
{
    public class ObjectArray
    {
        protected object[] array = new object[4];

        protected int lastElementPosition = -1;

        public ObjectArray()
        {
            this.array = new object[4];
        }

        public int Count => array.Length;

        public virtual object this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public virtual void Add(object element)
        {
            ResizeIfNeeded();

            array[lastElementPosition] = element;
        }

        public bool Contains(object element)
        {
            return Array.Exists(array, item => item == element);
        }

        public int IndexOf(object element)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public virtual void Insert(int index, int element)
        {
            ResizeIfNeeded();

            for (int i = array.Length - 1; i > index; i--)
            {
                array[i] = array[i - 1];
            }

            array[index] = element;
        }

        public void Clear()
        {
            array = new object[0];
            lastElementPosition = -1;
        }

        public void Remove(object element)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                {
                    RemoveAt(i);
                    break;
                }
            }

            lastElementPosition--;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }

            lastElementPosition--;
        }

        private void ResizeIfNeeded()
        {
            lastElementPosition++;

            if (lastElementPosition == array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }
        }
    }
}
