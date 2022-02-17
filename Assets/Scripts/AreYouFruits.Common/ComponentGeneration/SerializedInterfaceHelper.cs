#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AreYouFruits.Common.ComponentGeneration
{
    public static class SerializedInterfaceHelper
    {
        [MenuItem("Are You Fruits?/Try fix all Inspector dependencies")]
        public static void TryFixInspectorDependencies()
        {
            IEnumerable<MonoBehaviour> components = Object.FindObjectsOfType<MonoBehaviour>();

            foreach (MonoBehaviour behaviour in components)
            {
                Type type = behaviour.GetType();

                IEnumerable<FieldInfo> fields = type
                    .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Where(field => field.IsPublic || (field.GetCustomAttribute<SerializeField>() != null))
                    .Where(field => typeof(ISerializedInterface).IsAssignableFrom(field.FieldType));

                foreach (FieldInfo field in fields)
                {
                    ISerializedInterface serializedInterface = (ISerializedInterface)field.GetValue(behaviour);

                    Type serializedInterfaceType = serializedInterface.GetType()!;

                    FieldInfo serializedInterfaceTypeObjectField = serializedInterfaceType.GetField(
                        "_object",
                        BindingFlags.Instance | BindingFlags.NonPublic
                    )!;

                    Component? foundReference = TryGetReferenceFromScene(
                        serializedInterfaceType.GenericTypeArguments[0],
                        behaviour,
                        field
                    );

                    if (foundReference == null)
                    {
                        continue;
                    }

                    Object? oldObjectValue =
                        (Object?)serializedInterfaceTypeObjectField.GetValue(serializedInterface);

                    if (oldObjectValue == null)
                    {
                        serializedInterfaceTypeObjectField.SetValue(serializedInterface, foundReference);

                        field.SetValue(behaviour, serializedInterface);
                    }
                }
            }
        }

        private static Component? TryGetReferenceFromScene(
            Type type, Object? inspectedObject = null, FieldInfo? inspectedField = null
        )
        {
            Component[] references = Object.FindObjectsOfType<Component>().Where(type.IsInstanceOfType).ToArray();

            if (references.Length > 1)
            {
                Debug.LogWarning(
                    $"There are more than one candidate for {inspectedField?.Name} in {inspectedObject?.name}",
                    inspectedObject
                );
            }

            return references.Length == 1 ? references.First() : null;
        }
    }
}

#endif
