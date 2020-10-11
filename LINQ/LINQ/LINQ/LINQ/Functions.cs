using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    static class Functions
    {
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            CheckIfNull(source);
            CheckIfNull(predicate);

            foreach (var item in source)
            {
                if (!predicate(item))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            CheckIfNull(source);

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return true;
                }
            }

            return false;
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            CheckIfNull(source);

            if (source.Count() == 0)
            {
                throw new InvalidOperationException("Source is Empty");
            }

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return item;
                }
            }

            throw new InvalidOperationException("Element not found");
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            CheckIfNull(source);
            CheckIfNull(selector);

            foreach (var item in source)
            {
               yield return selector(item);
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            CheckIfNull(source);
            CheckIfNull(selector);

            foreach (var item in source)
            {
                foreach(var subItem in selector(item))
                {
                    yield return subItem;
                }
            }
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            CheckIfNull(source);
            CheckIfNull(predicate);

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector)
        {
            CheckIfNull(source);
            CheckIfNull(keySelector);
            CheckIfNull(elementSelector);

            var dictionary = new Dictionary<TKey, TElement>();

            foreach (var item in source)
            {
                dictionary.Add(keySelector(item), elementSelector(item));
            }
            return dictionary;
        }

        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector)
        {
            CheckIfNull(first);
            CheckIfNull(second);

            var smallestSize = first.Count() < second.Count() ? first.Count() : second.Count();

            for (int i = 0; i < smallestSize; i++)
            {
                yield return resultSelector(first.ElementAt(i), second.ElementAt(i));
            }
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func)
        {
            CheckIfNull(source);

            var aggregate = seed;

            foreach (var element in source)
            {
                aggregate = func(aggregate, element);
            }

            return aggregate;
        }

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector)
        {
            CheckIfNull(outer);
            CheckIfNull(inner);
            CheckIfNull(outerKeySelector);
            CheckIfNull(innerKeySelector);

            foreach (var outerElement in outer)
            {
                var outerKey = outerKeySelector(outerElement);

                foreach(var innerElement in inner)
                {
                    var innerKey = innerKeySelector(innerElement);

                    if (outerKey.Equals(innerKey))
                    {
                        yield return resultSelector(outerElement, innerElement);
                    }
                }
            }
        }

        public static IEnumerable<TSource> Distinct<TSource>(
            this IEnumerable<TSource> source,
            IEqualityComparer<TSource> comparer)
        {
            CheckIfNull(source);
            return new HashSet<TSource>(source, comparer);
        }

        public static IEnumerable<TSource> Union<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            CheckIfNull(first);
            CheckIfNull(second);

            var firstResult = new HashSet<TSource>(first, comparer);
            var secondResult = new HashSet<TSource>(second, comparer);

            firstResult.UnionWith(secondResult);

            return firstResult;
        }

        public static IEnumerable<TSource> Intersect<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            CheckIfNull(first);
            CheckIfNull(second);

            var firstResult = new HashSet<TSource>(first, comparer);
            var secondResult = new HashSet<TSource>(second, comparer);

            firstResult.IntersectWith(secondResult);

            return firstResult;
        }

        public static IEnumerable<TSource> Except<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            CheckIfNull(first);
            CheckIfNull(second);

            var firstResult = new HashSet<TSource>(first, comparer);
            var secondResult = new HashSet<TSource>(second, comparer);

            var intersection = firstResult;
            intersection.IntersectWith(secondResult);

            firstResult.ExceptWith(intersection);

            return firstResult;
        }

        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            Func<TKey, IEnumerable<TElement>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        { 
            var dictionary = new Dictionary<TKey, List<TElement>> (comparer);

            foreach (var item in source)
            {
                var key = keySelector(item);
                var element = elementSelector(item);

                if (dictionary.ContainsKey(key))
                {
                    dictionary[key].Add(element);
                }
                else
                {
                    dictionary.Add(key, new List<TElement>{ element });
                }
            }

            foreach(var item in dictionary)
            {
                yield return (resultSelector(item.Key, item.Value));
            }
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IComparer<TKey> comparer)
        {
            CheckIfNull(source);
            CheckIfNull(keySelector);

            var dictionary = new Dictionary<TKey, List<TSource>>((IDictionary<TKey, List<TSource>>)comparer);

            foreach (var item in source)
            {
                var key = keySelector(item);

                if (dictionary.ContainsKey(key))
                {
                    dictionary[key].Add(item);
                }
                else
                {
                    dictionary.Add(key, new List<TSource> { item });
                }
            }

            var orderedList = new List<TSource>();

            foreach (var item in dictionary)
            {
                foreach(var subItem in item.Value)
                {
                    orderedList.Add(subItem);
                }
            }

            return (IOrderedEnumerable<TSource>)orderedList;
        }

        public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(
            this IOrderedEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IComparer<TKey> comparer)
        {
            return source.CreateOrderedEnumerable(keySelector, comparer, false);
        }

        static private void CheckIfNull(object item)
        {
            if(item == null)
            {
                throw new ArgumentNullException("Argument is null");
            }

        }      
    }    
}