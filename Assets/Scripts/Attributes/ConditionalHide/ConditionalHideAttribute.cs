using System;
using ESparrow.Utils.Helpers;
using UnityEditor;
using Utils.Attributes.ConditionalHide;

namespace ESparrow.Utils.Attributes
{
    [AttributeUsage(AttributesHelper.DefaultMembers)]
    public class ConditionalHideAttribute : ConditionalHideAttributeBase
    {
        public ConditionalHideAttribute(Predicate<SerializedProperty> predicate, string conditionalSourceField, bool hideInInspector) : base(predicate, conditionalSourceField, hideInInspector)
        {
            
        }
    }
}