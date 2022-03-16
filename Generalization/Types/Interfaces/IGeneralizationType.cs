using System;
using ESparrow.Utils.Generalization.Types.Enums;

namespace ESparrow.Utils.Generalization.Interfaces
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