using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace LINQExercises
{
    static class ThenByClass
    {
        public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(
            this IOrderedEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IComparer<TKey> comparer)
        {
            var customSource = new CustomOrderedEnumerable<TSource, TKey>(source, new LinkerComparer<TSource>());

            return customSource.CreateOrderedEnumerable(keySelector, comparer, false);
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

        public class LinkerComparer<TSource> : IComparer<TSource>
        {
            IComparer<TSource> mainComparer;
            IComparer<TSource> secondComparer;

            public LinkerComparer() {}                   

            public LinkerComparer(IComparer<TSource> linkerComparer, IComparer<TSource> newComparer)
            {
                mainComparer = linkerComparer;
                secondComparer = newComparer;
            }

            public int Compare([AllowNull] TSource x, [AllowNull] TSource y)
            {
                int comparerResult = 0;

                comparerResult = mainComparer.Compare(x, y);

                if (comparerResult != 0)
                {
                    return comparerResult;
                }

                comparerResult = secondComparer.Compare(x, y);

                return comparerResult;
            }
        }

        private class CustomOrderedEnumerable<TSource, TKey> : IOrderedEnumerable<TSource>
        {
            private readonly IEnumerable<TSource> source;
            private IComparer<TSource> linkerComparer;

            public CustomOrderedEnumerable(IEnumerable<TSource> source, IComparer<TSource> linkerComparer)
            {
                this.source = source;
                this.linkerComparer = linkerComparer;
            }

            public IOrderedEnumerable<TSource> CreateOrderedEnumerable<TKey>(Func<TSource, TKey> keySelector, IComparer<TKey> comparer, bool descending)
            {
                IComparer<TSource> customComparer = new CustomComparer<TSource, TKey>(keySelector, comparer);
                var newLinkerComparer = new LinkerComparer<TSource>(linkerComparer, customComparer);

                return new CustomOrderedEnumerable<TSource, TKey>(source, newLinkerComparer);
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
        }
    }
}
