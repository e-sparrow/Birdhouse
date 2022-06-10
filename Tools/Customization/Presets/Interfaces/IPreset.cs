using System;

namespace ESparrow.Utils.Tools.Customization.Presets.Interfaces
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