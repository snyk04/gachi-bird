namespace GachiBird.Environment.Pooling
{
    public abstract class InitOnTheWayPool<T> : Pool<T>
    {
        protected abstract int MaxCount { get; }

        public sealed override T Get()
        {
            if (AvailableElements.Count + BusyElements.Count < MaxCount)
            {
                T element = Create();
                HandleActivated(element);
                AvailableElements.Enqueue(element);

                return element;
            }

            return base.Get();
        }
    }
}
