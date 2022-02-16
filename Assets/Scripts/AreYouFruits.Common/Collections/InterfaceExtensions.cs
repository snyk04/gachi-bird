using System;
using System.Collections;
using System.Collections.Generic;

namespace AreYouFruits.Common.Collections.InterfaceExtensions
{
    public static class InterfaceExtensions
    {
        public static IDictionary<TKey, TValue> Foreach<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary, Action<TKey, TValue> action
        )
        {
            foreach ((TKey key, TValue value) in dictionary)
            {
                action.Invoke(key, value);
            }

            return dictionary;
        }

        public static IEnumerable<T> Foreach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (T element in collection)
            {
                action.Invoke(element);
            }

            return collection;
        }

        public static IEnumerable ForeachNonGeneric(this IEnumerable collection, Action<object> action)
        {
            foreach (object element in collection)
            {
                action.Invoke(element);
            }

            return collection;
        }

        public static IReadOnlyCollection<T> For<T>(this IReadOnlyCollection<T> array, Action<int> action)
        {
            for (int i = 0; i < array.Count; i++)
            {
                action.Invoke(i);
            }

            return array;
        }

        public static IReadOnlyList<T> For<T>(this IReadOnlyList<T> array, Action<int, T> action)
        {
            for (int i = 0; i < array.Count; i++)
            {
                action.Invoke(i, array[i]);
            }

            return array;
        }

        public static void SafeAddToValueCollection<TKey, TValue, TCollection>(
            this IDictionary<TKey, TCollection> dictionary, TKey key, TValue value
        ) where TCollection : ICollection<TValue>, new()
        {
            if (!dictionary.TryGetValue(key, out TCollection valueList))
            {
                valueList = dictionary[key] = new TCollection();
            }

            valueList.Add(value);
        }
    }
}
