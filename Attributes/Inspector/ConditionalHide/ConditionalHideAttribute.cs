using System;
using ESparrow.Utils.Helpers;
using UnityEditor;
using ESparrow.Utils.Attributes.Inspector.Inspector.ConditionalHide;

namespace ESparrow.Utils.Attributes.Inspector
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