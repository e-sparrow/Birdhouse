using System;

namespace Birdhouse.Customization.Presets.Interfaces
{
    public interface IPreset
    {
        Type Type
        {
            get;
        }

        object Value
        {
            get;
        }
    }
}