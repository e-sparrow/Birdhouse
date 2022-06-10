using UnityEditor;

namespace ESparrow.Utils.Tools.Customization.Attributes.ConditionalHide.Editor
{
    #if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(EnumConditionalHideAttribute))]
    public class EnumConditionalHideAttributeDrawer : ConditionalHideAttributeDrawerBase
    {
        
    }
    #endif
}