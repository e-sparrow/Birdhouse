using System;
using ESparrow.Utils.Generalization.Types.Enums;
using ESparrow.Utils.Generalization.Interfaces;

namespace ESparrow.Utils.Generalization.Types
{
    public class IntGeneralizationType : IGeneralizationType
    {
        public Type Type => typeof(decimal);
        public EGeneralizationType GeneralizationType => EGeneralizationType.Decimal;
    }
}
