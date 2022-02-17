using System;
using System.Collections;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AreYouFruits.Common.ComponentGeneration
{
    [Serializable]
    public struct SerializedInterface<TInterface>
    {
        [SerializeField] internal Object Object;
        internal Type InterfaceType => typeof(TInterface);
        public TInterface Interface => Object is TInterface @interface ? @interface : default!;

        public static implicit operator TInterface(SerializedInterface<TInterface> serializedInterface)
        {
            return serializedInterface.Interface;
        }
    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(SerializedInterface<>))]
    public class SerializedObjectDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            object serializedInterface = GetTargetObjectOfProperty(property)!;

            Type interfaceType = (Type)serializedInterface.GetType()!
                .GetProperty("InterfaceType", BindingFlags.Instance | BindingFlags.NonPublic)!
                .GetMethod.Invoke(serializedInterface, null);
            
            SerializedProperty objectProperty = property.FindPropertyRelative("Object");
            
            objectProperty.objectReferenceValue = EditorGUI.ObjectField(position, label, objectProperty.objectReferenceValue, interfaceType, true);

            EditorGUI.EndProperty();
        }
        
        private static object? GetTargetObjectOfProperty(SerializedProperty prop)
        {
            string path = prop.propertyPath.Replace(".Array.data[", "[");
            object? obj = prop.serializedObject.targetObject;
            
            foreach (string element in path.Split('.'))
            {
                if (element.Contains("["))
                {
                    string elementName = element.Substring(0, element.IndexOf("[", StringComparison.Ordinal));
                    
                    int index = Convert.ToInt32(
                        element.Substring(
                                element.IndexOf("[", StringComparison.Ordinal))
                        .Replace("[", "")
                        .Replace("]", ""));
                    
                    obj = GetValueImp(obj, elementName, index);
                }
                else
                {
                    obj = GetValueImp(obj, element);
                }
            }
            
            return obj;
        }

        private static object? GetValueImp(object? source, string name, int index)
        {
            if (!(GetValueImp(source, name) is IEnumerable enumerable))
            {
                return null;
            }

            IEnumerator enm = enumerable.GetEnumerator();
            
            for (int i = 0; i <= index; i++)
            {
                if (!enm.MoveNext())
                {
                    return null;
                }
            }
            
            return enm.Current;
        }

        private static object? GetValueImp(object? source, string name)
        {
            if (source == null)
            {
                return null;
            }

            Type? type = source.GetType();

            while (type != null)
            {
                FieldInfo? f = type.GetField(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                
                if (f != null)
                {
                    return f.GetValue(source);
                }

                PropertyInfo? p = type.GetProperty(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                
                if (p != null)
                {
                    return p.GetValue(source, null);
                }

                type = type.BaseType;
            }
            
            return null;
        }
    }
#endif
}
