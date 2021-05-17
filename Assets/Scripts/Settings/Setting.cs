using System;
using ESparrow.Utils.Enums;

namespace ESparrow.Utils.Settings
{
    [Serializable]
    public class Setting
    {
        public string key;

        public Type type;
        public object value;

        public Setting(string key, Type type, object value)
        {
            this.key = key;
            this.type = type;
            this.value = value;
        }
    }
}
