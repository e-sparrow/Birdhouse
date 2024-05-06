#if UNITY_EDITOR
using UnityEditor;

namespace Birdhouse.Customization.Attributes.ConditionalHide.Editor
{
    [CustomPropertyDrawer(typeof(BoolConditionalHideAttribute))]
    public class BoolConditionalHideAttributeDrawer 
        : ConditionalHideAttributeDrawerBase
    {
        
    }
}
#endif