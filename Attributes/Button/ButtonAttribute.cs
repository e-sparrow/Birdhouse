using System;
using ESparrow.Utils.Helpers;

namespace ESparrow.Utils.Attributes.Button
{
    [AttributeUsage(AttributesHelper.Methods)]
    public class ButtonAttribute : ButtonAttributeBase
    {
        public ButtonAttribute()
        {
            
        }

        public ButtonAttribute(params object[] parameters) : base(parameters)
        {
            
        }
    }
}