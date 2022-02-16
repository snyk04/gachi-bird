using UnityEngine;

namespace AreYouFruits.Common
{
    public static class GameObjectHelper
    {
        public static GameObject Create(
            GameObject? prefab = null, string? name = null, Transform? parent = null, Vector3 position = default
        )
        {
            GameObject gameObject = (prefab == null) ? new GameObject() : Object.Instantiate(prefab);

            if (name != null)
            {
                gameObject.name = name;
            }

            gameObject.transform.SetParent(parent);
            gameObject.transform.position = position;

            return gameObject;
        }
    }
}
