using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace AreYouFruits.Common.ComponentGeneration
{
    [Serializable]
    public struct SerializedInterface<TInterface> : ISerializedInterface
    {
#nullable disable
        [SerializeField] private Object _object;
#nullable enable

        internal Type InterfaceType => typeof(TInterface);
        public TInterface Interface => _object is TInterface @interface ? @interface : default!;

        public static implicit operator TInterface(SerializedInterface<TInterface> serializedInterface)
        {
            return serializedInterface.Interface;
        }
    }

    public interface ISerializedInterface { }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(SerializedInterface<>))]
    public class SerializedObjectDrawer : PropertyDrawer
    {
        private enum SerializeType { Interface = 0, Object, Popup }

        private const int PopupWidth = 50;
        private const int GapWidth = 2;

        private SerializeType _serializeType = SerializeType.Interface;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            SerializedProperty objectProperty = property.FindPropertyRelative("_object");

            object serializedInterface = GetTargetObjectOfProperty(property)!;

            Type interfaceType =
                (Type)serializedInterface.GetType()!.GetProperty(
                    "InterfaceType",
                    BindingFlags.Instance | BindingFlags.NonPublic
                )!.GetMethod.Invoke(serializedInterface, null);

            Rect popupPosition = new Rect(
                new Vector2(position.max.x - PopupWidth, position.position.y),
                new Vector2(PopupWidth, position.size.y)
            );

            position = new Rect(position.position, position.size - (PopupWidth + GapWidth) * Vector2.right);

            _serializeType = (SerializeType)EditorGUI.EnumPopup(popupPosition, _serializeType);

            switch (_serializeType)
            {
                case SerializeType.Interface:
                    OnGuiAsInterface(position, objectProperty, label, interfaceType);

                    break;
                case SerializeType.Object:
                    OnGuiAsObject(position, objectProperty, label, interfaceType);

                    break;
                case SerializeType.Popup:
                    OnGuiAsPopup(position, objectProperty, label, interfaceType);

                    break;
                default: throw new ArgumentOutOfRangeException();
            }

            EditorGUI.EndProperty();
        }

        private void OnGuiAsInterface(
            Rect position, SerializedProperty objectProperty, GUIContent label, Type interfaceType
        )
        {
            objectProperty.objectReferenceValue = EditorGUI.ObjectField(
                position,
                label,
                objectProperty.objectReferenceValue,
                interfaceType,
                true
            );
        }

        private GameObject? _choosingGameObject;

        private void OnGuiAsObject(
            Rect position, SerializedProperty objectProperty, GUIContent label, Type interfaceType
        )
        {
            position = EditorGUI.PrefixLabel(position, label);

            Object obj;

            if (_choosingGameObject == null)
            {
                obj = EditorGUI.ObjectField(
                    position,
                    objectProperty.objectReferenceValue,
                    typeof(Object),
                    true
                );

                if (obj == objectProperty.objectReferenceValue)
                {
                    return;
                }
            }
            else
            {
                var objectPosition = new Rect(position.position, new Vector2(position.size.x / 2, position.size.y));

                var componentPosition = new Rect(
                    position.position + (objectPosition.width + GapWidth) * Vector2.right,
                    new Vector2(position.size.x - objectPosition.size.x - GapWidth, position.size.y)
                );

                obj = EditorGUI.ObjectField(
                    objectPosition,
                    _choosingGameObject,
                    typeof(Object),
                    true
                );

                if (obj is GameObject gameObject)
                {
                    Component[] interfaceComponents = gameObject.GetVarianceComponents(interfaceType);
                    
                    if (interfaceComponents.Length == 1)
                    {
                        obj = interfaceComponents[0];
                    }
                    else if (interfaceComponents.Length > 1)
                    {
                        Component[] allComponents = gameObject.GetAllComponents();
                        int count = 0;
                        
                        int index = CustomEditorGUI.Popup(
                            componentPosition,
                            -1,
                            allComponents.Select(c => new GUIContent(count++ + " " + GetName(c))).ToArray(),
                            i => interfaceComponents.Contains(allComponents[i])
                        );

                        if (index >= 0)
                        {
                            obj = allComponents[index];
                        }
                    }
                }
            }

            _choosingGameObject = obj as GameObject;

            TrySetObjectReferenceValue(obj, objectProperty, interfaceType);

            static void TrySetObjectReferenceValue(
                Object? value, SerializedProperty objectProperty, Type interfaceType
            )
            {
                if (value is null || interfaceType.IsInstanceOfType(value))
                {
                    objectProperty.objectReferenceValue = value;
                }
            }
        }

        private void OnGuiAsPopup(
            Rect position, SerializedProperty objectProperty, GUIContent label, Type interfaceType
        )
        {
            GameObject[] gameObjects = Object.FindObjectsOfType<GameObject>();

            Component[] components = gameObjects
                .SelectMany(g => g.GetVarianceComponents(interfaceType))
                .ToArray();

            GUIContent[] variants = components.Select(
                    c =>
                    {
                        string index =
                            c.gameObject.GetVarianceComponents(interfaceType).Count()
                         <= 1
                                ? string.Empty
                                : $"[{Array.IndexOf(c.gameObject.GetAllComponents(), c)}] ";

                        return new GUIContent($"{c.gameObject.name}.{index}{GetName(c)}");
                    }
                )
                .ToArray();

            int index = EditorGUI.Popup(
                position,
                label,
                Array.IndexOf(components, (Component)objectProperty.objectReferenceValue),
                variants
            );

            objectProperty.objectReferenceValue = index == -1 ? null : components[index];
        }

        private static string GetName(Component c)
        {
            return c.GetType().GetMethod("ToString")!.DeclaringType
             == typeof(Object).GetMethod("ToString")!.DeclaringType
                    ? c.GetType().Name
                    : c.ToString();
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
                        element.Substring(element.IndexOf("[", StringComparison.Ordinal))
                            .Replace("[", "")
                            .Replace("]", "")
                    );

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
                FieldInfo? f = type.GetField(
                    name,
                    BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance
                );

                if (f != null)
                {
                    return f.GetValue(source);
                }

                PropertyInfo? p = type.GetProperty(
                    name,
                    BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase
                );

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
