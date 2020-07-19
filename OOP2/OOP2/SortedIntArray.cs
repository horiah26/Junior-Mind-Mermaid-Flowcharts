using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2
{
    public class SortedIntArray : IntArray
    {
        public SortedIntArray() : base()
        {
        }

        public override void Insert(int index, int element)
        {
            if (lastElementPosition == -1 || 
                index == 0 && array[0] >= element || 
                index != 0 && array[index - 1] <= element && (array[index] >= element || index == lastElementPosition + 1))
            {
                Add(element);
            }
        }

        public override void Add(int element)
        {          
            if (lastElementPosition == -1 || base[0] >= element)
            {
                base.Insert(0, element);
                return;
            }
            else if (base[lastElementPosition] <= element)
            {
                base.Insert(lastElementPosition + 1, element);
                return;
            }

            for (int i = 1; i < Count; i++)
            {
                if (array[i - 1] < element && array[i] >= element)
                {
                    base.Insert(i, element);
                    return;
                }
            }
        }

        public override int this[int index]
        {
            get => array[index];
            set => Insert(index, value);
        }
    }    
}