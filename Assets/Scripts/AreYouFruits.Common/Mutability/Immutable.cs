namespace AreYouFruits.Common.Mutability
{
    public readonly struct Immutable<T> where T : struct
    {
        public readonly T Value;

        public Immutable(in T value)
        {
            Value = value;
        }

        public static implicit operator Immutable<T>(in T value)
        {
            return new Immutable<T>(in value);
        }
    }
}
