using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ESparrow.Utils.Tools.Customization.TypeSerialization.Interfaces;

namespace ESparrow.Utils.Tools.Customization.TypeSerialization
{
    public abstract class TypeContainerBase : ITypeContainer
    {
        protected abstract IEnumerable<Assembly> GetAssemblies();

        public IEnumerable<Type> GetData()
        {
            var assemblies = GetAssemblies();
            var types = assemblies.SelectMany(value => value.GetTypes());

            return types;
        }
    }
}