#nullable enable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AreYouFruits.Common;
using AreYouFruits.Common.Collections.InterfaceExtensions;
using UnityEngine;

namespace GachiBird.CameraMovement
{
    public class CameraEffectsChainer : IDisposable
    {
        protected readonly Camera Camera;
        protected readonly IEnumerable<ICameraEffect> Effects;
        protected readonly CancellationTokenSource CancellationSource = new CancellationTokenSource();
        
        public CameraEffectsChainer(Camera camera, IEnumerable<ICameraEffect> effects)
        {
            Camera = camera;
            Effects = effects;
        }

        public void Start()
        {
            VoidTasks.Repeat(ApplyEffects, CancellationSource.Token);
        }

        protected virtual void ApplyEffects()
        {
            foreach (ICameraEffect effect in Effects)
            {
                effect.Apply(Camera);
            }
        }

        public virtual void Dispose() => CancellationSource.Cancel();
    }
}
