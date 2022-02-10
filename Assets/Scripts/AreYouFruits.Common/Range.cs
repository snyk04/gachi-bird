#nullable enable

using System;
using System.Collections.Generic;

namespace AreYouFruits.Common
{
    [Serializable]
    public struct Range<T> : IEquatable<Range<T>>
    {
        public T Min;
        public T Max;
        public bool IsBounded;

        public Range(T min, T max)
        {
            Min = min;
            Max = max;
            IsBounded = true;
        }

        public static implicit operator Range<T>((T min, T max) tuple)
        {
            return new Range<T>(tuple.min, tuple.max);
        }

        public readonly void Deconstruct(out T min, out T max)
        {
            min = Min;
            max = Max;
        }

        public readonly void Deconstruct(out T min, out T max, out bool isBounded)
        {
            (min, max) = this;
            isBounded = IsBounded;
        }

        public bool Equals(Range<T> other)
        {
            return EqualityComparer<T>.Default.Equals(Min, other.Min)
             && EqualityComparer<T>.Default.Equals(Max, other.Max)
             && IsBounded == other.IsBounded;
        }

        public override bool Equals(object? obj) => obj is Range<T> other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = EqualityComparer<T>.Default.GetHashCode(Min);
                hashCode = (hashCode * 397) ^ EqualityComparer<T>.Default.GetHashCode(Max);
                hashCode = (hashCode * 397) ^ IsBounded.GetHashCode();

                return hashCode;
            }
        }
    }
}
