#nullable enable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;

namespace GachiBird.CameraMovement
{
    public class CameraEffectsChainerComponent : DestroyableAbstractComponent<CameraEffectsChainer>
    {
#nullable disable
        [SerializeField] private UnityEngine.Camera _camera;
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
        private readonly UnityEngine.Camera _camera;
        private readonly IEnumerable<ICameraEffect> _effects;
        private readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();
        
        public CameraEffectsChainer(UnityEngine.Camera camera, IEnumerable<ICameraEffect> effects)
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

        private void ApplyEffects()
        {
            foreach (ICameraEffect effect in _effects)
            {
                effect.Apply(_camera);
            }
        }

        public void Dispose() => _cancellationSource.Cancel();
    }
}
