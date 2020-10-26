using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace LINQ
{
    static class ThenByClass
    {
        public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(
            this IOrderedEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IComparer<TKey> comparer)
        {            
            var linkerComparer = new LinkerComparer<TSource, TKey>(new List<IComparer<TSource>>());
            var customSource = new CustomOrderedEnumerable<TSource, TKey>(source, linkerComparer);
            var newComparer = new CustomComparer<TSource, TKey>(keySelector, comparer);

            return customSource.CreateCustomOrderedEnumerable(new LinkerComparer<TSource, TKey>(linkerComparer, newComparer));
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
            List<IComparer<TSource>> comparers;

            public LinkerComparer(List<IComparer<TSource>> comparers)
            {
                this.comparers = comparers;
            }

            public LinkerComparer(LinkerComparer<TSource, TKey> linkerComparer, CustomComparer<TSource,TKey> newComparer)
            {
                comparers = linkerComparer.comparers;
                comparers.Add(newComparer);
            }

            public int Compare([AllowNull] TSource x, [AllowNull] TSource y)
            {
                int comparerResult = 0;

                foreach (var comparer in comparers)
                {
                    comparerResult = comparer.Compare(x, y);

                    if (comparerResult != 0)
                    {
                        return comparerResult;
                    }
                }

                return comparerResult;
            }
        }

        private class CustomOrderedEnumerable<TSource, TKey> : IOrderedEnumerable<TSource>
        {
            private readonly IEnumerable<TSource> source;
            private readonly LinkerComparer<TSource, TKey> linkerComparer;

            public CustomOrderedEnumerable(IEnumerable<TSource> source, LinkerComparer<TSource, TKey> linkerComparer)
            {
                this.source = source;
                this.linkerComparer = linkerComparer;
            }

            public IOrderedEnumerable<TSource> CreateCustomOrderedEnumerable<TKey>(LinkerComparer<TSource, TKey> linkComparer)
            {
                return new CustomOrderedEnumerable<TSource, TKey>(source, linkComparer);
            }

            public IEnumerator<TSource> GetEnumerator()
            {
                var list = new List<TSource>() {};

                foreach (var element in source)
                {
                    int i = 0;
                    bool inserted = false;

                    foreach (var item in list)
                    {
                        if (linkerComparer.Compare(element, item) == -1)
                        {
                            list.Insert(i, element);
                            inserted = true;
                        }

                        i++;
                    }

                    if (!inserted)
                    {
                        list.Add(element);
                    }
                }

                foreach (var item in list)
                {
                    yield return item;
                }
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public CustomOrderedEnumerable(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) { }

            public IOrderedEnumerable<TSource> CreateOrderedEnumerable<TKey>(Func<TSource, TKey> keySelector, IComparer<TKey> comparer, bool descending)
            {
                return new CustomOrderedEnumerable<TSource, TKey>(source, keySelector, comparer);
            }
        }
    }
}
