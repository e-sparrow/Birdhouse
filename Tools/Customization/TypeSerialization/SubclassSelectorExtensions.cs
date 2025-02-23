using System;
using System.Linq;
using System.Reflection;

namespace Birdhouse.Tools.Customization.TypeSerialization
{
    public static class SubclassSelectorExtensions
    {
        public static Type LoadType<T>(this AssignablesSelector<T> self)
        {
            var result = Assembly.Load(self.AssemblyName)
                .DefinedTypes
                .FirstOrDefault(value => value.Name == self.TypeName.Split('/').Last());
            
            return result;
        }
    }
}