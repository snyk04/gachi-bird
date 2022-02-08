#nullable enable

namespace GachiBird.Environment.Pooling
{
    public abstract class InitOnStartPool<T> : Pool<T>
    {
        protected void Start(int count)
        {
            for (int i = 0; i < count; i++)
            {
                AvailableElements.Enqueue(Create());
            }
        }
    }
}
