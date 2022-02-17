using System.Collections.Generic;
using System.Linq;

namespace AreYouFruits.Common.ComponentGeneration
{
    public static class SerializedInterfaceExtensions
    {
        public static IEnumerable<T> Extract<T>(this IEnumerable<SerializedInterface<IComponent<T>>> components) 
            where T : class
        {
            return components.Select(component => component.GetHeldItem());
        }
        
        public static T[] ExtractAsArray<T>(this IEnumerable<SerializedInterface<IComponent<T>>> components) 
            where T : class
        {
            return components.Extract().ToArray();
        }
        
        public static TLogic GetHeldItem<TLogic>(this SerializedInterface<IComponent<TLogic>> serializedInterface)
        {
            return serializedInterface.Interface.HeldItem;
        }
    }
}
