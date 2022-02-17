using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AreYouFruits.Common.ComponentGeneration
{
    public static class AbstractComponentExtensions
    {
        public static T GetHeldItem<T>(this GameObject gameObject)
        {
            return gameObject.GetComponent<IComponent<T>>().HeldItem;
        }
    }
}
