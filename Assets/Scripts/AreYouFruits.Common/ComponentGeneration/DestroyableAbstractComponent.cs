using System;

namespace AreYouFruits.Common.ComponentGeneration
{
    public abstract class DestroyableAbstractComponent<TDisposable> : AbstractComponent<TDisposable>
        where TDisposable : class, IDisposable
    {
        protected virtual void OnDestroy() => HeldItem.Dispose();
    }
    
    public abstract class DestroyableAbstractComponent<TDisposable, TInterface> 
        : AbstractComponent<TDisposable, TInterface> 
        where TDisposable : class, TInterface, IDisposable
    {
        protected virtual void OnDestroy() => HeldItem.Dispose();
    }
    
    public abstract class DestroyableAbstractComponent<TDisposable, TI0, TI1> 
        : AbstractComponent<TDisposable, TI0, TI1> 
        where TDisposable : class, TI0, TI1, IDisposable
    {
        protected virtual void OnDestroy() => HeldItem.Dispose();
    }
    
    public abstract class DestroyableAbstractComponent<TDisposable, TI0, TI1, TI2> 
        : AbstractComponent<TDisposable, TI0, TI1, TI2> 
        where TDisposable : class, TI0, TI1, TI2, IDisposable
    {
        protected virtual void OnDestroy() => HeldItem.Dispose();
    }
    
    public abstract class DestroyableAbstractComponent<TDisposable, TI0, TI1, TI2, TI3> 
        : AbstractComponent<TDisposable, TI0, TI1, TI2, TI3> 
        where TDisposable : class, TI0, TI1, TI2, TI3, IDisposable
    {
        protected virtual void OnDestroy() => HeldItem.Dispose();
    }
    
    public abstract class DestroyableAbstractComponent<TDisposable, TI0, TI1, TI2, TI3, TI4> 
        : AbstractComponent<TDisposable, TI0, TI1, TI2, TI3, TI4> 
        where TDisposable : class, TI0, TI1, TI2, TI3, TI4, IDisposable
    {
        protected virtual void OnDestroy() => HeldItem.Dispose();
    }
    
    public abstract class DestroyableAbstractComponent<TDisposable, TI0, TI1, TI2, TI3, TI4, TI5> 
        : AbstractComponent<TDisposable, TI0, TI1, TI2, TI3, TI4, TI5> 
        where TDisposable : class, TI0, TI1, TI2, TI3, TI4, TI5, IDisposable
    {
        protected virtual void OnDestroy() => HeldItem.Dispose();
    }
}
