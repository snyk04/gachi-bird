#nullable enable

using System.Collections.Generic;
using System.Linq;

namespace AreYouFruits.Common.ComponentGeneration
{
    public static class AbstractComponentExtensions
    {
        public static IEnumerable<T> Extract<T>(this IEnumerable<AbstractComponent<T>> components) 
            where T : class
        {
            return components.Select(component => component.HeldItem);
        }
        
        public static T[] ExtractAsArray<T>(this IEnumerable<AbstractComponent<T>> components) 
            where T : class
        {
            return components.Extract().ToArray();
        }
    }
}
