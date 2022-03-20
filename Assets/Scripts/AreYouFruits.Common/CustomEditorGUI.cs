#if UNITY_EDITOR

using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace AreYouFruits.Common
{
    public static class CustomEditorGUI
    {
        public static class Reflections
        {
            public static MethodInfo DoPopup = typeof(EditorGUI)
                .GetMethods(BindingFlags.Static | BindingFlags.NonPublic)
                .Where(m => m.Name == "DoPopup")
                .First(m => m.GetParameters().Length == 6);
        }

        public static class Delegates
        {
            public static readonly Func<Rect, int, int, GUIContent[], Func<int, bool>, GUIStyle, int> DoPopup =
                (Func<Rect, int, int, GUIContent[], Func<int, bool>, GUIStyle, int>)Delegate.CreateDelegate(
                    typeof(Func<Rect, int, int, GUIContent[], Func<int, bool>, GUIStyle, int>),
                    null,
                    Reflections.DoPopup
                );
        }

        public static int Popup(
            Rect position, int selectedIndex, GUIContent[] displayedOptions, Func<int, bool> checkEnabled
        )
        {
            //return EditorGUI.DoPopup(
            return Delegates.DoPopup(
                EditorGUI.IndentedRect(position),
                GUIUtility.GetControlID("EditorPopup".GetHashCode(), FocusType.Keyboard, position),
                selectedIndex,
                displayedOptions,
                checkEnabled,
                EditorStyles.popup
            );
        }

        public static Rect PrefixLabel(Rect position, float labelWidth, GUIContent label, GUIStyle? style = null)
        {
            Rect labelPosition = position;
            labelPosition.width = labelWidth;

            if (style == null)
            {
                EditorGUI.LabelField(labelPosition, label);
            }
            else
            {
                EditorGUI.LabelField(labelPosition, label, style);
            }

            position.x += labelWidth;
            position.width -= labelWidth;

            return position;
        }
    }
}

#endif
