using System;

namespace OOP2
{
    public class SortedList<T> : List<T> where T : IComparable<T>
    {
        public SortedList() : base(){}

        public override void Insert(int index, T element)
        {
            if (canInsert(index, element))
            {
                base.Insert(index, element);
            }
        }

        public override void Add(T element)
        {
            if (Count == 0 || base[0].CompareTo(element) >= 0)
            {
                base.Insert(0, element);
                return;
            }
            else if (base[Count - 1].CompareTo(element) <= 0)
            {
                base.Insert(Count, element);
                return;
            }

            base.Insert(searchPosition(element), element);
        }
        private int searchPosition(T element)
        {
            for (int i = 1; i < Count; i++)
            {
                if (base[i - 1].CompareTo(element) < 0 && base[i].CompareTo(element) >= 0)
                {
                    return i;
                }
            }

            throw new Exception("Position cannot be found");
        }
        public bool canInsert(int index, T element)
        {
            return (Count == 0 ||
            index == 0 && base[0].CompareTo(element) >= 0 ||
            index != 0 && base[index - 1].CompareTo(element) <= 0
            && (base[index].CompareTo(element) >= 0 || index == Count));
        }

    }
}
