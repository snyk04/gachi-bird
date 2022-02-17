using UnityEngine;

namespace AreYouFruits.Common
{
    public static class ArrayExtensions
    {
        public static T GetRandomElement<T>(this T[] array)
        {
            int randomIndex = Random.Range(0, array.Length);
            return array[randomIndex];
        }
    }
}