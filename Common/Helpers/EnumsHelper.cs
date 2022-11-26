using System;
using System.Collections.Generic;
using System.Linq;

namespace Birdhouse.Common.Helpers
{
    public static class EnumsHelper<T> where T : Enum
    {
        public static int GetCount()
        {
            var result = typeof(T)
                .GetEnumValues()
                .Length;
            
            return result;
        }

        public static T GetRandom(int seed)
        {
            var provider = new Random(seed);
            
            var result = GetRandom(provider);
            return result;
        }

        public static T GetRandom(Random random = null)
        {
            if (random == null)
            {
                random = new Random();
            }

            var next = random.Next(0, GetCount());
            
            var result = GetByIndex(next);
            return result;
        }

        public static T GetByIndex(int index)
        {
            var result = (T) Enum
                .GetValues(typeof(T))
                .GetValue(index);

            return result;
        }

        public static T GetByName(string name)
        {
            var result = Find(value => value.ToString() == name);
            return result;
        }

        public static T Find(Predicate<T> predicate)
        {
            var result = GetValues().FirstOrDefault(predicate.Invoke);
            return result;
        }

        public static void ForEach(Action<T> action)
        {
            var values = Enum.GetValues(typeof(T));
            foreach (var value in values)
            {
                action.Invoke((T) value);
            }
        }

        public static IEnumerable<T> GetValues()
        {
            var values = Enum
                .GetValues(typeof(T))
                .Cast<T>();
            
            return values;
        }
    }
}
