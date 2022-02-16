using System;
using System.Collections.Generic;

namespace AreYouFruits.Common.Collections
{
    public static class OtherExtensions
    {
        public static T[,] For<T>(this T[,] array, Action<T> action) => ForArray<T, T[,]>(array, action);
        public static T[,,] For<T>(this T[,,] array, Action<T> action) => ForArray<T, T[,,]>(array, action);
        public static T[,,,] For<T>(this T[,,,] array, Action<T> action) => ForArray<T, T[,,,]>(array, action);
        public static T[,,,,] For<T>(this T[,,,,] array, Action<T> action) => ForArray<T, T[,,,,]>(array, action);

        // todo: Check.
        private static TArray ForArray<TElement, TArray>(Array array, Action<TElement> action) where TArray : class
        {
            For(array, new int[array.Rank], obj => action.Invoke((TElement)obj));

            return (array as TArray)!;
        }

        // todo: Check.
        private static void For(Array array, int[] indices, Action<object> action, int dimension = 0)
        {
            Action nextAction = dimension == indices.Length - 1
                ? () => action.Invoke(array.GetValue(indices))
                : (Action)(() => For(array, indices, action, dimension + 1));

            for (int i = 0; i < array.GetLength(dimension); i++)
            {
                indices[dimension] = i;
                nextAction();
            }
        }

        public static void Deconstruct<TKey, TValue>(
            this KeyValuePair<TKey, TValue> pair, out TKey key, out TValue value
        )
        {
            key = pair.Key;
            value = pair.Value;
        }
    }
}
