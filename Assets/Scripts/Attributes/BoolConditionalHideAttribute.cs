using System;
using ESparrow.Utils.Helpers;
using UnityEditor;

namespace Utils.Attributes
{
    [AttributeUsage(AttributesHelper.ValidOn)]
    public class BoolConditionalHideAttribute : ConditionalHideAttributeBase
    {
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
    }
}