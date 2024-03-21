using System;
using System.Collections.Generic;
using System.Linq;
using Birdhouse.Common.Extensions;

namespace Birdhouse.Common.Helpers
{
    public static class EnumsHelper<T>
        where T : Enum
    {
        public static T WithAllFlags()
        {
            var isFlagEnum = typeof(T).HasCustomAttribute<FlagsAttribute>();
            if (!isFlagEnum)
            {
                var isNotFlagMessage = $"Enum with name {typeof(T).Name} is not flags enum!";
                throw new ArgumentException(isNotFlagMessage);
            }

            long numericResult = 0;

            var targetType = Enum.GetUnderlyingType(typeof(T));
            
            var items = Enum
                .GetValues(typeof(T))
                .Cast<IEnumerable<T>>()
                .Select(value => Convert.ChangeType(value, targetType))
                .ToArray();
            
            foreach (var item in items)
            {
                numericResult |= (long) item;
            }

            var result = (T)Enum.ToObject(typeof(T), numericResult);
            return result;
        }
        
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
