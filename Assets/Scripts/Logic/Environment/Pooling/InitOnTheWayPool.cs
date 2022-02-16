using System;

namespace GachiBird.Environment.Pooling
{
    public abstract class InitOnTheWayPool<T> : Pool<T>
    {
        protected abstract int MaxCount { get; }
        
        public override event Action<T>? OnCreate;
        
        protected abstract T Create();

        public sealed override T Get()
        {
            if (AvailableElements.Count + BusyElements.Count < MaxCount)
            {
                T element = Create();
                OnCreate?.Invoke(element);
                HandleActivated(element);
                AvailableElements.Enqueue(element);

                return element;
            }

            return base.Get();
        }
    }
}
