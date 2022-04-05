namespace AreYouFruits.Common
{
    public static class StructExtensions
    {
        public delegate void Modifier<T>(ref T t) where T : struct;

        public static T With<T>(this T value, Modifier<T> modifier) where T : struct
        {
            modifier(ref value);

            return value;
        }
    }

    public class Holder<T>
    {
        private T _value;

        public T Value => _value;
        public ref T ValueRef => ref _value;
        public ref readonly T ValueRefReadonly => ref _value;

        public Holder(T value) => _value = value;
        public Holder(in T value) => _value = value;
    }
}
