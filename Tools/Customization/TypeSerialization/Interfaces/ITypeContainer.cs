using System;
using System.Collections.Generic;

namespace ESparrow.Utils.Tools.Customization.TypeSerialization.Interfaces
{
    public interface ITypeContainer
    {
        IEnumerable<Type> GetData();
    }
}