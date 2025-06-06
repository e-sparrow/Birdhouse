﻿using System;
using Birdhouse.Common.Helpers;
using UnityEditor;

namespace Birdhouse.Customization.Attributes.ConditionalHide
{
    [AttributeUsage(AttributesHelper.DefaultMembers)]
#if UNITY_EDITOR
    public class EnumConditionalHideAttribute
        : ConditionalHideAttributeBase
    {
        public EnumConditionalHideAttribute(string conditionalSourceField, object value, bool hideInInspector = false) : base(CreatePredicate(value), conditionalSourceField, hideInInspector)
        {
            
        }
        
        private static Predicate<SerializedProperty> CreatePredicate(object value)
        {
            return IsFit;   
            
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
    public class EnumConditionalHideAttribute 
        : Attribute
    {
        public EnumConditionalHideAttribute(string conditionalSourceField, object value, bool hideInInspector = false)
        {
            
        }
#endif
    }
}