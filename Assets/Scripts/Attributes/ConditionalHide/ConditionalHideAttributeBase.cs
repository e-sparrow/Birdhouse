using System;
using UnityEditor;
using UnityEngine;

namespace Utils.Attributes.ConditionalHide
{
    public abstract class ConditionalHideAttributeBase : PropertyAttribute
    {
        protected ConditionalHideAttributeBase(Predicate<SerializedProperty> predicate, string conditionalSourceField, bool hideInInspector)
        {
            _predicate = predicate;
            
            ConditionalSourceField = conditionalSourceField;
            HideInInspector = hideInInspector;
        }
        
        private readonly Predicate<SerializedProperty> _predicate;

        public string ConditionalSourceField
        {
            get;
        }

        public bool HideInInspector
        {
            get;
        }

        public bool IsFit(SerializedProperty property)
        {
            return _predicate.Invoke(property);
        }
    }
}