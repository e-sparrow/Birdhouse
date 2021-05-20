using System;

namespace ESparrow.Utils.Helpers
{
    public static class EnumsHelper
    {
        public static int GetCount<T>() where T : Enum
        {
            return typeof(T).GetEnumValues().Length;
        }

        public static T GetByIndex<T>(int index) where T : Enum
        {
            return (T) Enum.GetValues(typeof(T)).GetValue(index);
        }

        public static void ForEach<T>(Action<T> action) where T : Enum
        {
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                action.Invoke((T) value);
            }
        }
    }
}
