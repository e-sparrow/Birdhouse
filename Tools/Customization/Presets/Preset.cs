using System;
using ESparrow.Utils.Tools.Customization.Presets.Interfaces;

namespace ESparrow.Utils.Tools.Customization.Presets
{
    [Serializable]
    public class Preset : IPreset
    {
        public Preset(Type type, object value)
        {
            Type = type;
            Value = value;
        }

        public Type Type
        {
            get;
        }

        public object Value
        {
            get;
        }
    }
}