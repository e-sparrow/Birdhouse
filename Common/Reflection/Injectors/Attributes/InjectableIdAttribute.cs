using System;

namespace Birdhouse.Common.Reflection.Injectors.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public class InjectableIdAttribute : Attribute
    {
        public InjectableIdAttribute(string id)
        {
            Id = id;
        }

        public string Id
        {
            get;
        }
    }
}