using Birdhouse.Customization.Attributes.ConditionalHide;
using UnityEditor;

namespace Birdhouse.Tools.Customization.Attributes.ConditionalHide
{
    #if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(BoolConditionalHideAttribute))]
    public class BoolConditionalHideAttributeDrawer : ConditionalHideAttributeDrawerBase
    {
        
    }
    #endif
}