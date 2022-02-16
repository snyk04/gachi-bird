using System;

namespace AreYouFruits.Common.ComponentGeneration
{
    public class RecursiveInitializationException : InvalidOperationException
    {
        protected const string ExceptionMessage =
            "There are bilateral dependencies. (This was created to avoid Recursion Exception)";

        public RecursiveInitializationException() : base(ExceptionMessage) { }
        public RecursiveInitializationException(string message) : base(message) { }
    }
}
