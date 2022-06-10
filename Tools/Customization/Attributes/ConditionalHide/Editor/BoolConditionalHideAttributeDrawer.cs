using UnityEditor;

namespace ESparrow.Utils.Tools.Customization.Attributes.ConditionalHide.Editor
{
    #if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(BoolConditionalHideAttribute))]
    public class BoolConditionalHideAttributeDrawer : ConditionalHideAttributeDrawerBase
    {
        
    }
    #endif
}