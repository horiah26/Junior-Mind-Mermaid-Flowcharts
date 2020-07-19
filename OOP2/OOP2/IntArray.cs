using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OOP2
{
    public class IntArray
    {
        protected int[] array = new int[4];

        protected int lastElementPosition = -1;

        public IntArray()
        {
            this.array = new int[4];
        }

        public int Count => array.Length;

        public virtual int this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public virtual void Add(int element)
        {
            ResizeIfNeeded();

            array[lastElementPosition] = element;
        }

        public bool Contains(int element)
        {
            return Array.Exists(array, item => item == element);
        }

        public int IndexOf(int element)
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
            array = new int[0];
            lastElementPosition = -1;
        }

        public void Remove(int element)
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