using System;
using Birdhouse.Common.Helpers;
using UnityEditor;

namespace Birdhouse.Customization.Attributes.ConditionalHide
{
    [AttributeUsage(AttributesHelper.DefaultMembers)]
#if UNITY_EDITOR
    public class BoolConditionalHideAttribute 
        : ConditionalHideAttributeBase
    {
        public BoolConditionalHideAttribute(string conditionalSourceField, bool inverse = false, bool hideInInspector = false) : base(CreatePredicate(inverse), conditionalSourceField, hideInInspector)
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
    public class BoolConditionalHideAttribute
        : Attribute
    {
        public BoolConditionalHideAttribute(string conditionalSourceField, bool inverse = false,  bool hideInInspector = false)
        {

        }
#endif
    }
}