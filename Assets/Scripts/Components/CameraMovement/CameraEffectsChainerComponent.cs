#nullable enable

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
}
