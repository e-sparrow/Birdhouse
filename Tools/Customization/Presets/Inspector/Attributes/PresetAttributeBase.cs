using System;
using ESparrow.Utils.Helpers;
using UnityEngine;

namespace ESparrow.Utils.Tools.Customization.Presets.Inspector.Attributes
{
    [AttributeUsage(AttributesHelper.DefaultMembers)]
    public abstract class PresetAttributeBase : PropertyAttribute
    {
#if UNITY_EDITOR
        public abstract Type Type
        {
            get;
        }
#else
#endif
    }
}