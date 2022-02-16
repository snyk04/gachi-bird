using System;
using System.Collections.Generic;
using System.Linq;

namespace GachiBird.Environment.Pooling
{
    public abstract class Pool<T> : IPool<T>
    {
        protected readonly Queue<T> AvailableElements = new Queue<T>();
        protected readonly List<T> BusyElements = new List<T>();

        protected abstract T Create();
        protected virtual void HandleActivated(T element) { }
        protected virtual void HandleDeactivated(T element) { }
        protected virtual void HandleReactivated(T element) { }

        public event Action<T>? OnGet;
        public event Action<T>? OnReturn;

        public virtual T Get()
        {
            T element;
            
            if (AvailableElements.Any())
            {
                element = AvailableElements.Dequeue();
                HandleActivated(element);
            }
            else
            {
                element = BusyElements.First();
                BusyElements.RemoveAt(0);
                HandleReactivated(element);
            }

            BusyElements.Add(element);
            OnGet?.Invoke(element);

            return element;
        }

        public void Return(T element)
        {
            BusyElements.Remove(element);
            HandleDeactivated(element);
            AvailableElements.Enqueue(element);
            
            OnReturn?.Invoke(element);
        }
    }
}
