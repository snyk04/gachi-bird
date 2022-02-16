using System;

namespace GachiBird.Environment.Pooling
{
    public interface IPool<T>
    {
        event Action<T>? OnGet;
        event Action<T>? OnReturn;
        event Action<T>? OnCreate;
        T Get();
        void Return(T element);
    }
}
