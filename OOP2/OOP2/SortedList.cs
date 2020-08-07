using System;

namespace OOP2
{
    public class SortedList<T> : List<T> where T : IComparable<T>
    {
        public SortedList() : base(){}

        public override void Insert(int index, T element)
        {
            if (lastElementPosition == -1 ||
              index == 0 && listArray[0].CompareTo(element) >= 0 || 
              index != 0 && listArray[index - 1].CompareTo(element) <= 0 
              && (listArray[index].CompareTo(element) >= 0 || index == lastElementPosition + 1))
            {
                Add(element);
            }
        }

        public override void Add(T element)
        {
            if (lastElementPosition == -1 || base[0].CompareTo(element) >= 0)
            {
                base.Insert(0, element);
                return;
            }
            else if (base[lastElementPosition].CompareTo(element) <= 0)
            {
                base.Insert(lastElementPosition + 1, element);
                return;
            }

            for (int i = 1; i < Count; i++)
            {
                if (listArray[i - 1].CompareTo(element) < 0 && listArray[i].CompareTo(element) >= 0)
                {
                    base.Insert(i, element);
                    return;
                }
            }
        }
    }
}
