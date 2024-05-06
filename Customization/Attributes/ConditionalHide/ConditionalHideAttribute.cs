#if UNITY_EDITOR
using System;
using Birdhouse.Common.Helpers;
using UnityEditor;

namespace Birdhouse.Customization.Attributes.ConditionalHide
{
    [AttributeUsage(AttributesHelper.DefaultMembers)]
    public class ConditionalHideAttribute 
        : ConditionalHideAttributeBase
    {
        public ConditionalHideAttribute(Predicate<SerializedProperty> predicate, string conditionalSourceField, bool hideInInspector) 
            : base(predicate, conditionalSourceField, hideInInspector)
        {
            
        }
    }
}
#endif