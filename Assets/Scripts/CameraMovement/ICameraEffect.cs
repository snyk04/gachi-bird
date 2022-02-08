#nullable enable

using UnityEngine;

namespace GachiBird.CameraMovement
{
    public interface ICameraEffect
    {
        public void Apply(Camera camera);
    }
}
