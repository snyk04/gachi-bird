#nullable enable

using System;
using UnityEngine;

namespace AreYouFruits.Common
{
    public static class RangeExtensions
    {
        public static bool Contains<TComparable>(this Range<TComparable> range, TComparable value)
            where TComparable : IComparable<TComparable>
        {
            return !range.IsBounded || (value.CompareTo(range.Min) >= 0 && value.CompareTo(range.Max) <= 0);
        }

        public static float Average(this Range<float> range) => (range.Min + range.Max) / 2.0f;
        public static float Average(this Range<int> range) => (range.Min + range.Max) / 2.0f;
        
        public static float Lerp(this Range<float> range, float t) => Mathf.Lerp(range.Min, range.Max, t);
        public static Color Lerp(this Range<Color> range, float t) => Color.Lerp(range.Min, range.Max, t);
        public static Vector2 Lerp(this Range<Vector2> range, float t) => Vector2.Lerp(range.Min, range.Max, t);
        public static Vector3 Lerp(this Range<Vector3> range, float t) => Vector3.Lerp(range.Min, range.Max, t);
        public static Vector3 Slerp(this Range<Vector3> range, float t) => Vector3.Slerp(range.Min, range.Max, t);
        public static Vector4 Lerp(this Range<Vector4> range, float t) => Vector4.Lerp(range.Min, range.Max, t);

        public static Quaternion Lerp(this Range<Quaternion> range, float t)
        {
            return Quaternion.Lerp(range.Min, range.Max, t);
        }

        public static Quaternion Slerp(this Range<Quaternion> range, float t)
        {
            return Quaternion.Slerp(range.Min, range.Max, t);
        }
    }
}
