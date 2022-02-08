#nullable enable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;

namespace GachiBird.CameraMovement
{
    public sealed class CameraEffectsChainerComponent : DestroyableAbstractComponent<CameraEffectsChainer>
    {
#nullable disable
        [SerializeField] private Camera _camera;
        [SerializeField] private AbstractComponent<ICameraEffect>[] _effects;
#nullable enable
        
        protected override CameraEffectsChainer Create()
        {
            var item = new CameraEffectsChainer(_camera, _effects.Extract());
            item.Start();
            
            return item;
        }
    }
    
    public class CameraEffectsChainer : IDisposable
    {
        protected readonly Camera _camera;
        protected readonly IEnumerable<ICameraEffect> _effects;
        protected readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();
        
        public CameraEffectsChainer(Camera camera, IEnumerable<ICameraEffect> effects)
        {
            _camera = camera;
            _effects = effects;
        }

        public async void Start()
        {
            while (!_cancellationSource.Token.IsCancellationRequested)
            {
                ApplyEffects();
                
                await Task.Yield();
            }
        }

        protected virtual void ApplyEffects()
        {
            foreach (ICameraEffect effect in _effects)
            {
                effect.Apply(_camera);
            }
        }

        public virtual void Dispose() => _cancellationSource.Cancel();
    }
}
