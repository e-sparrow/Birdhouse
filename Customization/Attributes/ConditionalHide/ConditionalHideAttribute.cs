using System;
using Birdhouse.Common.Helpers;
using UnityEditor;

namespace Birdhouse.Customization.Attributes.ConditionalHide
{
    [AttributeUsage(AttributesHelper.DefaultMembers)]
    public class ConditionalHideAttribute : ConditionalHideAttributeBase
    {
#if UNITY_EDITOR
        public ConditionalHideAttribute(Predicate<SerializedProperty> predicate, string conditionalSourceField, bool hideInInspector) : base(predicate, conditionalSourceField, hideInInspector)
        {
            
        }
#else
        public ConditionalHideAttribute(Predicate<SerializedProperty> predicate, string conditionalSourceField, bool hideInInspector)
        {
            
        }
#endif
    }
}