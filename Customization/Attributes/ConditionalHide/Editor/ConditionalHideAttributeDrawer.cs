using Birdhouse.Customization.Attributes.ConditionalHide;
using UnityEditor;
using UnityEngine;

namespace Birdhouse.Tools.Customization.Attributes.ConditionalHide
{
    #if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(ConditionalHideAttribute))]
    public class ConditionalHideAttributeDrawer : ConditionalHideAttributeDrawerBase
    {
        
    }
    #endif
}