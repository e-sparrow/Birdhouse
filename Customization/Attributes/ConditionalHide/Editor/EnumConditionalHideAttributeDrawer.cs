#if UNITY_EDITOR
using UnityEditor;

namespace Birdhouse.Customization.Attributes.ConditionalHide.Editor
{
    [CustomPropertyDrawer(typeof(EnumConditionalHideAttribute))]
    public class EnumConditionalHideAttributeDrawer : ConditionalHideAttributeDrawerBase
    {
        
    }
}
#endif
