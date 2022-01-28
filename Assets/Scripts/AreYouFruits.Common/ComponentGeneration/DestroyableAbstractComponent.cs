using System;

namespace AreYouFruits.Common.ComponentGeneration
{
    public abstract class DestroyableAbstractComponent<T> : AbstractComponent<T> where T : class, IDisposable
    {
        protected void OnDestroy() => HeldItem.Dispose();
    }
}
