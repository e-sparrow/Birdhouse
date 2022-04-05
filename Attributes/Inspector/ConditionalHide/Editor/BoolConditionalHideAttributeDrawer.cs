using UnityEditor;

namespace ESparrow.Utils.Attributes.Inspector.Inspector.ConditionalHide.Editor
{
    #if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(BoolConditionalHideAttribute))]
    public class BoolConditionalHideAttributeDrawer : ConditionalHideAttributeDrawerBase
    {
        
    }
    #endif
}