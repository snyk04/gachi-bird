using System;

namespace AreYouFruits.Common
{
    public static class FunctionsExtensions
    {
        public static TR InvokeOrDefault<TR>(this Func<TR>? func)
            where TR : struct
        {
            return func is null ? default : func.Invoke();
        }

        public static TR InvokeOrDefault<T, TR>(this Func<T, TR>? func, T param)
            where TR : struct
        {
            return func is null ? default : func.Invoke(param);
        }

        public static TR InvokeOrDefault<T1, T2, TR>(this Func<T1, T2, TR>? func, T1 param1, T2 param2)
            where TR : struct
        {
            return func is null ? default : func.Invoke(param1, param2);
        }

        public static TR InvokeOrDefault<T1, T2, T3, TR>(
            this Func<T1, T2, T3, TR>? func, T1 param1, T2 param2, T3 param3
        )
            where TR : struct
        {
            return func is null ? default : func.Invoke(param1, param2, param3);
        }

        public static TR InvokeOrDefault<T1, T2, T3, T4, TR>(
            this Func<T1, T2, T3, T4, TR>? func, T1 param1, T2 param2, T3 param3, T4 param4
        )
            where TR : struct
        {
            return func is null ? default : func.Invoke(param1, param2, param3, param4);
        }
    }
}
