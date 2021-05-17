using System;

namespace ESparrow.Utils
{
    [Serializable]
    public class EnumValuePair<E, V> where E : Enum
    {
        public E @enum;
        public V value;
    }
}
