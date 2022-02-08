#nullable enable

namespace AreYouFruits.Common.ComponentGeneration
{
    public interface IComponent<out T>
    {
        public T HeldItem { get; }
    }
}
