namespace AreYouFruits.Common.ComponentGeneration
{
    public interface IComponent<out T> : IComponent
    {
        public T HeldItem { get; }
    }

    public interface IComponent { }
}
