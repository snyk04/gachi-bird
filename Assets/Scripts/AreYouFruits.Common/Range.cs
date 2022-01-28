#nullable enable

using System;

namespace AreYouFruits.Common
{
    [Serializable]
    public struct Range<TRangeable>
    {
        public TRangeable Min;
        public TRangeable Max;
        public bool IsBounded;

        public Range(TRangeable min, TRangeable max)
        {
            Min = min;
            Max = max;
            IsBounded = true;
        }

        public static implicit operator Range<TRangeable>((TRangeable min, TRangeable max) tuple)
        {
            return new Range<TRangeable>(tuple.min, tuple.max);
        }
        
        public void Deconstruct(out TRangeable min, out TRangeable max)
        {
            min = Min;
            max = Max;
        }
    }
}
