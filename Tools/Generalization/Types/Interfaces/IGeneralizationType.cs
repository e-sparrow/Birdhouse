using System;
using Birdhouse.Tools.Generalization.Types.Enums;

namespace Birdhouse.Tools.Generalization.Types.Interfaces
{
    public interface IGeneralizationType
    {
        Type Type
        {
            get;
        }

        EGeneralizationType GeneralizationType
        {
            get;
        }
    }
}