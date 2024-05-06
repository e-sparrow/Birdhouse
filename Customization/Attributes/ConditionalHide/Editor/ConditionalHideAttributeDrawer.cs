#if UNITY_EDITOR
using UnityEditor;

namespace Birdhouse.Customization.Attributes.ConditionalHide.Editor
{
    [CustomPropertyDrawer(typeof(ConditionalHideAttribute))]
    public class ConditionalHideAttributeDrawer : ConditionalHideAttributeDrawerBase
    {
        
    }
}
#endif
