﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace Birdhouse.Customization.TypeSerialization
{
    public class TypeContainer : TypeContainerBase
    {
        protected override IEnumerable<Assembly> GetAssemblies()
        {
            var domain = AppDomain.CurrentDomain;
            var assemblies = domain.GetAssemblies();

            return assemblies;
        }
    }
}