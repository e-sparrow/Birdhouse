using System;

namespace Birdhouse.Common.Helpers
{
    public static class AttributesHelper
    {
        public const AttributeTargets DefaultMembers = AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Struct;
        public const AttributeTargets Methods = AttributeTargets.Method;
    }
}