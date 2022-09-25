using System;
using Birdhouse.Customization.Presets.Interfaces;

namespace Birdhouse.Customization.Presets
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