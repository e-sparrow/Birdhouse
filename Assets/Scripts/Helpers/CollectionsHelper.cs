using System;
using System.Linq;
using System.Collections.Generic;

namespace ESparrow.Utils.Helpers
{
    public static class CollectionsHelper
    {
        public static IEnumerable<TResult> ForEachResult<TInput, TResult>(IEnumerable<TInput> collection, Func<TInput, TResult> func)
        {
            var list = new List<TResult>();
            foreach (var input in collection)
            {
                list.Add(func.Invoke(input));
            }

            return list.AsEnumerable();
        }

        public static IEnumerable<T> For<T>(Func<int, T> func, int count)
        {
            var list = new List<T>();

            for (int i = 0; i < count; i++)
            {
                list.Add(func(i));
            }

            return list.AsEnumerable();
        }

        public static IEnumerable<T> Append<T>(params IEnumerable<T>[] collections)
        {
            var list = new List<IEnumerable<T>>();
            foreach (var collection in collections)
            {
                list.Add(collection);
            }

            return list.SelectMany(value => value).AsEnumerable();
        }
    }
}
