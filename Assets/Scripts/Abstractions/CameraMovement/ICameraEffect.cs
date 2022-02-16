#nullable enable

using UnityEngine;

namespace GachiBird.CameraMovement
{
    public interface ICameraEffect
    {

        void Apply(Camera camera);
    }
}