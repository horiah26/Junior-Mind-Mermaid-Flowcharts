using System;

namespace OOP2
{
    public class SortedIntArray : IntArray
    {
        public SortedIntArray() : base()
        {
        }

        public override int this[int index]
        {
            get => base[index];
            set
            {
                if (canInsert(index, value))
                {
                    base[index] = value;
                }
            }
        }

        public override void Insert(int index, int element)
        {
            if (Count == 0 || 
                index == 0 && base[0] >= element || 
                index != 0 && base[index - 1] <= element && (base[index] >= element || index == Count))
            {
                base.Insert(index, element);
            }
        }

        public override void Add(int element)
        {
            if (Count == 0 || base[0] >= element)
            {
                base.Insert(0, element);
                return;      
            }
            else if (base[Count - 1] <= element)
            {
                base.Insert(Count, element);
                return;
            }

            base.Insert(searchPosition(element), element);
        }

        private int searchPosition(int element)
        {
            for (int i = 1; i < Count; i++)
            {
                if (base[i - 1] < element && base[i] >= element)
                {
                    return i;
                }
            }

            throw new Exception("Position cannot be found");
        }

        public bool canInsert(int index, int element)
        {
            return (Count == 0 ||
             index == 0 && base[0] >= element ||
             index != 0 && base[index - 1] <= element && (base[index] >= element || index == Count));
        }
    }    
}