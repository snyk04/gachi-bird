using System.Collections.Generic;
using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;

namespace GachiBird.CameraMovement
{
    public sealed class CameraEffectsChainerComponent : DestroyableAbstractComponent<CameraEffectsChainer>
    {
#nullable disable
        [SerializeField] private Camera _camera;
        [SerializeField] private AbstractComponent<ICameraEffect>[] _uncontrollableEffects;
        [SerializeField] private AbstractComponent<IControllableCameraEffect>[] _controllableEffects;
#nullable enable
        
        protected override CameraEffectsChainer Create()
        {
            var uncontrollableEffects = new List<ICameraEffect>(_uncontrollableEffects.Extract());
            var controllableEffects = new List<ICameraEffect>(_controllableEffects.Extract());

            var effects = new List<ICameraEffect>();
            effects.AddRange(uncontrollableEffects);
            effects.AddRange(controllableEffects);
            
            var item = new CameraEffectsChainer(_camera, effects);
            item.Start();
            
            return item;
        }
    }
}
