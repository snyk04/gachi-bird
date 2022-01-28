#nullable enable

using UnityEngine;

namespace AreYouFruits.Common
{
    public static class MonoBehaviourExtensions
    {
        public static void GetComponents<T1, T2>(this Component behaviour, out T1 c1, out T2 c2)
        {
            c1 = behaviour.GetComponent<T1>();
            c2 = behaviour.GetComponent<T2>();
        }

        public static void GetComponents<T1, T2, T3>(this Component behaviour, out T1 c1, out T2 c2, out T3 c3)
        {
            c1 = behaviour.GetComponent<T1>();
            c2 = behaviour.GetComponent<T2>();
            c3 = behaviour.GetComponent<T3>();
        }

        public static void GetComponents<T1, T2, T3, T4>(
            this Component behaviour, out T1 c1, out T2 c2, out T3 c3, out T4 c4
        )
        {
            c1 = behaviour.GetComponent<T1>();
            c2 = behaviour.GetComponent<T2>();
            c3 = behaviour.GetComponent<T3>();
            c4 = behaviour.GetComponent<T4>();
        }

        public static void GetComponents<T1, T2, T3, T4, T5>(
            this Component behaviour, out T1 c1, out T2 c2, out T3 c3, out T4 c4, out T5 c5
        )
        {
            c1 = behaviour.GetComponent<T1>();
            c2 = behaviour.GetComponent<T2>();
            c3 = behaviour.GetComponent<T3>();
            c4 = behaviour.GetComponent<T4>();
            c5 = behaviour.GetComponent<T5>();
        }

        public static void GetComponents<T1, T2, T3, T4, T5, T6>(
            this Component behaviour, out T1 c1, out T2 c2, out T3 c3, out T4 c4, out T5 c5, out T6 c6
        )
        {
            c1 = behaviour.GetComponent<T1>();
            c2 = behaviour.GetComponent<T2>();
            c3 = behaviour.GetComponent<T3>();
            c4 = behaviour.GetComponent<T4>();
            c5 = behaviour.GetComponent<T5>();
            c6 = behaviour.GetComponent<T6>();
        }
    }
}
