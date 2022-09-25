using System;
using System.Collections.Generic;

namespace Birdhouse.Customization.TypeSerialization.Interfaces
{
    public interface ITypeContainer
    {
        IEnumerable<Type> GetData();
    }
}