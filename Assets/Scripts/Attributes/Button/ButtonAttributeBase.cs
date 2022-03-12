using System;
using ESparrow.Utils.Helpers;
using UnityEngine;

namespace ESparrow.Utils.Attributes.Button
{
    [AttributeUsage(AttributesHelper.Methods)]
    public class ButtonAttribute : PropertyAttribute
    {
        public ButtonAttribute(params object[] parameters)
        {
            Parameters = parameters;
        }

        public object[] Parameters
        {
            get;
        }
    }
}