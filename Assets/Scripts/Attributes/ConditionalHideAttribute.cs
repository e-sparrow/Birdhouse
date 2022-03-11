using System;
using ESparrow.Utils.Helpers;
using UnityEditor;
using Utils.Attributes;

namespace ESparrow.Utils.Attributes
{
    [AttributeUsage(AttributesHelper.ValidOn)]
    public class ConditionalHideAttribute : ConditionalHideAttributeBase
    {
        public ConditionalHideAttribute(Predicate<SerializedProperty> predicate, string conditionalSourceField, bool hideInInspector) : base(predicate, conditionalSourceField, hideInInspector)
        {
            
        }
    }
}