using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace LINQ
{
    class ThenBy
    {

        public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(
            this IOrderedEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IComparer<TKey> comparer)
        {


        }

        public class CustomComparer<TSource, TKey> : IComparer<TSource>
        {
            readonly Func<TSource, TKey> keySelector;
            readonly IComparer<TKey> comparer;

            public CustomComparer(Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
            {
                this.keySelector = keySelector;
                this.comparer = comparer;
            }

            public int Compare([AllowNull] TSource x, [AllowNull] TSource y)
            {
                return comparer.Compare(keySelector(x), keySelector(y));
            }
        }

        public class LinkerComparer<TSource, TKey> : IComparer<TSource>
        {
            IOrderedEnumerable<IComparer<TSource>> comparers;

            public LinkerComparer(IOrderedEnumerable<IComparer<TSource>> comparers)
            {
                this.comparers = comparers;
            }

            public int Compare([AllowNull] TSource x, [AllowNull] TSource y)
            {
                var comparerEnum = comparers.GetEnumerator();

                while (comparerEnum.MoveNext() && comparerEnum.Current.Compare(x, y) == 0) { }

                comparerEnum.MoveNext();

                return comparerEnum.Current.Compare(x, y);
            }
        }

    }
}
