using System;

namespace Birdhouse.Tools.Features
{
    public sealed class BirdhouseFeatureAttribute
        : Attribute
    {
        public BirdhouseFeatureAttribute(Type factoryType)
        {
            FactoryType = factoryType;
        }

        public Type FactoryType
        {
            get;
        }
    }
}