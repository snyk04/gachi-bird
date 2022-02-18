using System;

namespace GachiBird.Environment.Pooling
{
    public abstract class InitOnStartPool<T> : Pool<T>
    {
        public override event Action<T>? OnCreate;
        public override event Action? OnInitialize;
        
        protected abstract T Create();
        
        protected void Start(int count)
        {
            for (int i = 0; i < count; i++)
            {
                T item = Create();
                AvailableElements.Enqueue(item);
                OnCreate?.Invoke(item);
            }

            OnInitialize?.Invoke();
        }
    }
}
