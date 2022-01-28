using UnityEngine;

#nullable enable

namespace AreYouFruits.Common.ComponentGeneration
{
    public abstract class AbstractComponent<T> : MonoBehaviour where T : class
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

        protected abstract T Create();
    }
}
