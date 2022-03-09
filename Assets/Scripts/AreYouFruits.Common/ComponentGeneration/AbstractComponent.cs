using System;
using UnityEngine;

namespace AreYouFruits.Common.ComponentGeneration
{
    public abstract class AbstractComponent<T> : MonoBehaviour, IComponent<T>
        where T : class
    {
        private T? _heldItem;
        private bool _isStartedInitialization = false;

        public T HeldItem
        {
            get
            {
                if (_heldItem != null)
                {
                    return _heldItem;
                }

                if (_isStartedInitialization)
                {
                    throw new RecursiveInitializationException();
                }

                _isStartedInitialization = true;
                _heldItem = Create();

                return _heldItem;
            }
        }

        protected virtual void Awake()
        {
            _ = HeldItem;
        }

        protected virtual void OnDestroy()
        {
            if (HeldItem is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }

        protected abstract T Create();
    }
    //
    // public abstract class AbstractComponent<T, TInterface> : AbstractComponent<T>, IComponent<TInterface>
    //     where T : class, TInterface
    // {
    //     public TInterface GetHeldItem(out TInterface item) => item = (TInterface)HeldItem;
    //     TInterface IComponent<TInterface>.HeldItem => GetHeldItem(out _);
    // }
    //
    // public abstract class AbstractComponent<T, TI0, TI1> : AbstractComponent<T, TI0>, IComponent<TI1>
    //     where T : class, TI0, TI1
    // {
    //     public TI1 GetHeldItem(out TI1 item) => item = (TI1)HeldItem;
    //     TI1 IComponent<TI1>.HeldItem => GetHeldItem(out _);
    // }
    //
    // public abstract class AbstractComponent<T, TI0, TI1, TI2> : AbstractComponent<T, TI0, TI1>, IComponent<TI2>
    //     where T : class, TI0, TI1, TI2
    // {
    //     public TI2 GetHeldItem(out TI2 item) => item = (TI2)HeldItem;
    //     TI2 IComponent<TI2>.HeldItem => GetHeldItem(out _);
    // }
    //
    // public abstract class AbstractComponent<T, TI0, TI1, TI2, TI3> 
    //     : AbstractComponent<T, TI0, TI1, TI2>, IComponent<TI3>
    //     where T : class, TI0, TI1, TI2, TI3
    // {
    //     public TI3 GetHeldItem(out TI3 item) => item = (TI3)HeldItem;
    //     TI3 IComponent<TI3>.HeldItem => GetHeldItem(out _);
    // }
    //
    // public abstract class AbstractComponent<T, TI0, TI1, TI2, TI3, TI4> 
    //     : AbstractComponent<T, TI0, TI1, TI2, TI3>, IComponent<TI4>
    //     where T : class, TI0, TI1, TI2, TI3, TI4
    // {
    //     public TI4 GetHeldItem(out TI4 item) => item = (TI4)HeldItem;
    //     TI4 IComponent<TI4>.HeldItem => GetHeldItem(out _);
    // }
    //
    // public abstract class AbstractComponent<T, TI0, TI1, TI2, TI3, TI4, TI5> 
    //     : AbstractComponent<T, TI0, TI1, TI2, TI3, TI4>, IComponent<TI5>
    //     where T : class, TI0, TI1, TI2, TI3, TI4, TI5
    // {
    //     public TI5 GetHeldItem(out TI5 item) => item = (TI5)HeldItem;
    //     TI5 IComponent<TI5>.HeldItem => GetHeldItem(out _);
    // }
}
