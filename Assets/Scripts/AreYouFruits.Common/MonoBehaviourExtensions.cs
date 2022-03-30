using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace AreYouFruits.Common
{
    // todo: check for covariance to optimize
    public static class MonoBehaviourExtensions
    {
        public static void GetComponents<T1, T2>(this GameObject obj, out T1 c1, out T2 c2)
        {
            c1 = obj.GetComponent<T1>();
            c2 = obj.GetComponent<T2>();
        }

        public static void GetComponents<T1, T2, T3>(this GameObject obj, out T1 c1, out T2 c2, out T3 c3)
        {
            obj.GetComponents(out c1, out c2);
            c3 = obj.GetComponent<T3>();
        }

        public static void GetComponents<T1, T2, T3, T4>(
            this GameObject obj, out T1 c1, out T2 c2, out T3 c3, out T4 c4
        )
        {
            obj.GetComponents(out c1, out c2, out c3);
            c4 = obj.GetComponent<T4>();
        }

        public static void GetComponents<T1, T2, T3, T4, T5>(
            this GameObject obj, out T1 c1, out T2 c2, out T3 c3, out T4 c4, out T5 c5
        )
        {
            obj.GetComponents(out c1, out c2, out c3, out c4);
            c5 = obj.GetComponent<T5>();
        }

        public static void GetComponents<T1, T2, T3, T4, T5, T6>(
            this GameObject obj, out T1 c1, out T2 c2, out T3 c3, out T4 c4, out T5 c5, out T6 c6
        )
        {
            obj.GetComponents(out c1, out c2, out c3, out c4, out c5);
            c6 = obj.GetComponent<T6>();
        }


        public static Component[] GetAllComponents(this GameObject obj) => obj.GetComponents<Component>();

        public static T? GetVarianceComponent<T>(this GameObject obj) where T : class
        {
            return obj.GetAllComponents().FirstOrDefault(c => c is T) as T;
        }
        
        public static Component? GetVarianceComponent(this GameObject obj, Type type)
        {
            return obj.GetAllComponents().FirstOrDefault(type.IsInstanceOfType);
        }
        
        public static T[] GetVarianceComponents<T>(this GameObject obj) where T : class
        {
            return obj.GetAllComponents().Where(c => c is T).Cast<T>().ToArray();
        }
        
        public static Component[] GetVarianceComponents(this GameObject obj, Type type)
        {
            return obj.GetAllComponents().Where(type.IsInstanceOfType).ToArray();
        }

        private static T? FindComponent<T>(this IEnumerable<Component> components) where T : class
        {
            return components.FirstOrDefault(c => c is T) as T;
        }

        public static void GetVarianceComponents<T>(this GameObject obj, out T? c) where T : class
        {
            Component[] components = obj.GetAllComponents();

            c = components.FindComponent<T>();
        }

        public static void GetVarianceComponents<T1, T2>(this GameObject obj, out T1? c1, out T2? c2)
            where T1 : class where T2 : class
        {
            Component[] components = obj.GetAllComponents();

            c1 = components.FindComponent<T1>();
            c2 = components.FindComponent<T2>();
        }

        public static void GetVarianceComponents<T1, T2, T3>(
            this GameObject obj, out T1? c1, out T2? c2, out T3? c3
        ) where T1 : class where T2 : class where T3 : class
        {
            Component[] components = obj.GetAllComponents();

            c1 = components.FindComponent<T1>();
            c2 = components.FindComponent<T2>();
            c3 = components.FindComponent<T3>();
        }

        public static void GetVarianceComponents<T1, T2, T3, T4>(
            this GameObject obj, out T1? c1, out T2? c2, out T3? c3, out T4? c4
        ) where T1 : class where T2 : class where T3 : class where T4 : class
        {
            Component[] components = obj.GetAllComponents();

            c1 = components.FindComponent<T1>();
            c2 = components.FindComponent<T2>();
            c3 = components.FindComponent<T3>();
            c4 = components.FindComponent<T4>();
        }

        public static void GetVarianceComponents<T1, T2, T3, T4, T5>(
            this GameObject obj, out T1? c1, out T2? c2, out T3? c3, out T4? c4, out T5? c5
        ) where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class
        {
            Component[] components = obj.GetAllComponents();

            c1 = components.FindComponent<T1>();
            c2 = components.FindComponent<T2>();
            c3 = components.FindComponent<T3>();
            c4 = components.FindComponent<T4>();
            c5 = components.FindComponent<T5>();
        }
    }
}
