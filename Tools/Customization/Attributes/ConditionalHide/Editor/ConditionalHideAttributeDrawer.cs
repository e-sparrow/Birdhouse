using ESparrow.Utils.Attributes.Inspector;
using UnityEditor;
using UnityEngine;

namespace ESparrow.Utils.Tools.Customization.Attributes.ConditionalHide.Editor
{
    #if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(ConditionalHideAttribute))]
    public class ConditionalHideAttributeDrawer : ConditionalHideAttributeDrawerBase
    {
        
    }
    #endif
}