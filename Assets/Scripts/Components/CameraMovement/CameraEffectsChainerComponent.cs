using System.Collections.Generic;
using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;

namespace GachiBird.CameraMovement
{
    public sealed class CameraEffectsChainerComponent : AbstractComponent<CameraEffectsChainer>
    {
#nullable disable
        [SerializeField] private Camera _camera;
        [SerializeField] private SerializedInterface<IComponent<ICameraEffect>>[] _effects;
#nullable enable
        
        protected override CameraEffectsChainer Create()
        {
            var item = new CameraEffectsChainer(_camera, _effects.Extract());
            item.Start();
            
            return item;
        }
    }
}
