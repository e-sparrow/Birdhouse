using System;
using UnityEditor;
using UnityEngine;

namespace ESparrow.Utils.Attributes.Inspector.Inspector.ConditionalHide
{
    public abstract class ConditionalHideAttributeBase : PropertyAttribute
    {
#if UNITY_EDITOR
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
#endif
    }
}