using UnityEngine;

namespace AreYouFruits.Common.UnityWithInterfaces
{
    internal static class UnityInterfaceExtensions
    {
        internal static IRigidbody ToUnityInterface(this Rigidbody rigidbody) => new RigidbodyHolder(rigidbody);
        internal static IRigidbody2D ToUnityInterface(this Rigidbody2D rigidbody) => new Rigidbody2DHolder(rigidbody);
    }
}
