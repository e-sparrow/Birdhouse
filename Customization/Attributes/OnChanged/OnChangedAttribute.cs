using UnityEngine;

namespace Birdhouse.Customization.Attributes.OnChanged
{
    public sealed class OnChangedAttribute
        : PropertyAttribute
    {
        public OnChangedAttribute(string methodName)
        {
            MethodName = methodName;
        }

        public string MethodName
        {
            get;
            private set;
        }
    }
}