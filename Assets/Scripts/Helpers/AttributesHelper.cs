using System;

namespace ESparrow.Utils.Helpers
{
    public static class AttributesHelper
    {
        public const AttributeTargets ValidOn = AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Struct;
    }
}