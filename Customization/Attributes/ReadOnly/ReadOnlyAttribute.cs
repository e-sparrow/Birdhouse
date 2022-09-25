using System;
using Birdhouse.Common.Helpers;
using UnityEngine;

namespace Birdhouse.Customization.Attributes.ReadOnly
{
    [AttributeUsage(AttributesHelper.DefaultMembers)]
    public class ReadOnlyAttribute : PropertyAttribute
    {

    }
}