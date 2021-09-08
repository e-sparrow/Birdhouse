using System;
using System.Collections.Generic;

namespace ESparrow.Utils.Helpers
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
            return (T)Enum.GetValues(typeof(T)).GetValue(index);
        }

        public static void ForEach(Action<T> action)
        {
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                action.Invoke((T)value);
            }
        }

        public static IEnumerable<T> AsEnumerable()
        {
            var list = new List<T>();
            ForEach(value => list.Add(value));

            return list;
        }
    }
}
