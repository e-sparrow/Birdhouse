using System;
using System.Collections.Generic;
using Birdhouse.Abstractions.Misc;

namespace Birdhouse.Tools.Customization.TypeSerialization.Abstractions
{
    public interface IReadOnlyTypePreloader
    {
        IEnumerable<Type> GetTypes();
    }
    
    public interface ITypePreloader
        : IReadOnlyTypePreloader, IUpdatable
    {
        
    }
}