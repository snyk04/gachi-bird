using System;

namespace AreYouFruits.Common.ComponentGeneration
{
    public abstract class DestroyableAbstractComponent<T, TDisposable> : AbstractComponent<T> 
        where T : class
        where TDisposable : T, IDisposable
    {
        protected virtual void OnDestroy() => ((TDisposable)HeldItem).Dispose();
    }
    
    public abstract class DestroyableAbstractComponent<TDisposable> 
        : DestroyableAbstractComponent<TDisposable, TDisposable>
        where TDisposable : class, IDisposable { }
}
