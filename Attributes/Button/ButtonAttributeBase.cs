using UnityEngine;

namespace ESparrow.Utils.Attributes.Button
{
    public abstract class ButtonAttributeBase : PropertyAttribute
    {
        protected ButtonAttributeBase(params object[] parameters)
        {
            Parameters = parameters;
        }

        public object[] Parameters
        {
            get;
        }
    }
}