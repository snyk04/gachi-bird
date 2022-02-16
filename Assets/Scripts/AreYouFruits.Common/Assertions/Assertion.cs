using System;
using System.Diagnostics;
using UnityEngine;

namespace AreYouFruits.Common.Assertions
{
    public static class Assertion
    {
        private const string DirectiveName = "ASSERTIONS_ENABLED";

        [Conditional(DirectiveName)]
        public static void AssertNotNull<TNullable>(this TNullable? nullable, string? name = "")
            where TNullable : class
        {
            if (nullable == null)
            {
                string valueName = string.IsNullOrEmpty(name) ? "value" : name!;

                throw new ArgumentNullException($"{valueName} should not be null");
            }
        }

        [Conditional(DirectiveName)]
        public static void AssertNotNull<TBehaviour>(this TBehaviour behaviour, params object?[] nullables)
            where TBehaviour : MonoBehaviour
        {
            int i = 0;

            foreach (object? nullable in nullables)
            {
                nullable.AssertNotNull($"Value #{i} in {behaviour.GetType().Name}");

                i++;
            }
        }

        [Conditional(DirectiveName)]
        public static void ThrowIf<TException>(bool condition, TException exception) where TException : Exception
        {
            if (condition)
            {
                throw exception;
            }
        }

        [Conditional(DirectiveName)]
        public static void ThrowIf(bool condition, string message) => ThrowIf(condition, new Exception(message));
    }
}
