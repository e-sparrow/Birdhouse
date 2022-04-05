using ESparrow.Utils.Attributes.Inspector;
using UnityEditor;
using UnityEngine;

namespace ESparrow.Utils.Attributes.Inspector.Inspector.ConditionalHide.Editor
{
    #if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(ConditionalHideAttribute))]
    public class ConditionalHideAttributeDrawer : ConditionalHideAttributeDrawerBase
    {
        
    }
    #endif
}