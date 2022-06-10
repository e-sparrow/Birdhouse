using System;
using ESparrow.Utils.Helpers;
using UnityEditor;

namespace ESparrow.Utils.Tools.Customization.Attributes.ConditionalHide
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
                var fitType = property.propertyType == SerializedPropertyType.Boolean;
                var fitValue = property.boolValue != inverse;
                var fit = fitType && fitValue;
                
                return fit;
            }
        }
#else
        public BoolConditionalHideAttribute(string conditionalSourceField, bool inverse = false,  bool hideInInspector = false)
        {
            
        }
#endif
    }
}