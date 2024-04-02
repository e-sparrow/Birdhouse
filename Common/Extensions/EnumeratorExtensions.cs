using System;
using System.Collections;
using System.Collections.Generic;

namespace Birdhouse.Common.Extensions
{
    public static class EnumeratorExtensions
    {
        public static T CircularNext<T>(this IEnumerator<T> self)
        {
            var isLast = !self.MoveNext();
            if (isLast)
            {
                self.Reset();
            }

            return self.Current;
        }

        public static void Foreach(this IEnumerator self, Action<object> callback)
        {
            self.Reset();
            while (self.MoveNext())
            {
                callback.Invoke(self.Current);
            }
        }

        public static void Foreach<T>(this IEnumerator<T> self, Action<T> callback)
        {
            self.Reset();
            while (self.MoveNext())
            {
                callback.Invoke(self.Current);
            }
        }

        public static IEnumerator Select(this IEnumerator self, Func<object, object> selector)
        {
            self.Reset();
            while (self.MoveNext())
            {
                yield return selector.Invoke(self.Current);
            }
        }

        public static IEnumerator<TTo> Select<TFrom, TTo>(this IEnumerator<TFrom> self, Func<TFrom, TTo> selector)
        {
            self.Reset();
            while (self.MoveNext())
            {
                yield return selector.Invoke(self.Current);
            }
        }

        public static IEnumerator<TTo> Select<TTo>(this IEnumerator self, Func<object, TTo> selector)
        {
            self.Reset();
            while (self.MoveNext())
            {
                yield return selector.Invoke(self.Current);
            }
        }
    }
}