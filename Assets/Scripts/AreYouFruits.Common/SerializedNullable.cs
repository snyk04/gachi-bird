using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AreYouFruits.Common
{
    [Serializable]
    public struct SerializedNullable<T> where T : struct
    {
        public T Value;
        public bool HasValue;

        public SerializedNullable(T? value)
        {
            Value = value.GetValueOrDefault();
            HasValue = value.HasValue;
        }

        public void Deconstruct(out T value, out bool hasValue) => (value, hasValue) = (Value, HasValue);

        public static implicit operator T?(in SerializedNullable<T> serializedNullable)
        {
            (T value, bool hasValue) = serializedNullable;

            return hasValue ? value : (T?)null;
        }
    }
    
#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(SerializedNullable<>))]
    public sealed class SerializedNullableDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property.FindPropertyRelative("Value"));
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            
            SerializedProperty valueProperty = property.FindPropertyRelative("Value");
            SerializedProperty nullProperty = property.FindPropertyRelative("HasValue");

            Rect nullPosition = position;
            nullPosition.x += position.width - position.height;
            nullPosition.width = position.height;

            Rect propertyPosition = position;
            propertyPosition.width -= nullPosition.height - 2.0f;

            nullProperty.boolValue = EditorGUI.Toggle(nullPosition, nullProperty.boolValue);
            
            bool guiEnabled = GUI.enabled;
            GUI.enabled &= nullProperty.boolValue;
            EditorGUI.PropertyField(propertyPosition, valueProperty, label, true);
            GUI.enabled = guiEnabled;
                
            EditorGUI.EndProperty();
        }
    }
#endif
}
