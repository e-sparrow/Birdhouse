using System;
using Birdhouse.Common.Helpers;
using UnityEngine;

namespace Birdhouse.Customization.Presets.Inspector.Attributes
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