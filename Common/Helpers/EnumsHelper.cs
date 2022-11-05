using System;
using System.Collections.Generic;
using System.Linq;

namespace Birdhouse.Common.Helpers
{
    public static class EnumsHelper<T> where T : Enum
    {
        public static int GetCount()
        {
            return typeof(T).GetEnumValues().Length;
        }

        public static T GetRandom(int seed)
        {
            return GetRandom(new Random(seed));
        }

        public static T GetRandom(Random random = null)
        {
            if (random == null)
            {
                random = new Random();
            }

            return GetByIndex(random.Next(0, GetCount()));
        }

        public static T GetByIndex(int index)
        {
            return (T) Enum.GetValues(typeof(T)).GetValue(index);
        }

        public static T GetByName(string name)
        {
            return Find(value => value.ToString() == name);
        }

        public static T Find(Predicate<T> predicate)
        {
            return GetValues().FirstOrDefault(predicate.Invoke);
        }

        public static void ForEach(Action<T> action)
        {
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                action.Invoke((T) value);
            }
        }

        public static IEnumerable<T> GetValues()
        {
            var list = new List<T>();
            ForEach(value => list.Add(value));

            return list;
        }
    }
}
