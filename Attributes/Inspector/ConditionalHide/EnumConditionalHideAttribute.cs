using System;
using ESparrow.Utils.Helpers;
using UnityEditor;

namespace ESparrow.Utils.Attributes.Inspector.Inspector.ConditionalHide
{
    [AttributeUsage(AttributesHelper.DefaultMembers)]
    public class EnumConditionalHideAttribute : ConditionalHideAttributeBase
    {
#if UNITY_EDITOR
        public EnumConditionalHideAttribute(string conditionalSourceField, object value, bool hideInInspector = false) : base(CreatePredicate(value), conditionalSourceField, hideInInspector)
        {
            
        }
        
        private static Predicate<SerializedProperty> CreatePredicate(object value)
        {
            return IsFit;   
            
            // TODO: execute flags
            bool IsFit(SerializedProperty property)
            {
                var names = property.enumNames;
                var index = property.enumValueIndex;

                var self = names[index];
                var other = value.ToString();
                
                return self == other;
            }
        }
#else
        public EnumConditionalHideAttribute(string conditionalSourceField, object value, bool hideInInspector = false)
        {
            
        }
#endif
    }
}