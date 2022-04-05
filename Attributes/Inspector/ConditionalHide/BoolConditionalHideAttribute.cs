using System;
using ESparrow.Utils.Helpers;
using UnityEditor;

namespace ESparrow.Utils.Attributes.Inspector.Inspector.ConditionalHide
{
    [AttributeUsage(AttributesHelper.DefaultMembers)]
    public class BoolConditionalHideAttribute : ConditionalHideAttributeBase
    {
#if UNITY_EDITOR
        public BoolConditionalHideAttribute(string conditionalSourceField, bool inverse = false,  bool hideInInspector = false) : base(CreatePredicate(inverse), conditionalSourceField, hideInInspector)
        {
            
        }
        
        private static Predicate<SerializedProperty> CreatePredicate(bool inverse)
        {
            return IsFit;
            
            bool IsFit(SerializedProperty property)
            {
                return property.boolValue != inverse;
            }
        }
#else
        public BoolConditionalHideAttribute(string conditionalSourceField, bool inverse = false,  bool hideInInspector = false)
        {
            
        }
#endif
    }
}